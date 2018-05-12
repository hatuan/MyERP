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
