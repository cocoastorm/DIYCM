app.controller('quoteheadersController', ['$scope', '$http', 'QuotesService', function ($scope, $http, QuotesService) {

    $scope.message = 'Everyone come and look!';

    var onGetQuoteHeader = function (data) {
        $scope.allQuoteHeaders = data;
        console.log(data);
    };
    var onAddProject = function (data) {
      $scope.newQuote = data;
      console.log(data);
    };





    var onGetAllComplete = function (data) {
        //console.log(data);
    };
    var onGetAllError = function (reason) {
        console.log(reason);
    };



    QuotesService.getAllQuoteHeaders()
    .then(onGetQuoteHeader, onGetAllError);
    QuotesService.getAllQuoteHeaders()
    .then(onGetQuoteHeader, onGetAllError);
}]);
