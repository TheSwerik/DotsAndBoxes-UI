window.cookies = {
    CreateCookie: function (name, value, days) {
        let expires;
        if (days) {
            const date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            expires = "; expires=" + date.toGMTString();
        } else {
            expires = "";
        }
        document.cookie = name + "=" + value + expires + "; path=/";
    },
    ReadCookie: function () {
        return document.cookie;
    },
    DeleteCookie: function (name) {
        document.cookie = name + "= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
    },
}