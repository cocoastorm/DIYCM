(function () {

    var areas = null;

    var InvoicesService = function ($http, $q) {
        var invoiceHeadersUrl = 'http://diycm-api.azurewebsites.net/api/SupplierInvoiceHeaders/';
        var invoiceDetailsUrl = 'http://diycm-api.azurewebsites.net/api/SupplierInvoiceDetails/';
        // var baseUrl = 'http://localhost:49983/api/';

        var _getAllInvoiceHeaders = function () {
            return $http.get(invoiceHeadersUrl)
              .then(function (response) {
                  return response.data;
              });
        };

        var _getInvoiceHeader = function (id) {
            return $http.get(invoiceHeadersUrl + id)
             .then(function (response) {
                 return response.data;
             });
        };

        var _addInvoiceHeader = function (data) {
          $.support.cors = true;
           return $http.post(invoiceHeadersUrl, data)
             .then(function (response) {
                 return response.data;
             });
       };

       var _editInvoiceHeader = function (data, id) {
         $.support.cors = true;
          return $http.put(invoiceHeadersUrl + id, data)
            .then(function (response) {
                return response.data;
            });
      };

      var _deleteInvoiceHeader = function (id) {
        $.support.cors = true;
        return $http.delete(invoiceHeadersUrl + id)
          .then(function (response) {
            return response.data;
          });
      };

      var _getAllInvoiceDetails = function () {
          return $http.get(invoiceDetailsUrl)
            .then(function (response) {
                return response.data;
            });
      };

      var _getInvoiceDetail = function (id) {
          return $http.get(invoiceDetailsUrl + id)
           .then(function (response) {
               return response.data;
           });
      };

      var _addInvoiceDetail = function (data) {
        $.support.cors = true;
         return $http.post(invoiceDetailsUrl, data)
           .then(function (response) {
               return response.data;
           });
     };

     var _editInvoiceDetail = function (data, id) {
       $.support.cors = true;
        return $http.put(invoiceDetailsUrl + id, data)
          .then(function (response) {
              return response.data;
          });
    };

    var _deleteInvoiceDetail = function (id) {
      $.support.cors = true;
      return $http.delete(invoiceDetailsUrl + id)
        .then(function (response) {
          return response.data;
        });
    };

      return {
          getInvoiceHeader: _getInvoiceHeader,
          addInvoiceHeader: _addInvoiceHeader,
          editInvoiceHeader: _editInvoiceHeader,
          deleteInvoiceHeader: _deleteInvoiceHeader,
          getAllInvoiceHeaders: _getAllInvoiceHeaders,
          getInvoiceDetail: _getInvoiceDetail,
          addInvoiceDetail: _addInvoiceDetail,
          editInvoiceDetail: _editInvoiceDetail,
          deleteInvoiceDetail: _deleteInvoiceDetail,
          getAllInvoiceDetails: _getAllInvoiceDetails,
      };
    };
    var module = angular.module("diycm");
    module.factory("InvoicesService", ['$http', '$q', InvoicesService]);
}());
