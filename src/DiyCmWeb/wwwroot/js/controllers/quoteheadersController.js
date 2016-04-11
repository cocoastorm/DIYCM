app.controller('quoteheadersController', ['$scope', '$http', 'QuotesService', function ($scope, $http, QuotesService) {

    $scope.message = 'Everyone come and look!';

    var onGetQuoteHeader = function (data) {
        $scope.allQuoteHeaders = data;
        //console.log(data);
    };
    var onAddProject = function (data) {
      $scope.newQuote = data;
      console.log(data);
    };

    var onComplete = function (data) {
      console.log("ONADDEDQUOTEDETAIL");
        console.log(data);
        window.location.reload();
    };
    var onError = function (reason) {
        console.log(reason);
    };

    var onAddQuoteHeaderComplete = function (data){
      console.log(data);
      var quoteDetails = {
        QuoteHeaderId   : data.QuoteHeaderId,
        //QuoteHeader : ,
        LineNumber      : 1,
        PartId          : $scope.quotedetails.PartId,
        PartDescription : $scope.quotedetails.PartDescription,
        CategoryId      : $scope.quotedetails.CategoryId,
        //Category: ,
        SubCategoryId   : $scope.quotedetails.SubCategoryId,
        //SubCategory: ,
        AreaId          : 2,
        //Area: ,
        UnitPrice       : $scope.quotedetails.UnitPrice,
        Quantity        : $scope.quotedetails.Quantity,
        Notes           : $scope.quotedetails.Notes
      }
      console.log(quoteDetails);
      QuotesService.addQuoteDetail(quoteDetails)
        .then(onComplete, onError);
    }

    $scope.addQuoteHeader = function () {
      var isAcceptValue;
      if($scope.quoteheader.IsAccept == true){
        isAcceptValue = "Y";
      } else {
        isAcceptValue = "N";
      }
      var data = {
        Supplier          : $scope.quoteheader.Supplier,
        Date              : $scope.quoteheader.Date,
        StartDate         : $scope.quoteheader.StartDate,
        ExpiryDate        : $scope.quoteheader.ExpiryDate,
        ReferredBy        : $scope.quoteheader.ReferredBy,
        AddressStreet     : $scope.quoteheader.AddressStreet,
        AddressCity       : $scope.quoteheader.AddressCity,
        AddressProvince   : $scope.quoteheader.AddressProvince,
        AddressPostalCode : $scope.quoteheader.AddressPostalCode,
        AddressCountry    : $scope.quoteheader.AddressCountry,
        PercentDiscount   : $scope.quoteheader.PercentDiscount,
        notes             : $scope.quoteheader.notes,
        IsAccept          : isAcceptValue,
        ContactName       : $scope.quoteheader.ContactName,
        PhoneNumber       : $scope.quoteheader.PhoneNumber
      };
      console.log(data);
      QuotesService.addQuoteHeader(data)
        .then(onAddQuoteHeaderComplete, onError);
    };

    QuotesService.getAllQuoteHeaders()
    .then(onGetQuoteHeader, onError);

          // DatePicker Below
          $scope.today = function() {
            $scope.dt = new Date();
          };
          $scope.today();

          $scope.clear = function() {
            $scope.dt = null;
          };

          $scope.inlineOptions = {
            customClass: getDayClass,
            minDate: new Date(),
            showWeeks: true
          };

          $scope.dateOptions = {
            // dateDisabled: disabled,
            formatYear: 'yy',
            maxDate: new Date(2020, 5, 22),
            minDate: new Date(),
            startingDay: 1
          };

          // Disable weekend selection
          function disabled(data) {
            var date = data.date,
              mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
          }

          $scope.toggleMin = function() {
            $scope.inlineOptions.minDate = $scope.inlineOptions.minDate ? null : new Date();
            $scope.dateOptions.minDate = $scope.inlineOptions.minDate;
          };

          $scope.toggleMin();

          $scope.open1 = function() {
            $scope.popup1.opened = true;
          };

          $scope.open2 = function() {
            $scope.popup2.opened = true;
          };

          $scope.open3 = function() {
            $scope.popup3.opened = true;
          };

          $scope.setDate = function(year, month, day) {
            $scope.dt = new Date(year, month, day);
          };

          $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
          $scope.format = $scope.formats[0];
          $scope.altInputFormats = ['M!/d!/yyyy'];

          $scope.popup1 = {
            opened: false
          };

          $scope.popup2 = {
            opened: false
          };

          $scope.popup3 = {
            opened: false
          };

          var tomorrow = new Date();
          tomorrow.setDate(tomorrow.getDate() + 1);
          var afterTomorrow = new Date();
          afterTomorrow.setDate(tomorrow.getDate() + 1);
          $scope.events = [
            {
              date: tomorrow,
              status: 'full'
            },
            {
              date: afterTomorrow,
              status: 'partially'
            }
          ];

          function getDayClass(data) {
            var date = data.date,
              mode = data.mode;
            if (mode === 'day') {
              var dayToCheck = new Date(date).setHours(0,0,0,0);

              for (var i = 0; i < $scope.events.length; i++) {
                var currentDay = new Date($scope.events[i].date).setHours(0,0,0,0);

                if (dayToCheck === currentDay) {
                  return $scope.events[i].status;
                }
              }
            }

            return '';
          }
}]);
