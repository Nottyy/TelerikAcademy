/*globals define*/
define(['jquery', 'mustache'], function($, Mustache){
    'use strict';
    var UI;
    UI = (function(){
        function UI(selector){
            this.selector = selector;
        }

        UI.prototype.renderHome = function(){
            $(this.selector).load('templates/wellcome.html');
        };

        UI.prototype.renderLogin = function(){
            $(this.selector).load('templates/login.html');
        };

        UI.prototype.renderLoginDone = function(){
            $(this.selector).load('templates/loggedin.html');
        };

        UI.prototype.renderLogout = function(){
            $(this.selector).load('templates/logout.html');
        };

        UI.prototype.renderLogoutDone = function(){
            $(this.selector).load('templates/logoutdone.html');
        };

        UI.prototype.notLogged = function(){
            $(this.selector).load('templates/notlogged.html');
        };

        UI.prototype.renderChat = function(){
            $(this.selector).load('templates/chat.html');
        };

        UI.prototype.renderMessages = function(messages, chatContainer){
            var template = $('#messages-template').html();
            var $container = $('<ul>').attr('id', 'chat-messages');
            Mustache.parse(template);
            for (var i = 0; i < messages.length; i++) {
                var rendered = Mustache.render(template, messages[i]);
                $container.append(rendered);
            }
            $(chatContainer).html($container);
        };

        return UI;
    }());
    return UI;
});