app.controller('quoteheadersController', ['$scope', '$http', 'QuotesService', 'AreasService', function ($scope, $http, QuotesService, AreasService) {

    $scope.message = 'Everyone come and look!';
    var isAcceptValue;
    var quoteDetails;
    var quoteHeader;

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
        //if quote added was accepted
          if ($scope.quoteheader.IsAccept == true) {
              var supplierHeader = {
                  SupplierName     : $scope.quoteheader.Supplier,
                  QuoteHeaderId    : data.QuoteHeaderId,
                  Date             : $scope.quoteheader.Date,
                  ContactName      : $scope.quoteheader.ContactName,
                  PhoneNumber      : $scope.quoteheader.PhoneNumber,
                  ReferredBy       : $scope.quoteheader.ReferredBy,
                  AddressStreet    : $scope.quoteheader.AddressStreet,
                  AddressCity      : $scope.quoteheader.AddressCity,
                  AddressProvince  : $scope.quoteheader.AddressProvince,
                  AddressPostalCode: $scope.quoteheader.AddressPostalCode,
                  AddressCountry   : $scope.quoteheader.AddressCountry,
                  AmountPaid       : "N",
                  PaymentDate      : $scope.quoteheader.ExpiryDate,
                  SH_AMOUNT        : ($scope.quotedetails.UnitPrice * $scope.quotedetails.Quantity),
                  SH_AMOUNT_PAID   : 0.0
              };
              console.log("ADDING INVOICE");
              console.log(supplierHeader);
              QuotesService.addSupplierHeader(supplierHeader)
              .then(onSupplierInvoiceHeaderAddComplete, onError);
          } else {
              window.location.reload();
          }
    };

    var onError = function (reason) {
        console.log(reason);
    };
    var onSuccess = function (data){
      window.location.reload();
      console.log(data);
    };

    var onAddQuoteDetailsComplete = function(){
      window.location.reload();
    };

    //Adding a quotedetail to a quoteheader
    //Quote> +item
    $scope.addQuoteDetails = function () {
      var data = {
        QuoteHeaderId   : $scope.quotedetails.QuoteHeaderId,
        PartId          : $scope.quotedetails.PartId,
        PartDescription : $scope.quotedetails.PartDescription,
        UnitPrice       : $scope.quotedetails.UnitPrice,
        LineNumber      : 1,
        Quantity        : $scope.quotedetails.Quantity,
        AreaId          : $scope.areas.Choice,
        SubCategoryId   : $scope.quotedetails.SubCategoryId,
        CategoryId      : $scope.quotedetails.CategoryId,
        Notes           : $scope.quotedetails.Notes
      };
      console.log(data);
      QuotesService.addQuoteDetail(data)
        .then(onAddQuoteDetailsComplete, onError);
    };


    //Adding quote details
    //After creating a quoteheader add the quotedetail
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
        AreaId          : $scope.areas.Choice,
        //Area: ,
        UnitPrice       : $scope.quotedetails.UnitPrice,
        Quantity        : $scope.quotedetails.Quantity,
        Notes           : $scope.quotedetails.Notes
      }
      console.log(quoteDetails);
      QuotesService.addQuoteDetail(quoteDetails)
        .then(onComplete, onError);
    }

    //Adding quote header
    //Subcategories>add QuoteHeader
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


    $scope.deleteQuoteHeader = function (id) {
      var QuoteHeaderId = id;
      console.log(QuoteHeaderId);
      QuotesService.deleteQuoteHeader(QuoteHeaderId)
        .then(onSuccess, onError);
    };
    $scope.deleteQuoteDetails = function (id) {
      var QuoteDetailId = id;
      console.log(QuoteDetailId);
      QuotesService.deleteQuoteDetail(QuoteDetailId)
        .then(onSuccess, onError);
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

    //add invoice details
          var onSupplierInvoiceHeaderAddComplete = function (data) {

              var supplierDetails = {
                InvoiceId       : data.InvoiceId,
                PartNumber      : $scope.quotedetails.PartId,
                PartDescription : $scope.quotedetails.PartDescription,
                UnitPrice       : $scope.quotedetails.UnitPrice,
                LineNumber      : 1,
                Quantity        : $scope.quotedetails.Quantity,
                AreaId          : $scope.areas.Choice,
                SubCategoryId   : $scope.quotedetails.SubCategoryId,
                CategoryId      : $scope.quotedetails.CategoryId,
                Notes           : $scope.quotedetails.Notes
              };
              QuotesService.addSupplierDetail(supplierDetails)
                .then(onAddSupplierComplete, onError);
          }

          $scope.getAreas = function () {
              AreasService.getAllAreas()
                .then(onGetAreas, onError);
          }


        var onGetAreas = function (data) {
            $scope.areas = data;
            //console.log(data);
        };


        var onAddSupplierComplete = function (data) {
          console.log("ADDEDSUPPLIERHEADER");
          console.log(data);
          window.location.reload();
        }
}]);
