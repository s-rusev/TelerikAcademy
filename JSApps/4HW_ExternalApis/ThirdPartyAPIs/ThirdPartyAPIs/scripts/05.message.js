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

function showFriendsList() {
    var holder = $("#container");
    holder.html("");
    FB.api('/me/friends', function (response) {

        holder.append("<h1>List of my friends. Click on the photo of one of them to send message using Facebook</h1>");
        for (var i = 0; i < response.data.length; i++) {
            var name = response.data[i].name;
            var id = response.data[i].id;
            var url = "https://graph.facebook.com/" + id + "/picture";
            var div = $("<div>");
            var img = $("<img src =" + url + " width = '50px' height= '50px'/>");
            img.data("id", id);
            div.append("<h2>" + name + "</h2>");
            div.append(img);
            holder.append(div);
        }
    });

    //using google to send the message because link is required :)
    $(holder).on("click", "div img", function () {
        var image = $(this);
        var friendId = image.data("id");
        FB.ui({
            method: 'send',
            to: friendId,
            link: 'https://google.bg/',
            message: 'Testing FB homework',

        });
    });

}
