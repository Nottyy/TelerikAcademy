/*globals require, alert, console*/
(function () {
    'use strict';
    require.config({
        paths: {
            jquery: 'libs/jquery-2.1.1',
            mustache: 'libs/mustache',
            q: 'libs/q',
            sammy: 'libs/sammy',
            requester: 'modules/requester',
            basePersister: 'persisters/basePersister',
            dataPersister: 'persisters/dataPersister',
            userPersister: 'persisters/userPersister',
            chatController: 'controllers/chatController',
            ui: 'ui/ui'
        }
    });

    require(['sammy', 'jquery', 'chatController'], function (Sammy, $, ChatController) {
        var resourceURL = 'http://crowd-chat.herokuapp.com/posts';
        var chatApp = new ChatController('#main-content', resourceURL);

        chatApp.addEvents();

        setInterval(function(){
            chatApp.getMessages();
        }, 1000);

        var app = Sammy('#main-content', function () {
            this.get('#/', function () {
                chatApp.loadHome();
            });
            this.get('#/login', function () {
                chatApp.loadLogin();
            });
            this.get('#/chat', function () {
                chatApp.loadChat();
            });
            this.get('#/logout', function () {
                chatApp.loadLogout();
            });
        });

        $(function () {
            app.run('#/');
        });
    });
}());
