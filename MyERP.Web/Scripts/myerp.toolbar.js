
$(function () {

    /* ========================================================================
     * MYERP Check all toolbar
     * ======================================================================== */
    // Grab a reference to the check all box:
    var checkAllBox = $("#btn-toolbar-check-all");
    var checkAll = false;

    // Attach the call to toggleChecked to the
    // click event of the global checkbox:
    checkAllBox.click(function () {
        checkAll = !checkAll;
        toggleChecked(checkAll);
    });

    function toggleChecked(status) {
        $("input[name='list-action']").each(function () {
            // Set the checked status of each to match the 
            // checked status of the check all checkbox:
            $(this).prop("checked", status);
        });
    }

    /* ========================================================================
     * MYERP Delete toolbar
     * ======================================================================== */
    var deleteIdArray = [];
    var deleteUrl = '';
    $("#btn-toolbar-delete").click(function() {
        deleteIdArray = [];

        var elements = $("input[name='list-action']:checkbox:checked");
        elements.each(function() {
            deleteIdArray.push($(this).val());
        });

        if (deleteIdArray.length == 0) return;

        deleteUrl = $(this).data('request-url');
        if (deleteUrl == '') return;

        $("#confirm-delete").modal('show');
    });

    $("#confirm-delete").on('show.bs.modal', function (e) {
        $(this).find('.danger').click(function () {
            deleteProcess();
        });
    });

    function deleteProcess() {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};
        headers['__RequestVerificationToken'] = token;

        if (deleteIdArray.length == 0) return;
        if (deleteUrl == '') return;

        var postData = { values: deleteIdArray };
        $.ajax({
            type: "POST",
            url: deleteUrl,
            headers: headers,
            data: postData,
            success: function(data) {
                $("#confirm-delete").modal('hide');
                window.location.reload();
            },
            error: function (xhr) {
                console.log("Error when delete");
                $("#confirm-delete").modal('hide');
            },
            dataType: "json",
            traditional: true
        });
    };
});