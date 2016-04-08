(function () {

    var areas = null;

    var DocumentsService = function ($http, $q) {
        var documentsUrl = 'http://diycm-api.azurewebsites.net/api/Documents/';
        // var baseUrl = 'http://localhost:49983/api/';

        var _getAllDocuments = function () {
            return $http.get(documentsUrl)
              .then(function (response) {
                  return response.data;
              });
        };

        var _getDocument = function (id) {
            return $http.get(documentsUrl + id)
             .then(function (response) {
                 return response.data;
             });
        };

        var _addDocument = function (data) {
          $.support.cors = true;
           return $http.post(documentsUrl, data)
             .then(function (response) {
                 return response.data;
             });
       };

       var _editDocument = function (data, id) {
         $.support.cors = true;
          return $http.put(documentsUrl + id, data)
            .then(function (response) {
                return response.data;
            });
      };

      var _deleteDocument = function (id) {
        $.support.cors = true;
        return $http.delete(documentsUrl + id)
          .then(function (response) {
            return response.data;
          });
      };


      return {
          getDocument    : _getDocument,
          addDocument    : _addDocument,
          editDocument   : _editDocument,
          deleteDocument : _deleteDocument,
          getAllDocuments: _getAllDocuments
      };
    };
    var module = angular.module("diycm");
    module.factory("DocumentsService", ['$http', '$q', DocumentsService]);
}());
