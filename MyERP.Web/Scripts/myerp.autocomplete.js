
$(function () {

    /* ========================================================================
     * Currency Autocomplete
     * ======================================================================== */
    $("input[data-autocomplete='currency-code']").each(function (index, element) {
        var urlBase = $(element).attr('data-urlbase');
        var that = element;
        var elementId = document.getElementById($(element).attr('data-autocomplete-id'));

        $(that).autocomplete({
            autoFocus: true,
            source: function (req, resp) {
                $.ajax({
                    url: urlBase + "/Currencies?$filter=startswith(Code,'" + req.term + "')&$select=Id,Code,Name&$orderby=Code",
                    success: function (result) {
                        resp($.map(result.value, function (item) {
                            return {
                                label: item.Code + ' - ' + item.Name,
                                value: item.Code,
                                id: item.Id
                            };
                        }));
                    }
                });
            },
            select: function (event, ui) {
                if (ui.item) {
                    $(that).val(ui.item.value);
                    $(elementId).val(ui.item.id);
                } else {
                    $(that).val('');
                    $(elementId).val('');
                }
            },
            change: function (event, ui) {
                if (ui.item) {
                    $(that).val(ui.item.value);
                    $(elementId).val(ui.item.id);
                } else {
                    var currentValue = $(that).val();

                    $.ajax({
                        url: urlBase + "/Currencies?$filter=Code eq '" + currentValue + "'&$select=Id,Code,Name&$orderby=Code",
                        success: function (result) {
                            if (result.value.length == 0) {
                                $(that).val('');
                                $(elementId).val('');
                            } else {
                                $(that).val(result.value[0].Code);
                                $(elementId).val(result.value[0].Id);
                            }
                        }
                    });
                }
            }
        });
    });

    /* ========================================================================
     * Account Autocomplete
     * ======================================================================== */
    $("input[data-autocomplete='account-code']").each(function (index, element) {
        var urlBase = $(element).attr("data-urlbase");
        var that = element;
        var elementId = document.getElementById($(element).attr("data-autocomplete-id"));

        $(that).autocomplete({
            autoFocus: true,
            source: function (req, resp) {
                $.ajax({
                    url: urlBase + "/Accounts?$filter=startswith(Code,'" + req.term + "')&$select=Id,Code,Name&$orderby=Code",
                    success: function (result) {
                        resp($.map(result.value, function (item) {
                            return {
                                label: item.Code + " - " + item.Name,
                                value: item.Code,
                                id: item.Id
                            };
                        }));
                    }
                });
            },
            select: function (event, ui) {
                if (ui.item) {
                    $(that).val(ui.item.value);
                    $(elementId).val(ui.item.id);
                } else {
                    $(that).val("");
                    $(elementId).val("");
                }
            },
            change: function (event, ui) {
                if (ui.item) {
                    $(that).val(ui.item.value);
                    $(elementId).val(ui.item.id);
                } else {
                    var currentValue = $(that).val();

                    $.ajax({
                        url: urlBase + "/Accounts?$filter=Code eq '" + currentValue + "'&$select=Id,Code,Name&$orderby=Code",
                        success: function (result) {
                            if (result.value.length == 0) {
                                $(that).val("");
                                $(elementId).val("");
                            } else {
                                $(that).val(result.value[0].Code);
                                $(elementId).val(result.value[0].Id);
                            }
                        }
                    });
                }
            }
        });
    });

});