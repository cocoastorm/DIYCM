(function() {
  var CategoriesService = function ($http, $q) {
    var categoriesUrl = 'http://diycm-api.azurewebsites.net/api/Categories/';
    var subcategoriesUrl = 'http://diycm-api.azurewebsites.net/api/SubCategories/';

    // var baseUrl = 'http://localhost:5000/api/Projects/';

    var _getCategory = function (id) {
        return $http.get(categoriesUrl + id)
         .then(function (response) {
             return response.data;
         });
    };

    var _addCategory = function (data) {
      $.support.cors = true;
       return $http.post(categoriesUrl, data)
         .then(function (response) {
             return response.data;
         });
   };

   var _editCategory = function (data, id) {
     $.support.cors = true;
      return $http.put(categoriesUrl + id, data)
        .then(function (response) {
            return response.data;
        });
  };

  var _deleteCategory = function (id) {
    $.support.cors = true;
    return $http.delete(categoriesUrl + id)
      .then(function (response) {
        return response.data;
      });
  };

    var _getAllCategories = function () {
        return $http.get(categoriesUrl)
          .then(function (response) {
              return response.data;
          });
    };

    return {
      getCategory: _getCategory,
      addCategory: _addCategory,
      editCategory: _editCategory,
      getAllCategories: _getAllCategories
    };
  };

  var module = angular.module("diycm");
  module.factory("CategoriesService", ['$http', '$q', CategoriesService]);
}());
