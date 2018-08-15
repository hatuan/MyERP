Ext.onReady(function () {
    var sidebarRight = document.getElementById('rightnav-body');
    Ps.initialize(sidebarRight);

    Ext.get("menu-button", true).on({
        click: function () {
            App.rightnav[App.rightnav.isHidden() ? "show" : "hide"]();
            Ps.update(sidebarRight);
        }
    });

    Ext.select("[data-toggle='collapse'", true).on({
        click: function (e) {
            e.preventDefault();

            this.toggleCls("expanded");
            Ext.get((this.getAttribute("data-target")).substring(1)).toggleCls("expanded");
        }
    });
});

var lockHistoryChange = false;

var lookup = {};

var loadModule = function (href, id, title) {
    var tab = App.ExampleTabs.getComponent(id),
        lObj = lookup[href];

    var slashFields = href.split("/");
    if (slashFields.length > 3) {
        href = "";
        for (var i in [0, 1, 2]) {
            href = href + slashFields[i] + "/"
        }
    } else if(href[href.length - 1] != "/") {
        href = href + "/";
    }

    if (id == "-") {
        App.direct.GetHashCode(href, {
            success: function (result) {
                loadModule(href, "e" + result, title);
            }
        });

        return;
    }

    lookup[href] = id;

};

var change = function (token) {
    if (!lockHistoryChange) {
        if (token) {
            loadModule(token, lookup[token] || "-");
        } else {
            
        }
    }
    lockHistoryChange = false;
};

var getToken = function (url) {
    var host = window.location.protocol + "//" + window.location.host;

    return url.substr(host.length);
};

var addToken = function (el, tab) {
    if (tab.loader && tab.loader.url) {
        var token = getToken(tab.loader.url);

        Ext.History.add(token);
    } else if (tab.historyToken) {
        Ext.History.add(tab.historyToken);
    } else {
        Ext.History.add("");
    }
};

var keyUp = function (field, e) {
    if (e.getKey() === 40) {
        return;
    }

    if (e.getKey() === Ext.event.Event.ESC) {
        clearFilter(field);
    } else {
        changeFilterHash(field.getRawValue().replace(" ", "+"));
        filter(field);
    }
};

if (window.location.href.indexOf("#") > 0) {
    var directLink = window.location.href.substr(window.location.href.indexOf("#") + 1)
                    .replace(/(\s|\<|&lt;|%22|%3C|\"|\'|&quot|&#039;|script)/gi, '');

    Ext.onReady(function () {
        Ext.Function.defer(function () {
            if (!Ext.isEmpty(directLink, false)) {
                loadModule(directLink, "-");
            }
        }, 100, window);
    }, window);
}

var CashReceipt = {
    CorrespAccountRenderer: function(value, metadata, record, rowIndex, colIndex, store) {
        if (!Ext.isEmpty(record.data.CorrespAccountCode) && value > 0) {
            return record.data.CorrespAccountCode;
        }
        return "";
    },

    CashLineBeforeEdit: function (editor, e) {
        e.grid.getSelectionModel().select(e.rowIdx, true);

        var field = this.getEditor(e.record, e.column).field;

        switch (e.field) {
            case "CorrespAccountId":
                field.store.id = e.record.data.CorrespAccountId;
                if (e.record.data.CorrespAccount != null) {
                    field.store.add(e.record.data.CorrespAccount);
                }
                break;
        }
    },

    CashLineEdit: function (editor, e) {
         if (!(e.value === e.originalValue || (Ext.isDate(e.value) && Ext.Date.isEqual(e.value, e.originalValue)))) {
             Ext.net.DirectMethod.request({
                 url: "/Cash/CashReceipt/LineEdit",
                 params: {
                     lineNo: e.record.data.LineNo,
                     field: e.field,
                     oldValue: e.originalValue,
                     newValue: e.value,
                     recordData: e.record.data
                 },
                 eventMask: {
                     showMask: false
                 },
                 success: function() {
                 }
             });
         }
    }
};

