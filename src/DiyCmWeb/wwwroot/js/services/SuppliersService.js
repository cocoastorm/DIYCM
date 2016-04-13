(function () {

    var areas = null;

    var SuppliersService = function ($http, $q) {
        var supplierHeadersUrl = 'http://diycm-api.azurewebsites.net/api/SupplierInvoiceHeaders/';
        var supplierDetailsUrl = 'http://diycm-api.azurewebsites.net/api/SupplierInvoiceDetails/';
        // var baseUrl = 'http://localhost:49983/api/';

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
    module.factory("SuppliersService", ['$http', '$q', SuppliersService]);
}());
