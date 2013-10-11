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
            $("#container").html("");
            $("a").click(function () {
                FB.logout(function (response) {
                    $("#container").html("");
                    $("#container").append("<div>You are now logged out!</div>");
                });
            });
        } else {
            console.log("user not logged in");
        }
    }, { scope: 'read_friendlists,read_mailbox' });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

