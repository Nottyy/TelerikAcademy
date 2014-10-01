/*globals define*/
define(['requester'], function (requester) {
    'use strict';
    var DataPersister;
    DataPersister = (function () {
        function DataPersister(resourceURL) {
            this.resourceURL = resourceURL;
        }

        DataPersister.prototype.messages = function(){
            var self = this;
            return requester.getJSON(self.resourceURL);
        };

        return DataPersister;
    }());
    return DataPersister;
});
