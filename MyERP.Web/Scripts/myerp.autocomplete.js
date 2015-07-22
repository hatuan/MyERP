
$(function () {

    /* ========================================================================
     * Currency Autocomplete
     * ======================================================================== */
    $("input[data-autocomplete='currency-code']").each(function(index, element) {
        var urlBase = $(element).attr("data-urlbase");
        var that = element;
        var elementId = document.getElementById($(element).attr("data-autocomplete-id"));

        var widgetInst = $(that).autocomplete({
            autoFocus: true,
            source: function(req, resp) {
                $.ajax({
                    url: urlBase + "/Currencies?$filter=startswith(Code,'" + req.term + "')&$select=Id,Code,Name&$orderby=Code",
                    success: function(result) {
                        resp($.map(result.value, function(item) {
                            return {
                                label: item.Code + " - " + item.Name,
                                value: item.Code,
                                id: item.Id
                            };
                        }));
                    }
                });
            },
            open: function () {
                // After menu has been opened, set width
                $('.ui-menu').width(250);
            },
            select: function(event, ui) {
                if (ui.item) {
                    $(that).val(ui.item.value);
                    $(elementId).val(ui.item.id);
                } else {
                    $(that).val("");
                    $(elementId).val("");
                }
            },
            change: function(event, ui) {
                if (ui.item) {
                    $(that).val(ui.item.value);
                    $(elementId).val(ui.item.id);
                } else {
                    var currentValue = $(that).val();

                    $.ajax({
                        url: urlBase + "/Currencies?$filter=Code eq '" + currentValue + "'&$select=Id,Code,Name&$orderby=Code",
                        success: function(result) {
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
        }).data("ui-autocomplete");

        widgetInst._renderMenu = function(ul, items) {
            var self = this;
            ul.append("<table class=\"table table-hover\"><thead><tr><th class=\"col-sm-1\">Code</th><th class=\"col-sm-2\">Name</th></tr></thead><tbody></tbody></table>");

            $.each(items, function(index, item) {
                self._renderItem(ul.find("table tbody"), item);
            });
        };
        widgetInst._renderItem = function (ul, item) {
            return $("<li></li>")
                .data("ui-autocomplete-item", item)
                .append("<a><table class='table table-condensed table-hover' style='margin-bottom:0px;'><tr><td class='col-sm-1'>" + item.value + "</td><td class='col-sm-2'>" + item.label + "</td></tr></table></a>")
                .appendTo(ul);

            //return $('<tr class="ui-menu-item" role="presentation"></tr>')
            //    .data("ui-autocomplete-item", item)
            //    .append("<td>" + item.value + "</td>" + "<td>" + item.label + "</td>")
            //    .appendTo(ul);
        };
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