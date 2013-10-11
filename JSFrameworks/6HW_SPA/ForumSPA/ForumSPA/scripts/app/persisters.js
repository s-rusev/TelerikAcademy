/// <reference path="http-requester.js" />
/// <reference path="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js" />

var persisters = (function () {
    var el = null;
    localStorage.setItem('token', null);

    var BasePersister = Class.create({
        init: function (apiKey) {
            el = new Everlive(apiKey);
            el.setup.token = localStorage.getItem('token');
            this.user = new UserPersister();
            this.post = new PostPersister();
        },
        getToken: function () {
            return localStorage.getItem('token');
        }
    });

    var UserPersister = Class.create({
        init: function () {
        },
        isLoggedIn: function () {
            return (localStorage.getItem('token') != null);
        },
        register: function (data) {
            Everlive.$.Users.register(
                data.Username,
                data.Password,
                data
            );
        },
        login: function (user) {
            var username = user.Username;
            var password = user.Password;
            el.Users.login(username, password)
                .then(function (data) {
                    //console.log(data);
                    var accessToken = data.result.access_token;
                    el.setup.token = accessToken;
                    localStorage.setItem('token', accessToken);
                    var displayNameContainer = document.getElementById('displayName');
                    displayNameContainer.innerHTML = username;
                }, function(error) {
                    console.log(error);
                });
        },
        logout: function () {
            el.Users.logout();
            localStorage.setItem('token', null);
        }
    });

    var PostPersister = Class.create({
        init: function () {
            this.posts = Everlive.$.data('Post');
        },
        getAll: function () {
            return this.posts.get();
        },
        getPostById: function(id) {
            return this.posts.getById(id);
        },
        create: function(post) {
            var data = Everlive.$.data('Post');
            return data.create(post);
        }
    });

    return {
        getPersister: function (apiKey) {
            return new BasePersister(apiKey);
        }
    };
}());

