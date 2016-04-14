app.controller('areasController', ['$scope', '$http', 'AreasService', function ($scope, $http, AreasService) {
    var onError = function (reason) {
        console.log(reason);
    };
    var onAddArea = function (data){
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
        .then(onAddArea, onError);
    };

}]);
