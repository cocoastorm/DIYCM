(function() {
  var AreasService = function ($http, $q) {
    var baseUrl = 'http://diycm-api.azurewebsites.net/api/Areas/';

    // var baseUrl = 'http://localhost:5000/api/Projects/';

    var _getArea = function (id) {
        return $http.get(baseUrl + id)
         .then(function (response) {
             return response.data;
         });
    };

    var _addArea = function (data) {
      $.support.cors = true;
       return $http.post(baseUrl, data)
         .then(function (response) {
             return response.data;
         });
   };

   var _editArea = function (data, id) {
     $.support.cors = true;
      return $http.put(baseUrl + id, data)
        .then(function (response) {
            return response.data;
        });
  };

  var _deleteArea = function (id) {
    $.support.cors = true;
    return $http.delete(baseUrl + id)
      .then(function (response) {
        return response.data;
      });
  };

    var _getAllAreas = function () {
        return $http.get(baseUrl)
          .then(function (response) {
              return response.data;
          });
    };

    return {
      getArea: _getArea,
      addArea: _addArea,
      editArea: _editArea,
      getAllAreas: _getAllAreas
    };
  };

  var module = angular.module("diycm");
  module.factory("AreasService", ['$http', '$q', AreasService]);
}());
