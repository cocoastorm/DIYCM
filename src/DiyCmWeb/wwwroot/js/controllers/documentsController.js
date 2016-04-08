app.controller('documentsController', ['$scope', '$http', 'ReportsService', function ($scope, $http, DocumentsService) {

    $scope.message = 'Everyone come and look!';
    var onGetAllDocuments = function (data) {
        $scope.tableDocuments = data;
        console.log(data);
    }
    var onGetAllError = function (reason) {
        console.log(reason);
    };





    DocumentsService.getAllDocuments()
        .then(onGetAllDocuments, onGetAllError);
}]);
