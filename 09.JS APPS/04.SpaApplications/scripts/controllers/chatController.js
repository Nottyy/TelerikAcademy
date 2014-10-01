/*globals define, console*/
define(['basePersister', 'ui', 'jquery'], function (basePersister, UI, $) {
    'use strict';
    var ChatController;
    ChatController = (function () {
        function ChatController(selector, resourceURL) {
            this.selector = selector;
            this.resourceURL = resourceURL;
            this.persister = basePersister.get(resourceURL);
            this.ui = new UI(selector);
        }

        ChatController.prototype.loadHome = function () {
            this.ui.renderHome();
        };

        ChatController.prototype.loadLogin = function () {
            if (this.persister.isLoggedIn()) {
                this.ui.renderLoginDone();
            } else {
                this.ui.renderLogin();
            }
        };

        ChatController.prototype.loadLogout = function () {
            if (this.persister.isLoggedIn()) {
                this.persister.user.logout();
                this.ui.renderLogout();
            } else {
                this.ui.renderLogoutDone();
            }
        };

        ChatController.prototype.loadChat = function () {
            if (this.persister.isLoggedIn()) {
                this.ui.renderChat();

            } else {
                this.ui.notLogged();
            }
        };


        ChatController.prototype.addEvents = function () {
            var self = this;
            $(this.selector).on('click', '#login-btn', function () {
                var nickname = $('#input-name').val();
                self.persister.user.login(nickname);
                window.location = '#/chat';
            });

            $(this.selector).on('click', '#send', function () {
                var nickname = localStorage.getItem(self.persister.user.getLocalStorageNickKey());
                var message = $('#message').val();
                self.persister.user.postMessage({
                    user: nickname,
                    text: message
                })
                    .then(function () {
                        console.log('success posted');
                    }, function (err) {
                        console.log(err);
                    });
            });
        };

        ChatController.prototype.getMessages = function () {
            var self = this;
            self.persister.data.messages()
                .then(function (messages) {
                    var lastTwentyMessages = messages.slice(messages.length - 20);
                    self.ui.renderMessages(lastTwentyMessages, '#chat');
                }, function (err) {
                    console.log(err);
                });
        };


        return ChatController;
    }());
    return ChatController;
});