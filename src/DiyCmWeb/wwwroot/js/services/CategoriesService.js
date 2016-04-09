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

    var _getSubCategory = function (id) {
        return $http.get(subcategoriesUrl + id)
         .then(function (response) {
             return response.data;
         });
    };

    var _addSubCategory = function (data) {
      $.support.cors = true;
       return $http.post(subcategoriesUrl, data)
         .then(function (response) {
             return response.data;
         });
   };

   var _editSubCategory = function (data, id) {
     $.support.cors = true;
      return $http.put(subcategoriesUrl + id, data)
        .then(function (response) {
            return response.data;
        });
  };

  var _deleteSubCategory = function (id) {
    $.support.cors = true;
    return $http.delete(subcategoriesUrl + id)
      .then(function (response) {
        return response.data;
      });
  };

    var _getSubAllCategories = function () {
        return $http.get(subcategoriesUrl)
          .then(function (response) {
              return response.data;
          });
    };

    var _getAllCategoriesByProjectId = function(id) {
      $http.get(categoriesUrl).then(function(cats) {
        var categories = cats.data;
        var projectCategories = [];

        categories.forEach(function(category) {
          if(category.ProjectId == id) {
            projectCategories.push(category);
          }
        });

        return projectCategories;
      });
    };

    return {
      getCategory: _getCategory,
      addCategory: _addCategory,
      editCategory: _editCategory,
      getAllCategories: _getAllCategories,
      getSubCategory: _getSubCategory,
      addSubCategory: _addSubCategory,
      editSubCategory: _editSubCategory,
      getSubAllCategories: _getSubAllCategories,
      getAllCategoriesByProjectId: _getAllCategoriesByProjectId
    };
  };

  var module = angular.module("diycm");
  module.factory("CategoriesService", ['$http', '$q', CategoriesService]);
}());
