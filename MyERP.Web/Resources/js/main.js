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

var showHtmlPreviewReport = function (renderName) {
    Ext.create("Ext.window.Window", {
        renderTo: Ext.net.ResourceMgr.getRenderTarget(),
        title: "Report Preview",
        width: 200,
        frame: true,
        items: [{
            loader:
            {
                renderer: 'frame',
                url: baseURL + 'Resources/PrintReports/EInvoices/' + renderName + "/" + renderName + ".html",
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

//Convert a number into words
var NumberToWords = function(_number) {
    var words_of_number = {
        "99": "chín mươi chín",
        "98": "chín mươi tám",
        "97": "chín mươi bảy",
        "96": "chín mươi sáu",
        "95": "chín mươi lăm",
        "94": "chín mươi tư",
        "93": "chín mươi ba",
        "92": "chín mươi hai",
        "91": "chín mươi mốt",
        "90": "chín mươi",
        "89": "tám mươi chín",
        "88": "tám mươi tám",
        "87": "tám mươi bảy",
        "86": "tám mươi sáu",
        "85": "tám mươi lăm",
        "84": "tám mươi tư",
        "83": "tám mươi ba",
        "82": "tám mươi hai",
        "81": "tám mươi mốt",
        "80": "tám mươi",
        "79": "bảy mươi chín",
        "78": "bảy mươi tám",
        "77": "bảy mươi bảy",
        "76": "bảy mươi sáu",
        "75": "bảy mươi lăm",
        "74": "bảy mươi tư",
        "73": "bảy mươi ba",
        "72": "bảy mươi hai",
        "71": "bảy mươi mốt",
        "70": "bảy mươi",
        "69": "sáu mươi chín",
        "68": "sáu mươi tám",
        "67": "sáu mươi bảy",
        "66": "sáu mươi sáu",
        "65": "sáu mươi lăm",
        "64": "sáu mươi tư",
        "63": "sáu mươi ba",
        "62": "sáu mươi hai",
        "61": "sáu mươi mốt",
        "60": "sáu mươi",
        "59": "năm mươi chín",
        "58": "năm mươi tám",
        "57": "năm mươi bảy",
        "56": "năm mươi sáu",
        "55": "năm mươi lăm",
        "54": "năm mươi tư",
        "53": "năm mươi ba",
        "52": "năm mươi hai",
        "51": "năm mươi mốt",
        "50": "năm mươi",
        "49": "bốn mươi chín",
        "48": "bốn mươi tám",
        "47": "bốn mươi bảy",
        "46": "bốn mươi sáu",
        "45": "bốn mươi lăm",
        "44": "bốn mươi tư",
        "43": "bốn mươi ba",
        "42": "bốn mươi hai",
        "41": "bốn mươi mốt",
        "40": "bốn mươi",
        "39": "ba mươi chín",
        "38": "ba mươi tám",
        "37": "ba mươi bảy",
        "36": "ba mươi sáu",
        "35": "ba mươi lăm",
        "34": "ba mươi tư",
        "33": "ba mươi ba",
        "32": "ba mươi hai",
        "31": "ba mươi mốt",
        "30": "ba mươi",
        "29": "hai mươi chín",
        "28": "hai mươi tám",
        "27": "hai mươi bảy",
        "26": "hai mươi sáu",
        "25": "hai mươi lăm",
        "24": "hai mươi tư",
        "23": "hai mươi ba",
        "22": "hai mươi hai",
        "21": "hai mươi mốt",
        "20": "hai mươi",
        "19": "mười chín",
        "18": "mười tám",
        "17": "mười bảy",
        "16": "mười sáu",
        "15": "mười lăm",
        "14": "mười bốn",
        "13": "mười ba",
        "12": "mười hai",
        "11": "mười một",
        "10": "mười",
        "09": "lẻ chín",
        "08": "lẻ tám",
        "07": "lẻ bảy",
        "06": "lẻ sáu",
        "05": "lẻ năm",
        "04": "lẻ tư",
        "03": "lẻ ba",
        "02": "lẻ hai",
        "01": "lẻ một",
        "00": "",
        "00_remove": "không trăm lẻ",
        "00_remove_4": "không trăm lẻ tư",
        "9": "chín",
        "8": "tám",
        "7": "bảy",
        "6": "sáu",
        "5": "năm",
        "4": "bốn",
        "3": "ba",
        "2": "hai",
        "1": "một",
        "0": "không",
        "000": " ",
        "100": "trăm",
        "1000": "ngàn",
        "1000000": "triệu",
        "1000000000": "tỷ",
        "minus": "Âm",
    };

    //Converts a number from 100-999 into words
    function GetHundreds(s) {
        if ( isNaN(parseInt(s, 10)) || parseInt(s, 10) === 0) {
            return words_of_number["000"];
        }
        var _return = words_of_number[s.substring(0, 1)] + ' ' + words_of_number["100"] + ' ';
        if (words_of_number[s.substring(1)].trim() !== '')
            return _return + words_of_number[s.substring(1)] + ' ';
        else
            return _return + words_of_number[s.substring(1)];
    };

    var _result = '';
    var Temp = '';
    var Billion = 1000000000;
    var Million = 1000000;
    var Thousand = 1000;
    var Hundred = 100;
    var MaxNumber = 1000000000000000;
    if (_number < 0) {
        _result = words_of_number["minus"];
    }
    _number = Math.abs(_number);

    if (_number > MaxNumber) {
        return "*****************";
    }
    var _removeLeftStr = words_of_number["00_remove"];
    var _removeLeftStr4 = words_of_number["00_remove_4"];
    var MyNumber = "" + _number;
    var Count = 1;
    var unitNames = [
        '',
        words_of_number["1000"],
        words_of_number["1000000"],
        words_of_number["1000000000"],
        words_of_number["1000"],
        words_of_number["1000000"]
    ];

    while (MyNumber !== '') {
        Temp = GetHundreds(('000' + MyNumber).substring(('000' + MyNumber).length - 3));
        if (Temp.trim() !== '')
            _result = Temp + unitNames[Count - 1] + ' ' + _result;
        else if (Count === 4)
            _result = unitNames[Count - 1] + ' ' + _result;

        if (MyNumber.length > 3)
            MyNumber = MyNumber.substring(0, MyNumber.length - 3);
        else
            MyNumber = '';
        Count++;
    }

    if (_result.substring(0, _removeLeftStr4.length) === _removeLeftStr4)
        _result = words_of_number["4"] + _result.substring(_removeLeftStr4.length); //khong tram le tu -> bon
    else if (_result.substring(0, _removeLeftStr.length) === _removeLeftStr)
        _result = _result.substring(_removeLeftStr.length); //khong tram le -> ''

    _result = _result.charAt(0).toUpperCase() + _result.substring(1);
    return _result.trim();
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
        if (Ext.getCmp("Status").getValue() !== "0") {
            return false;
        }

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
        var totalAmountWithVATInWordsId = "TotalAmountWithVATInWords";

        Ext.getCmp(totalTotalAmountWithoutVATId).setRawValue(Ext.util.Format.number(sumItemTotalAmountWithoutVAT, '0.000,00/i'));
        Ext.getCmp(totalTotalVATAmountId).setRawValue(Ext.util.Format.number(sumVATAmount, '0.000,00/i'));
        Ext.getCmp(totalAmountWithVATId).setRawValue(Ext.util.Format.number(sumItemTotalAmountWithVAT, '0.000,00/i'));
        Ext.getCmp(totalAmountWithVATInWordsId).setRawValue(NumberToWords(sumItemTotalAmountWithVAT) + " đồng chẵn");
    }

};