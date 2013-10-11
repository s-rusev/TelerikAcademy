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
            showBirthdayAndLocation();
        } else {
            console.log("user not logged in");
        }
    }, { scope: 'user_birthday, user_location' });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

function showBirthdayAndLocation() {
    var holder = $("#container");
    holder.html("");
    FB.api('/me', function (response) {
        var birthday = response.birthday;
        var location = response.location.name;
        holder.append("<div>My Birthday: " + birthday + "</div>");
        holder.append("<div>My Location: " + location + "</div>");
    });
}
