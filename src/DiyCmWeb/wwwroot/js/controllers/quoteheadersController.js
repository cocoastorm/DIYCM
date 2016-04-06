app.controller('quoteheadersController', ['$scope', '$http', 'ReportsService', function ($scope, $http, ReportsService) {

    $scope.message = 'Everyone come and look!';

    var onGetQuoteHeader = function (data) {
        $scope.allQuoteHeaders = data;
        console.log(data);
    };

    var onGetAllComplete = function (data) {
        //console.log(data);
    };
    var onGetAllError = function (reason) {
        console.log(reason);
    };

    ReportsService.getAllQuoteHeaders()
    .then(onGetQuoteHeader, onGetAllError);
}]);