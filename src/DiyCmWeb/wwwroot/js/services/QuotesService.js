(function () {

    var areas = null;

    var QuotesService = function ($http, $q) {
        var quoteHeadersUrl = 'http://diycm-api.azurewebsites.net/api/QuoteHeaders/';
        var quoteDetailsUrl = 'http://diycm-api.azurewebsites.net/api/QuoteDetails/';
        var supplierHeadersUrl = 'http://diycm-api.azurewebsites.net/api/SupplierInvoiceHeaders/';
        var supplierDetailsUrl = 'http://diycm-api.azurewebsites.net/api/SupplierInvoiceDetails/';

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


    var _getAllSupplierHeaders = function () {
        return $http.get(supplierHeadersUrl)
          .then(function (response) {
              return response.data;
          });
    };

    var _getSupplierHeader = function (id) {
        return $http.get(supplierHeadersUrl + id)
         .then(function (response) {
             return response.data;
         });
    };

    var _addSupplierHeader = function (data) {
        $.support.cors = true;
        return $http.post(supplierHeadersUrl, data)
          .then(function (response) {
              return response.data;
          });
    };

    var _editSupplierHeader = function (data, id) {
        $.support.cors = true;
        return $http.put(supplierHeadersUrl + id, data)
          .then(function (response) {
              return response.data;
          });
    };

    var _deleteSupplierHeader = function (id) {
        $.support.cors = true;
        return $http.delete(supplierHeadersUrl + id)
          .then(function (response) {
              return response.data;
          });
    };

    var _getAllSupplierDetails = function () {
        return $http.get(supplierDetailsUrl)
          .then(function (response) {
              return response.data;
          });
    };

    var _getSupplierDetail = function (id) {
        return $http.get(supplierDetailsUrl + id)
         .then(function (response) {
             return response.data;
         });
    };

    var _addSupplierDetail = function (data) {
        $.support.cors = true;
        return $http.post(supplierDetailsUrl, data)
          .then(function (response) {
              return response.data;
          });
    };

    var _editSupplierDetail = function (data, id) {
        $.support.cors = true;
        return $http.put(supplierDetailsUrl + id, data)
          .then(function (response) {
              return response.data;
          });
    };

    var _deleteSupplierDetail = function (id) {
        $.support.cors = true;
        return $http.delete(supplierDetailsUrl + id)
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
          getSupplierHeader: _getSupplierHeader,
          addSupplierHeader: _addSupplierHeader,
          editSupplierHeader: _editSupplierHeader,
          deleteSupplierHeader: _deleteSupplierHeader,
          getAllSupplierHeaders: _getAllSupplierHeaders,
          getSupplierDetail: _getSupplierDetail,
          addSupplierDetail: _addSupplierDetail,
          editSupplierDetail: _editSupplierDetail,
          deleteSupplierDetail: _deleteSupplierDetail,
          getAllSupplierDetails: _getAllSupplierDetails,
      };
    };
    var module = angular.module("diycm");
    module.factory("QuotesService", ['$http', '$q', QuotesService]);
}());
