(function () {

    var areas = null;

    var QuotesService = function ($http, $q) {
        var quoteHeadersUrl = 'http://diycm-api.azurewebsites.net/api/QuoteHeaders/';
        var quoteDetailsUrl = 'http://diycm-api.azurewebsites.net/api/QuoteDetails/';
        // var baseUrl = 'http://localhost:49983/api/';

        var _getAllQuoteHeaders = function () {
            return $http.get(quoteHeadersUrl)
              .then(function (response) {
                  return response.data;
              });
        };

        var _getQuoteHeader = function (id) {
            return $http.get(quoteHeadersUrl + id)
             .then(function (response) {
                 return response.data;
             });
        };

        var _addQuoteHeader = function (data) {
          $.support.cors = true;
           return $http.post(quoteHeadersUrl, data)
             .then(function (response) {
                 return response.data;
             });
       };

       var _editQuoteHeader = function (data, id) {
         $.support.cors = true;
          return $http.put(quoteHeadersUrl + id, data)
            .then(function (response) {
                return response.data;
            });
      };

      var _deleteQuoteHeader = function (id) {
        $.support.cors = true;
        return $http.delete(quoteHeadersUrl + id)
          .then(function (response) {
            return response.data;
          });
      };

      var _getAllQuoteDetails = function () {
          return $http.get(quoteDetailsUrl)
            .then(function (response) {
                return response.data;
            });
      };

      var _getQuoteDetail = function (id) {
          return $http.get(quoteDetailsUrl + id)
           .then(function (response) {
               return response.data;
           });
      };

      var _addQuoteDetail = function (data) {
        $.support.cors = true;
         return $http.post(quoteDetailsUrl, data)
           .then(function (response) {
               return response.data;
           });
     };

     var _editQuoteDetail = function (data, id) {
       $.support.cors = true;
        return $http.put(quoteDetailsUrl + id, data)
          .then(function (response) {
              return response.data;
          });
    };

    var _deleteQuoteDetail = function (id) {
      $.support.cors = true;
      return $http.delete(quoteDetailsUrl + id)
        .then(function (response) {
          return response.data;
        });
    };

      return {
          getQuoteHeader: _getQuoteHeader,
          addQuoteHeader: _addQuoteHeader,
          editQuoteHeader: _editQuoteHeader,
          deleteQuoteHeader: _deleteQuoteHeader,
          getAllQuoteHeaders: _getAllQuoteHeaders,
          getQuoteDetail: _getQuoteDetail,
          addQuoteDetail: _addQuoteDetail,
          editQuoteDetail: _editQuoteDetail,
          deleteQuoteDetail: _deleteQuoteDetail,
          getAllQuoteDetails: _getAllQuoteDetails,
      };
    };
    var module = angular.module("diycm");
    module.factory("QuotesService", ['$http', '$q', QuotesService]);
}());
