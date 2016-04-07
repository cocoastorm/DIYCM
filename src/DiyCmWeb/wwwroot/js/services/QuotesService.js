(function () {

    var areas = null;

    var QuotesService = function ($http, $q) {
        var baseUrl = 'http://diycm-api.azurewebsites.net/api/';
        // var baseUrl = 'http://localhost:49983/api/';

        var _getAllQuoteHeaders = function () {
            return $http.get(baseUrl + "QuoteHeaders")
              .then(function (response) {
                  return response.data;
              });
        };

        var _getQuote = function (id) {
            return $http.get(baseUrl + id)
             .then(function (response) {
                 return response.data;
             });
        };

        var _addQuote = function (data) {
          $.support.cors = true;
           return $http.post(baseUrl + "QuoteHeaders", data)
             .then(function (response) {
                 return response.data;
             });
       };

       var _editQuote = function (data, id) {
         $.support.cors = true;
          return $http.put(baseUrl + "QuoteHeaders/" + id, data)
            .then(function (response) {
                return response.data;
            });
      };

      var _deleteQuote = function (id) {
        $.support.cors = true;
        return $http.delete(baseUrl + "QuoteHeaders/" + id)
          .then(function (response) {
            return response.data;
          });
      };

      return {
          getQuote: _getQuote,
          addQuote: _addQuote,
          editQuote: _editQuote,
          deleteQuote: _deleteQuote,
          getAllQuoteHeaders: _getAllQuoteHeaders
      };
    };
    var module = angular.module("diycm");
    module.factory("QuotesService", ['$http', '$q', QuotesService]);
}());
