/// <reference path="c:\users\toshiba\documents\visual studio 2013\Projects\ConsumingRemoteData\01.ModulePerformingHttpRequestsByGivenURLAndHeaders\Scripts/jquery-2.1.1.js" />
/// <reference path="c:\users\toshiba\documents\visual studio 2013\Projects\ConsumingRemoteData\01.ModulePerformingHttpRequestsByGivenURLAndHeaders\Scripts/q.js" />

var HttpRequester = (function () {

    var promiseAjaxRequest = function (url, type, data) {
        var ajaxDeferred = Q.defer();

        if (data) {
            data = JSON.stringify(data);
        }
        
        $.ajax({
            url: url,
            type: type,
            data: data,
            contentType: "application/json",
            success: function (responseData) {
                ajaxDeferred.resolve(responseData);
            },
            error: function (errorData) {
                ajaxDeferred.reject(errorData);
            }
        });

        return ajaxDeferred.promise;
    }

    var promiseAjaxRequestGet = function (url) {
        return promiseAjaxRequest(url, "get");
    }

    var promiseAjaxRequestPost = function (url, data) {
        return promiseAjaxRequest(url, "post", data);
    }

    return {
        getJson: promiseAjaxRequestGet,

        postJson: promiseAjaxRequestPost
    }
}());