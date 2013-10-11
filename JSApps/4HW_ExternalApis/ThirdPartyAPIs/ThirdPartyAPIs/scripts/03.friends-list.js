/// <reference path="jquery-1.10.1.js" />

window.fbAsyncInit = function () {
    FB.init({
        appId: '618080744870245',
        channelUrl: '//http://localhost:26003/channel.html',
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML
    });

    FB.login(function (response) {
        if (response.authResponse) {
            showFriendsList();
        } else {
            console.log("user not logged in");
        }
    }, { scope: 'read_friendlists' });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

function showFriendsList() {
    var holder = $("#container");
    holder.html("");
    FB.api('/me/friends', function (response) {

        holder.append("<h1>List of my friends</h1>");
        for (var i = 0; i < response.data.length; i++) {
            var name = response.data[i].name;
            var id = response.data[i].id;
            var url = "https://graph.facebook.com/" + id + "/picture";
            holder.append("<div><h2>" + name + "</h2><img src =" + url + " width = '50px' height= '50px'/></div>");
        }
    });

    $(holder).on("click", "div img", function () {
        var img = $(this);
        if (img.hasClass("clicked")) {
            img.removeClass("clicked");
        }
        else {
            img.addClass("clicked");
        }
    });

}
