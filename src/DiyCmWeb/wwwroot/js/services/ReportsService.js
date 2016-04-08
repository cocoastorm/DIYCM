(function () {

    var areas = null;

    var ReportsService = function ($http, $q) {


         var baseUrl = 'http://diycm-api.azurewebsites.net/api/';
        //var baseUrl = 'http://localhost:5000/api/';


        var _getAllDocuments = function () {
            return $http.get(baseUrl + "Documents")
              .then(function (response) {
                  return response.data;
              });
        };

        var _getAllQuoteHeaders = function () {
            return $http.get(baseUrl + "QuoteHeaders")
              .then(function (response) {
                  return response.data;
              });
        };

        //returns a JSON with project and summed up category budgets for the corresponding project -> charts?
        // | ProjectName | BudgetAmount | ActualAmount |
        var _getAllProjectsBudgetActual = function () {

            var reqProjects = $http.get(baseUrl + 'projects');
            var reqCategories = $http.get(baseUrl + 'categories');

            return $q.all([reqProjects, reqCategories]).then(function (values) {
                var projects = values[0].data;
                var categorybudgets = values[1].data;
                projects.forEach(function (project) {
                    var budgetSum = 0;
                    var actualSum = 0;
                    categorybudgets.forEach(function (budget) {
                        if (project.ProjectId == budget.ProjectId) {
                            budgetSum += budget.BudgetAmount;
                            actualSum += budget.ActualAmount;
                        }
                    });
                    project.BudgetAmount = budgetSum;
                    project.ActualAmount = actualSum;
                });
                return projects;
            });
        };

        //returns a JSON with all the information for categories details/summary
        //summary table
        // | ProjectName | CategoryName | BudgetAmount(cat) | ActualAmount(cat) | PercentCompleted |
        //details table
        // | ProjectName | CategoryName | BudgetAmount(cat) | ActualAmount(cat) | PercentCompleted | PartDesccription | PartUnitPrice | SupplierName |
        var _getCategoryDetailsAndSummary = function () {
            var reqCategories = $http.get(baseUrl + 'categories');
            var reqProjects = $http.get(baseUrl + 'projects');
            var reqQuoteDetails = $http.get(baseUrl + 'quotedetails');
            var regQuoteHeaders = $http.get(baseUrl + 'quoteheaders');

            return $q.all([reqCategories, reqProjects, reqQuoteDetails, regQuoteHeaders]).then(function (values) {
                var categories = values[0].data;
                var projects = values[1].data;
                var quotedetails = values[2].data;
                var quoteheaders = values[3].data;

                categories.forEach(function (category) {
                    category.ProjetName = '';
                    projects.forEach(function (project) {
                        if (project.ProjectId == category.ProjectId) {
                            category.ProjectId = project.ProjectId;
                            category.ProjectName = project.ProjectName;
                        }
                    });
                    quotedetails.forEach(function (detail) {
                        if (detail.CategoryId == category.CategoryId) {
                            category.QuoteHeaderId = detail.QuoteHeaderId;
                            category.PartId = detail.PartId;
                            category.PartUnitPrice = detail.UnitPrice;
                            category.PartDescription = detail.PartDescription;

                        }
                    });
                    quoteheaders.forEach(function (header) {
                        if (header.QuoteHeaderId = category.QuoteHeaderId) {
                            category.SupplierName = header.Supplier;
                        }
                    });
                });

                return categories;
            });
        };

        //returns a JSON with all the information for subcategories details/summmary
        //summary table
        // | ProjectName | CategoryName | SubCategoryName | BudgetAmount(subcat) | ActualAmount(subcat) | PercentCompleted |
        //details tablae
        // | ProjectName | CategoryName | SubCategoryName | PartDescription | PercentCompleted | PartUnitPrice | PercentDiscount | SupplierName |
        var _getSubCategoryDetailsAndSummary = function () {
            var reqSubCategories = $http.get(baseUrl + 'subcategories');
            var reqCategories = $http.get(baseUrl + 'categories');
            var reqProjects = $http.get(baseUrl + 'projects');
            var reqQuoteDetails = $http.get(baseUrl + 'quotedetails');
            var regQuoteHeaders = $http.get(baseUrl + 'quoteheaders');

            return $q.all([reqSubCategories, reqCategories, reqProjects, reqQuoteDetails, regQuoteHeaders]).then(function (values) {
                var subcategories = values[0].data;
                var categories = values[1].data;
                var projects = values[2].data;
                var quotedetails = values[3].data;
                var quoteheaders = values[4].data;

                subcategories.forEach(function (subcategory) {
                    categories.forEach(function (category) {
                        if (category.CategoryId == subcategory.CategoryId) {
                            subcategory.CategoryName = category.CategoryName;
                            subcategory.ProjectId = category.ProjectId;
                        }
                    });
                    projects.forEach(function (project) {
                        if (subcategory.ProjectId == project.ProjectId) {
                            subcategory.ProjectName = project.ProjectName;
                        }
                    });
                    quotedetails.forEach(function (detail) {
                        if (detail.SubCategoryId == subcategory.SubCategoryId) {
                            subcategory.QuoteHeaderId = detail.QuoteHeaderId;
                            subcategory.PartId = detail.PartId;
                            subcategory.PartUnitPrice = detail.UnitPrice;
                            subcategory.PartDescription = detail.PartDescription;
                        }
                    });
                    quoteheaders.forEach(function (header) {
                        if (subcategory.QuoteHeaderId == header.QuoteHeaderId) {
                            subcategory.SupplierName = header.Supplier;
                            subcategory.PercentDiscount = header.PercentDiscount;
                        }
                    });
                });

                return subcategories;
            });
        };

        //returns a JSON with all the information activities (week by week filter?)
        // | ProjectName | PartDescription | AreaRoom | StartDate | EndDate | SupplierName
        var _getActivities = function () {
            var regQuoteHeaders = $http.get(baseUrl + 'quoteheaders');
            var reqQuoteDetails = $http.get(baseUrl + 'quotedetails');
            var reqCategories = $http.get(baseUrl + 'categories');
            var reqProjects = $http.get(baseUrl + 'projects');
            var reqAreas = $http.get(baseUrl + 'areas');

            return $q.all([regQuoteHeaders, reqQuoteDetails, reqCategories, reqProjects, reqAreas]).then(function (values) {
                var quoteheaders = values[0].data;
                var quotedetails = values[1].data;
                var categories = values[2].data;
                var projects = values[3].data;
                var areas = values[4].data;

                quoteheaders.forEach(function (header) {
                    quotedetails.forEach(function (detail) {
                        if (detail.QuoteHeaderId == header.QuoteHeaderId) {
                            header.PartDescription = detail.PartDescription;
                            header.CategoryId = detail.CategoryId;
                            header.AreaId = detail.AreaId;
                        }
                    });
                    categories.forEach(function (category) {
                        if (category.CategoryId == header.CategoryId) {
                            header.ProjectId = category.ProjectId;
                        }
                    });
                    projects.forEach(function (project) {
                        if (project.ProjectId == header.ProjectId) {
                            header.ProjectName = project.ProjectName;
                        }
                    });
                    areas.forEach(function (area) {
                        if (area.AreaId == header.AreaId) {
                            header.AreaRoom = area.AreaRoom;
                        }
                    });
                })
                return quoteheaders;
            });
        };

        return {
            getAllDocuments: _getAllDocuments,
            getAllProjectsBudgetActual: _getAllProjectsBudgetActual,
            getCategoryDetailsAndSummary: _getCategoryDetailsAndSummary,
            getSubCategoryDetailsAndSummary: _getSubCategoryDetailsAndSummary,
            getActivities: _getActivities,
            getAllQuoteHeaders: _getAllQuoteHeaders
        };
    };
    var module = angular.module("diycm");
    module.factory("ReportsService", ['$http', '$q', ReportsService]);
}());
