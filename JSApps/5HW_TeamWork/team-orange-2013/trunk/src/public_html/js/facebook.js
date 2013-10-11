window.fbAsyncInit = function() {
    FB.init({appId: '581310678558079', status: true, cookie: true, xfbml: true});
};
(function() {
    var e = document.createElement('script'); 
    e.async = true;
    e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js';
    document.getElementById('fb-root').appendChild(e);
}());

$(document).ready(function(){
    $('#share_button').click(function(e){
        e.preventDefault();
        FB.ui(
        {
            method: 'feed',
            name: 'SpaceBoom',
            link: 'http://www.google.com/',
            picture: 'https://lh3.googleusercontent.com/-ig9gbXi0GgI/AAAAAAAAAAI/AAAAAAAAAAA/mBNpT90iIgs/photo.jpg',
            caption: 'by Team Orange',
            description: 'This is the coolest game ever!.',
            message: 'Can you finish level 5?'
        });
    });
});