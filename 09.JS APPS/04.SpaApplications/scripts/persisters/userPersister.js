/*globals define*/
define(['requester'], function(requester){
    var UserPersister;
    UserPersister = (function(){
        var LOCAL_STORAGE_NICK_KEY = 'nickname';
        function UserPersister(resourceURL){
            this.resourceURL = resourceURL;
        }

        UserPersister.prototype.getLocalStorageNickKey = function(){
            return LOCAL_STORAGE_NICK_KEY;
        };

        UserPersister.prototype.login = function(username){
            localStorage.setItem('nickname', username);
        };

        UserPersister.prototype.logout = function(){
            localStorage.setItem(LOCAL_STORAGE_NICK_KEY, '');
        };

        UserPersister.prototype.postMessage = function(message){
            return requester.postJSON(this.resourceURL, message);
        };
        return UserPersister;
    }());
    return UserPersister;
});
