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

var makeTab = function (id, url, title) {
    var win,
        tab,
        hostName,
        exampleName,
        node,
        tabTip;

    if (id === "-") {
        id = Ext.id(undefined, "extnet");
        lookup[url] = id;
    }

    tabTip = url.replace(/^\//g, "");
    tabTip = tabTip.replace(/\/$/g, "");
    tabTip = tabTip.replace(/\//g, " > ");
    tabTip = tabTip.replace(/_/g, " ");

    win = new Ext.window.Window({
        id: "w" + id,
        layout: "fit",
        title: "Source Code",
        iconCls: "fa fa-code",
        width: 925,
        height: 650,
        border: false,
        maximizable: true,
        constrain: true,
        closeAction: "hide",
        listeners: {
            show: {
                fn: function () {
                    var me = this,
                        height = Ext.getBody().getViewSize().height;

                    if (this.getSize().height > height) {
                        this.setHeight(height - 20)
                    }

                    App.direct.GetSourceTabs(id, url, this.nsId, {
                        eventMask: {
                            showMask: true,
                            customTarget: this.body
                        },
                        failure: function (msg, response) {
                            Ext.Msg.alert("Failure", "The error during example loading:\n" + response.responseText);
                        }
                    });
                },

                single: true
            }
        },
        buttons: [
            {
                id: "b" + id,
                text: "Download",
                iconCls: "fa fa-download",
                listeners: {
                    click: {
                        fn: function (el, e) {
                            App.direct.DownloadExample(url, {
                                isUpload: true,
                                formId: "downloadForm"
                            });
                        }
                    }
                }
            }
        ]
    });

    hostName = window.location.protocol + "//" + window.location.host;
    exampleName = url;

    tab = App.ExampleTabs.add(new Ext.panel.Panel({
        id: id,
        tbar: [{
            text: "Source Code",
            iconCls: "fa fa-code",
            listeners: {
                "click": function () {
                    Ext.getCmp("w" + id).show(null);
                }
            }
        },
        "->",
        {
            text: "Direct Link",
            iconCls: "fa fa-link",
            handler: function () {
                new Ext.window.Window({
                    modal: true,
                    iconCls: "fa fa-link",
                    layout: "absolute",
                    defaultButton: "dl" + id,
                    width: 400,
                    height: 140,
                    title: "Direct Link",
                    closable: false,
                    resizable: false,
                    items: [{
                        id: "dl" + id,
                        xtype: "textfield",
                        cls: "dlText",
                        width: 364,
                        x: 10,
                        y: 10,
                        selectOnFocus: true,
                        readOnly: true,
                        value: hostName + "/#" + exampleName
                    }],
                    buttons: [{
                        xtype: "button",
                        text: " Open",
                        iconCls: "fa fa-external-link",
                        tooltip: "Open Example in the separate window",
                        handler: function () {
                            window.open(hostName + "/#" + exampleName);
                        }
                    },
                    {
                        xtype: "button",
                        text: " Open (Direct)",
                        iconCls: "fa fa-external-link-square",
                        tooltip: "Open Example in the separate window using a direct link",
                        handler: function () {
                            window.open(hostName + url, "_blank");
                        }
                    },
                    {
                        xtype: "button",
                        text: "Close",
                        handler: function () {
                            this.findParentByType("window").hide(null);
                        }
                    }]
                }).show(null);
            }
        },
        "-",
        {
            text: "Refresh",
            handler: function () {
                Ext.getCmp(id).reload(true)
            },
            iconCls: "fa fa-refresh"
        }],
        title: title,
        tabTip: tabTip,
        hideMode: "offsets",

        loader: {
            renderer: "frame",
            url: hostName + url,
            listeners: {
                beforeload: function () {
                    this.target.body.mask('Loading...');
                },
                load: function (loader) {
                    this.target.body.unmask();
                }
            }
        },
        listeners: {
            deactivate: {
                fn: function (el) {
                    if (this.sWin && this.sWin.isVisible()) {
                        this.sWin.hide();
                    }
                }
            },

            destroy: function () {
                if (this.sWin) {
                    this.sWin.close();
                    this.sWin.destroy();
                }
            }
        },
        closable: true
    }));

    tab.sWin = win;
    setTimeout(function () {
        App.ExampleTabs.setActiveTab(tab);
    }, 250);
 };

var lookup = {};

var loadExample = function (href, id, title) {
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
                loadExample(href, "e" + result, title);
            }
        });

        return;
    }

    lookup[href] = id;

    if (tab) {
        App.ExampleTabs.setActiveTab(tab);
    } else {
        if (Ext.isEmpty(title)) {
            var m = /(\w+)\/$/g.exec(href);
            title = m == null ? "[No name]" : m[1];
        }

        title = title.replace(/<span>&nbsp;<\/span>/g, "");
        title = title.replace(/_/g, " ");
        makeTab(id, href, title);
    }
};

var change = function (token) {
    if (!lockHistoryChange) {
        if (token) {
            loadExample(token, lookup[token] || "-");
        } else {
            App.ExampleTabs.setActiveTab(0);
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
                loadExample(directLink, "-");
            }
        }, 100, window);
    }, window);
}

mainMenuClick = function(menuItem) {
    
}