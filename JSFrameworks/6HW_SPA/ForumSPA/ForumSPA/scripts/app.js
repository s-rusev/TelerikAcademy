$(function () {
    var persister = persisters.getPersister('9NfruOIIrwGudABQ');
    var postId = null;
    var app = Sammy("#wrapper", function () {
        var self = this;
        this.get("#/", function () {
            self.attachEvents('#wrapper');

            if (persister.user.isLoggedIn()) {
                $('#wrapper').load('../partial-views/login-form.html', function () {

                });
            } else {
                $('#wrapper').load('../partial-views/main-interface.html', function () {

                });
            }
        });

        this.get("#/login", function () {
            $('#wrapper').load('../partial-views/login-form.html', function () {

            });
        });

        this.get("#/register", function () {
            $('#wrapper').load('../partial-views/register-form.html', function () {

            });

        });

        this.get('#/forum', function () {
            if (persister.user.isLoggedIn()) {
                $('#wrapper').load('../partial-views/main-interface.html', function () {

                });
            } else {
                $('#wrapper').load('../partial-views/login.html', function () {

                });
            }
        });

        this.get('#/posts', function () {
            persister.post.getAll().then(function (data) {
                console.log(data);
                var postsWrapper = document.getElementById('posts-container');
                postsWrapper.innerHTML = "";
                for (var i = 0; i < data.count; i++) {
                    console.log(data.count);
                    var currentPostContainer = document.createElement('div');
                    currentPostContainer.classList.add('post');
                    currentPostContainer.classList.add('well');
                    currentPostContainer.classList.add('well-large');
                    currentPostContainer.setAttribute('data-id', data.result[i].Id);
                    //id
                    var id = document.createElement('p');
                    id.innerHTML = "Id: " + data.result[i].Id;
                    currentPostContainer.appendChild(id);
                    //title
                    var title = document.createElement('p');
                    title.innerHTML = "Title: " + data.result[i].Title;
                    currentPostContainer.appendChild(title);
                    //content
                    var content = document.createElement('p');
                    content.innerHTML = "Content: " + data.result[i].Content;
                    currentPostContainer.appendChild(content);
                    ////tags
                    if (data.result[i].Tags !== undefined) {
                        var tags = document.createElement('p');
                        var tagString = "";
                        for (var j = 0; j < data.result[i].Tags.length; j++) {
                            tagString += data.result[i].Tags[j].Name + " ";
                        }
                        tags.innerHTML = "Tags: " + tagString;
                        currentPostContainer.appendChild(tags);
                    }

                    postsWrapper.appendChild(currentPostContainer);
                }
            }, function (err) {
                console.log("postsError: ");
                console.log(err);
            });
        });

        this.get('#/singlePost/:id', function(id) {
            console.log(this.params['id']);
            persister.post.getPostById(this.params['id']).then(function (data) {
                console.log(data);
                var postsWrapper = document.getElementById('posts-container');
                $(postsWrapper).load('../partial-views/single-post.html', function () {
                    document.getElementById('postIdLabel').innerHTML = "<strong>Id: </strong>" + postId;
                    document.getElementById('postTitleLabel').innerHTML = "<strong>Title: </strong>" + data.result.Title;
                    document.getElementById('postContentLabel').innerHTML = "<strong>Id: </strong>" + data.result.Content;
                });
            });
        });

        this.attachEvents = function (container) {
            $(container).on('submit', '#login-form', function (ev) {
                ev.preventDefault();

                $('input', this).attr("disabled", "disabled");

                var user = {
                    Username: $(this).find('#username').val(),
                    Password: $(this).find('#password').val()
                };

                persister.user.login(user);
                window.location.href = "#/forum";
            });

            $(container).on('submit', '#register-form', function (ev) {
                ev.preventDefault();

                var user = {
                    Username: $(this).find('#username').val(),
                    DisplayName: $(this).find('#nickname').val(),
                    Password: $(this).find('#password').val()
                };

                persister.user.register(user, function (data) {
                    window.location.href = '#/login';
                }, function (err) {
                    console.log(err);
                });
            });

            $(container).on('click', '#createPostButton', function (ev) {
                ev.preventDefault();

                var tagsArray = [];
                var tagStrings = document.getElementById('postTags').value.split(',');
                for (var i = 0; i < tagStrings.length; i++) {
                    var tag = {
                        Name: tagStrings[i]
                    };
                    tagsArray.push(tag);
                }
                //TODO: add to database and than add tagArray

                var post = {
                    Title: document.getElementById('postTitle').value,
                    Content: document.getElementById('postContent').value,
                    Tags: tagsArray
                };

                persister.post.create(post).then(function (data) {
                    console.log(data);
                }, function (err) {
                    console.log(err);
                });
            });

            $(container).on('click', '#logout-button', function (ev) {
                ev.preventDefault();

                window.location.href = '#/login';
                var displayNameContainer = document.getElementById('displayName');
                displayNameContainer.innerHTML = "";
            });

            $(container).on('click', '.post', function(ev) {
                postId = $(this).data('id');
                window.location.href = '#/singlePost/' + postId;
            });

            $(container).on('click', '#leaveCommentButton', function() {
                console.log("You left a comment: " + document.getElementById('commentText').value);
            });
        };
    });

    app.run("#/");
});