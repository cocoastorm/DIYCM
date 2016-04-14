app.controller('areasController', ['$scope', '$http', 'AreasService', function ($scope, $http, AreasService) {
  $scope.editorEnabled = false;
    var onError = function (reason) {
        console.log(reason);
    };
    var onSuccess = function (data){
      window.location.reload();
      console.log(data);
    };

    $scope.addArea = function () {
      var data = {
        AreaRoom          : $scope.area.AreaRoom,
        AreaSquareFootage : $scope.area.AreaSquareFootage
      };
      console.log(data);
      AreasService.addArea(data)
        .then(onSuccess, onError);
    };

    $scope.deleteArea = function (id) {
      var AreaId = id;
      console.log(AreaId);
      AreasService.deleteArea(AreaId)
        .then(onSuccess, onError);
    }
    var onEditArea = function (data) {
      $scope.disableEditor();
    };

    $scope.editArea = function () {
      var data = {
        AreaId : $scope.a.AreaId,
        AreaRoom: $scope.a.AreaRoom,
        AreaSquareFootage: $scope.a.AreaSquareFootage
      };
      console.log(data);
      AreasService.editArea(data, data.AreaId)
        .then(onEditArea, onError);
    };
    $scope.enableEditor = function(id) {
      $scope.editorEnabled = id;
    };
    $scope.disableEditor = function() {
      $scope.editorEnabled = false;
    };

}]);
