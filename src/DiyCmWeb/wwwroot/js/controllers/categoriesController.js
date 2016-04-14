app.controller('categoriesController', ['$scope', '$http', '$routeParams', 'CategoriesService', function ($scope, $http, $routeParams, CategoriesService) {

    var ProjectId = $routeParams["id"];
    var baseUrl = 'http://diycm-api.azurewebsites.net/api/';

    var onError = function (reason) {
        console.log(reason);
    };
    var onSuccess = function (data){
      window.location.reload();
      console.log(data);
    };

    var onAddCategory = function (data) {
      window.location.reload();
      console.log(data);
    };
    var onCategoryError = function(reason) {
        console.error(reason);
    };

    $scope.addCategory = function () {
      var data = {
        ProjectId: ProjectId,
        //ProjectEntity: null,
        CategoryName: $scope.category.Name,
        Description: $scope.category.Description,
        BudgetAmount: $scope.category.BudgetAmount,
        ActualAmount: $scope.category.ActualAmount,
        PercentCompleted: $scope.category.PercentCompleted,
        VarianceAmount: $scope.category.VarianceAmount
      };
      console.log(data);
      CategoriesService.addCategory(data)
        .then(onAddCategory, onCategoryError);
    };

    $scope.deleteCategory = function (id) {
      var CategoryId = id;
      console.log(CategoryId);
      CategoriesService.deleteCategory(CategoryId)
        .then(onSuccess, onError);
    };
    $scope.deleteSubCategory = function (id) {
      var SubCategoryId = id;
      console.log(SubCategoryId);
      CategoriesService.deleteSubCategory(SubCategoryId)
        .then(onSuccess, onError);
    };



    $scope.addSubCategory = function () {
      var data = {
        SubCategoryName: $scope.subcategory.Name,
        Description: $scope.subcategory.Description,
        CategoryId: $scope.subcategory.CategoryId,
        BudgetAmount: $scope.subcategory.BudgetAmount,
        ActualAmount: $scope.subcategory.ActualAmount,
        PercentCompleted: $scope.subcategory.PercentCompleted,
        VarianceAmount: $scope.subcategory.VarianceAmount
      };
      console.log(data);
      CategoriesService.addSubCategory(data)
        .then(onAddCategory, onCategoryError);
    };



}]);
