app.controller('categoriesController', ['$scope', '$http', '$routeParams', 'CategoriesService', function ($scope, $http, $routeParams, CategoriesService) {

    var ProjectId = $routeParams["id"];
    var baseUrl = 'http://diycm-api.azurewebsites.net/api/';

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





}]);
