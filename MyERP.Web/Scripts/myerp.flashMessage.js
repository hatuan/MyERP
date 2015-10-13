/****** http://aboutcode.net/2010/11/30/display-a-flash-message-with-asp-net-mvc.html

public ActionResult ProcessForm() {
    ... process form ...
    Response.Cookies.Add(new HttpCookie("FlashMessage", "Data processed") { Path = "/" }));
    return RedirectToAction("Index");
}

$(function () { $("#flash-message").flashMessage(); });
********/
$.fn.flashMessage = function (options) {
    var target = this;
    options = $.extend({}, options, { timeout: 3000 });

    function getFlashMessageFromCookie() {
        return $.cookie("FlashMessage");
    }

    function deleteFlashMessageCookie() {
        $.cookie("FlashMessage", null, { path: '/' });
    }

    if (!options.message) {
        options.message = getFlashMessageFromCookie();
        deleteFlashMessageCookie();
    }

    if (options.message) {
        if (typeof options.message === "string") {
            target.html("<span>" + options.message + "</span>");
        } else {
            target.empty().append(options.message);
        }
    }

    if (target.children().length === 0) return;

    target.fadeIn().one("click", function () {
        $(this).fadeOut();
    });

    if (options.timeout > 0) {
        setTimeout(function () { target.fadeOut(); }, options.timeout);
    }

    return this;

};
