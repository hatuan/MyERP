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
    } else if(href[href.length - 1] !== "/") {
        href = href + "/";
    }

    if (id === "-") {
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
            //    
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


var showPreviewReport = function(fileNameOfSnapshotReport) {
    Ext.create("Ext.window.Window", {
        renderTo: Ext.net.ResourceMgr.getRenderTarget(),
        title: "Report Preview",
        width: 200,
        frame: true,
        items: [{
            loader:
            {
                paramsFn: function () { return { fileName: fileNameOfSnapshotReport }; },
                renderer: 'frame',
                url: baseURL + 'Report'
            }
        }],
        layout: 'fit',
        bodyPadding: 0,
        closeAction: 'destroy',
        iconCls: '#Printer',
        maximized: true,
        modal: true
    }).show();
};

var showHtmlPreviewReport = function (fileHtmlRenderName) {
    Ext.create("Ext.window.Window", {
        renderTo: Ext.net.ResourceMgr.getRenderTarget(),
        title: "Report Preview",
        width: 200,
        frame: true,
        items: [{
            loader:
            {
                renderer: 'frame',
                url: baseURL + 'Resources/PrintReports/EInvoices/' + fileHtmlRenderName +'.html'
            }
        }],
        layout: 'fit',
        bodyPadding: 0,
        closeAction: 'destroy',
        iconCls: '#Printer',
        maximized: true,
        modal: true
    }).show();
};

var CashReceipt = {
    CorrespAccountRenderer: function(value, metadata, record, rowIndex, colIndex, store) {
        if (Ext.isDefined(record.data.CorrespAccount) && record.data.CorrespAccount !== null && value > 0) {
            return record.data.CorrespAccount.Code;
        }
        return "";
    },

    CashLineBeforeEdit: function (editor, e) {
        e.grid.getSelectionModel().select(e.rowIdx, true);

        var field = this.getEditor(e.record, e.column).field;

        switch (e.field) {
            case "CorrespAccountId":
                field.store.id = e.record.data.CorrespAccountId;
                if (e.record.data.CorrespAccount !== null) {
                    field.store.add(e.record.data.CorrespAccount);
                }
                break;
        }
    },

    CalcHeaderTotal: function (grid) {
        var sumAmount = 0;
        var sumAmountLCY = 0;

        grid.getStore().each(function (record) {
            var v = (record.get("Amount") + "").replace(/\./g, '').replace(',', '.');
            sumAmount += parseFloat(v);

            v = (record.get("AmountLCY") + "").replace(/\./g, '').replace(',', '.');
            sumAmountLCY += parseFloat(v);
        });

        var totalAmountId = "TotalAmount";
        var totalAmountLCYId = "TotalAmountLCY";

        Ext.getCmp(totalAmountId).setRawValue(Ext.util.Format.number(sumAmount, '0.000,00/i'));
        Ext.getCmp(totalAmountLCYId).setRawValue(Ext.util.Format.number(sumAmountLCY, '0.000,00/i'));
    }

    /*
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
    */
};

var CashPayment = {
    CorrespAccountRenderer: function (value, metadata, record, rowIndex, colIndex, store) {
        if (Ext.isDefined(record.data.CorrespAccount) && record.data.CorrespAccount !== null && value > 0) {
            return record.data.CorrespAccount.Code;
        }
        return "";
    },

    CashLineBeforeEdit: function (editor, e) {
        e.grid.getSelectionModel().select(e.rowIdx, true);

        var field = this.getEditor(e.record, e.column).field;

        switch (e.field) {
            case "CorrespAccountId":
                field.store.id = e.record.data.CorrespAccountId;
                if (e.record.data.CorrespAccount !== null) {
                    field.store.add(e.record.data.CorrespAccount);
                }
                break;
        }
    },

    CalcHeaderTotal: function (grid) {
        var sumAmount = 0;
        var sumAmountLCY = 0;

        grid.getStore().each(function (record) {
            var v = (record.get("Amount") + "").replace(/\./g, '').replace(',', '.');
            sumAmount += parseFloat(v);

            v = (record.get("AmountLCY") + "").replace(/\./g, '').replace(',', '.');
            sumAmountLCY += parseFloat(v);
        });

        var totalAmountId = "TotalAmount";
        var totalAmountLCYId = "TotalAmountLCY";

        Ext.getCmp(totalAmountId).setRawValue(Ext.util.Format.number(sumAmount, '0.000,00/i'));
        Ext.getCmp(totalAmountLCYId).setRawValue(Ext.util.Format.number(sumAmountLCY, '0.000,00/i'));
    }
};

var PurchaseInvoice = {

    ItemRenderer: function (value, metadata, record, rowIndex, colIndex, store) {

        if (Ext.isDefined(record.data.Item) && record.data.Item !== null && value > 0) {
            return record.data.Item.Code;
        }
        return "";
    },

    UomRenderer: function (value, metadata, record, rowIndex, colIndex, store) {

        if (Ext.isDefined(record.data.Uom) && record.data.Uom !== null && value > 0) {
            return record.data.Uom.Code;
        }
        return "";
    },

    LocationRenderer: function (value, metadata, record, rowIndex, colIndex, store) {

        if (Ext.isDefined(record.data.Location) && record.data.Location !== null && value > 0) {
            return record.data.Location.Code;
        }
        return "";
    },

    VatRenderer: function (value, metadata, record, rowIndex, colIndex, store) {
        if (Ext.isDefined(record.data.Vat) && record.data.Vat !== null && value > 0) {
            return record.data.Vat.Code;
        }
        return "";
    },

    InventoryAccountRender: function (value, metadata, record, rowIndex, colIndex, store) {
        if (Ext.isDefined(record.data.InventoryAccount) && record.data.InventoryAccount !== null && value > 0) {
            return record.data.InventoryAccount.Code;
        }
        return "";
    },

    JobRender: function (value, metadata, record, rowIndex, colIndex, store) {
        if (Ext.isDefined(record.data.Job) && record.data.Job !== null && value > 0) {
            return record.data.Job.Code;
        }
        return "";
    },

    PurchaseInvoiceLineBeforeEdit: function (editor, e) {
        e.grid.getSelectionModel().select(e.rowIdx, true);

        var field = this.getEditor(e.record, e.column).field;

        switch (e.field) {
            case "ItemId":
                field.store.id = e.record.data.ItemId;
                if (e.record.data.Item !== null) {
                    field.store.add(e.record.data.Item);
                }
                break;
            case "UomId":
                field.allQuery = e.record.get('ItemId');
                //field.store.id = e.record.data.UomId;
                if (e.record.data.Uom !== null) {
                    field.store.add(e.record.data.Uom);
                }
                break;
            case "LocationId":
                field.store.id = e.record.data.LocationId;
                if (e.record.data.Location !== null) {
                    field.store.add(e.record.data.Location);
                }
                break;
            case "VatId":
                field.store.id = e.record.data.VatId;
                if (e.record.data.Vat !== null) {
                    field.store.add(e.record.data.Vat);
                }
                break;
            case "InventoryAccountId":
                field.store.id = e.record.data.InventoryAccountId;
                if (e.record.data.InventoryAccount !== null) {
                    field.store.add(e.record.data.InventoryAccount);
                }
                break;
            case "JobId":
                field.store.id = e.record.data.JobId;
                if (e.record.data.Job !== null) {
                    field.store.add(e.record.data.Job);
                }
                break;
        }
    },

    CalcHeaderTotal: function (grid) {
        var sumAmount = 0;
        var sumAmountLCY = 0;

        grid.getStore().each(function (record) {
            var v = (record.get("Amount") + "").replace(/\./g, '').replace(',', '.');
            sumAmount += parseFloat(v);

            v = (record.get("AmountLCY") + "").replace(/\./g, '').replace(',', '.');
            sumAmountLCY += parseFloat(v);
        });

        var totalAmountId = "TotalAmount";
        var totalAmountLCYId = "TotalAmountLCY";

        Ext.getCmp(totalAmountId).setRawValue(Ext.util.Format.number(sumAmount, '0.000,00/i'));
        Ext.getCmp(totalAmountLCYId).setRawValue(Ext.util.Format.number(sumAmountLCY, '0.000,00/i'));
    }

};

var VatEntry = {

    BusinessPartnerRenderer: function (value, metadata, record, rowIndex, colIndex, store) {
        if (Ext.isDefined(record.data.BusinessPartner) && record.data.BusinessPartner !== null && value > 0) {
            return record.data.BusinessPartner.Code;
        }
        return "";
    },
    VatRenderer: function (value, metadata, record, rowIndex, colIndex, store) {
        if (Ext.isDefined(record.data.Vat) && record.data.Vat !== null && value > 0) {
            return record.data.Vat.Code;
        }
        return "";
    },
    AccountVatRenderer: function (value, metadata, record, rowIndex, colIndex, store) {
        if (Ext.isDefined(record.data.AccountVat) && record.data.AccountVat !== null && value > 0) {
            return record.data.AccountVat.Code;
        }
        return "";
    },
    BeforeEdit: function (editor, e) {
        e.grid.getSelectionModel().select(e.rowIdx, true);

        var field = this.getEditor(e.record, e.column).field;

        switch (e.field) {
            case "BusinessPartnerId":
                field.store.id = e.record.data.BusinessPartnerId;
                if (e.record.data.BusinessPartner !== null) {
                    field.store.add(e.record.BusinessPartner);
                }
                break;
            case "VatId":
                field.store.id = e.record.data.VatId;
                if (e.record.data.Vat !== null) {
                    field.store.add(e.record.data.Vat);
                }
                break;
            case "AccountVatId":
                field.store.id = e.record.data.AccountVatId;
                if (e.record.data.AccountVat !== null) {
                    field.store.add(e.record.data.AccountVat);
                }
                break;
            case "JobId":
                field.store.id = e.record.data.JobId;
                if (e.record.data.Job !== null) {
                    field.store.add(e.record.data.Job);
                }
                break;
        }
    },
    ValidateEdit: function (ed, e) {
        var editor = ed.getEditor(e.record, e.column),
            v = editor.getValue();

        switch (e.field) {
            case "InvoiceNumber":
            case "InvoiceSeries":
                editor.setValue((v || "").toUpperCase());
                break;
        }
    }
};


var EInvoice = {

    ItemRenderer: function (value, metadata, record, rowIndex, colIndex, store) {

        if (Ext.isDefined(record.data.Item) && record.data.Item !== null && value > 0) {
            return record.data.Item.Code;
        }
        return "";
    },

    UomRenderer: function (value, metadata, record, rowIndex, colIndex, store) {

        if (Ext.isDefined(record.data.Uom) && record.data.Uom !== null && value > 0) {
            return record.data.Uom.Code;
        }
        return "";
    },

    VatRenderer: function (value, metadata, record, rowIndex, colIndex, store) {
        if (Ext.isDefined(record.data.Vat) && record.data.Vat !== null && value > 0) {
            return record.data.Vat.Code;
        }
        return "";
    },

    InvoiceLineBeforeEdit: function (editor, e) {
        e.grid.getSelectionModel().select(e.rowIdx, true);

        var field = this.getEditor(e.record, e.column).field;

        switch (e.field) {
            case "ItemId":
                field.store.id = e.record.data.ItemId;
                if (e.record.data.Item !== null) {
                    field.store.add(e.record.data.Item);
                }
                break;
            case "UnitId":
                field.allQuery = e.record.get('ItemId');
                //field.store.id = e.record.data.UomId;
                if (e.record.data.Uom !== null) {
                    field.store.add(e.record.data.Uom);
                }
                break;
            case "VatId":
                field.store.id = e.record.data.VatId;
                if (e.record.data.Vat !== null) {
                    field.store.add(e.record.data.Vat);
                }
                break;
        }
    },

    CalcHeaderTotal: function (grid) {
        var sumItemTotalAmountWithoutVAT = 0;
        var sumVATAmount = 0;
        var sumItemTotalAmountWithVAT = 0;

        grid.getStore().each(function (record) {
            var v = (record.get("ItemTotalAmountWithoutVAT") + "").replace(/\./g, '').replace(',', '.');
            sumItemTotalAmountWithoutVAT += parseFloat(v);

            v = (record.get("VATAmount") + "").replace(/\./g, '').replace(',', '.');
            sumVATAmount += parseFloat(v);

            v = (record.get("ItemTotalAmountWithVAT") + "").replace(/\./g, '').replace(',', '.');
            sumItemTotalAmountWithVAT += parseFloat(v);
        });

        var totalTotalAmountWithoutVATId = "TotalAmountWithoutVAT";
        var totalTotalVATAmountId = "TotalVATAmount";
        var totalAmountWithVATId = "TotalAmountWithVAT";

        Ext.getCmp(totalTotalAmountWithoutVATId).setRawValue(Ext.util.Format.number(sumItemTotalAmountWithoutVAT, '0.000,00/i'));
        Ext.getCmp(totalTotalVATAmountId).setRawValue(Ext.util.Format.number(sumVATAmount, '0.000,00/i'));
        Ext.getCmp(totalAmountWithVATId).setRawValue(Ext.util.Format.number(sumItemTotalAmountWithVAT, '0.000,00/i'));
    }

};