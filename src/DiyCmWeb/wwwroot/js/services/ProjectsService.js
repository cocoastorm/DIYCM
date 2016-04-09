(function() {
  var ProjectsService = function ($http, $q) {
    var baseUrl = 'http://diycm-api.azurewebsites.net/api/Projects/';
    var url = 'http://diycm-api.azurewebsites.net/api/';
    //var baseUrl = 'http://localhost:5000/api/Projects/';


    var _getProject = function (id) {
        return $http.get(baseUrl + id)
         .then(function (response) {
             return response.data;
         });
    };

    var _addProject = function (data) {
      $.support.cors = true;
       return $http.post(baseUrl, data)
         .then(function (response) {
             return response.data;
         });
   };

   var _editProject = function (data, id) {
     $.support.cors = true;
      return $http.put(baseUrl + id, data)
        .then(function (response) {
            return response.data;
        });
  };

  var _deleteProject = function (id) {
    $.support.cors = true;
    return $http.delete(baseUrl + id)
      .then(function (response) {
        return response.data;
      });
  };

    var _getAllProjects = function () {
        return $http.get(baseUrl)
          .then(function (response) {
              return response.data;
          });
    };

    var _ongetProjectCategories = function(id){
          var reqCategories = $http.get(url + 'categories');
          var reqSubCategories = $http.get(url + 'subcategories');
          var reqProjects = $http.get(url + 'projects/' + id);
          // Both Main Categories + Sub categories
          var allProjectCategories    = new Array();
          var allProjectSubCategories = new Array();
          var allCategories = new Array();

          return $q.all([reqCategories, reqProjects, reqSubCategories]).then(function (values) {
              var categories    = values[0].data;
              var project       = values[1].data;
              var subcategories = values[2].data;
              //Iterate through each category
              categories.forEach(function (category) {
                var allSubcategories = new Array();
                      //Find the corresponding categories for the project
                      if (id == category.ProjectId) {
                        var obj = {
                          CategoryId      : category.CategoryId,
                          CategoryName    : category.CategoryName,
                          Description     : category.Description,
                          BudgetAmount    : category.BudgetAmount,
                          ActualAmount    : category.ActualAmount,
                          PercentCompleted: category.PercentCompleted,
                          VarianceAmount  : category.VarianceAmount,
                          SubCategories   : allSubcategories
                        };
                        //Iterate through each subcategory
                        var subcat = new Array();   //Used to store all subcategories for a main Category
                        subcategories.forEach(function (subcategory) {
                          //Find all subcategories for the current category
                          if(category.CategoryId == subcategory.CategoryId){
                            var sub = {
                              SubCategoryId    : subcategory.SubCategoryId,
                              SubCategoryName  : subcategory.SubCategoryName,
                              Description      : subcategory.Description,
                              CategoryId       : subcategory.CategoryId,
                              CategoryName     : category.CategoryName,
                              //Category         : subcategory.,
                              BudgetAmount     : subcategory.BudgetAmount,
                              ActualAmount     : subcategory.ActualAmount,
                              VarianceAmount   : subcategory.VarianceAmount,
                              PercentCompleted : subcategory.PercentCompleted
                            }
                            //Add the subcategory to the current main category
                            subcat.push(sub);
                            obj.SubCategories.push(sub); //Optional
                          }
                        });

                        var SubCategoriesForArray  = {
                          CategoryName  : category.CategoryName,
                          SubCategories : subcat
                        };
                        //Add the category
                        allProjectCategories.push(obj);
                        if(subcat.length > 0)
                          allProjectSubCategories.push(SubCategoriesForArray);

                      }
              });
              allCategories.push(allProjectCategories);
              allCategories.push(allProjectSubCategories);
              return allCategories;
          });
    }

    return {
      getProject: _getProject,
      addProject: _addProject,
      editProject: _editProject,
      deleteProject: _deleteProject,
      getAllProjects: _getAllProjects,
      getProjectCategories: _ongetProjectCategories
    };
  };

  var module = angular.module("diycm");
  module.factory("ProjectsService", ['$http', '$q', ProjectsService]);
}());
