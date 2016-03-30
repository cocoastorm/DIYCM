
(function () {

    var projects = null;
    var categories = null;
    var subcategories = null;
    var quotedetails = null;
    var quoteheaders = null;
    var areas = null;

    var ReportsService = function ($http) {

        //var baseUrl = 'http://diycm-api.azurewebsites.net/api/';
        var baseUrl = 'http://localhost:49983/api';

        var _getProject = function (id) {
            return $http.get(baseUrl + id)
             .then(function (response) {
                 return response.data;
             });
        };
        var _getAllProjects = function () {
            return $http.get(baseUrl)
              .then(function (response) {
                  return response.data;
              });
        };

        //returns a JSON with project and summed up category budgets for the corresponding project -> charts?
        // | ProjectName | BudgetAmount | ActualAmount |
        var _getAllProjectsBudgetActual = function () {
            return $http.get(baseUrl + 'projects').then(function (response) {
                projects = response.data;
                $http.get(baseUrl + 'categories').then(function (response) {
                    var categorybudgets = response.data;
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
                });
                console.log("budgetactual");
                return projects;
            });
        };

        //returns a JSON with all the information for categories details/summary
        //summary table
        // | ProjectName | CategoryName | BudgetAmount(cat) | ActualAmount(cat) | PercentCompleted |
        //details table
        // | ProjectName | CategoryName | BudgetAmount(cat) | ActualAmount(cat) | PercentCompleted | PartDesccription | PartUnitPrice | SupplierName |
        var _getCategoryDetailsAndSummary = function () {
            return $http.get(baseUrl + 'categories').then(function (response) {
                categories = response.data;
                $http.get(baseUrl + 'projects').then(function (response) {
                    projects = response.data;
                    $http.get(baseUrl + 'quotedetails').then(function (response) {
                        quotedetails = response.data;
                        $http.get(baseUrl + 'quoteheaders').then(function (response) {
                            quoteheaders = response.data;
                            categories.forEach(function (category) {
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
                        });

                    });
                });
                console.log("categories");
                return categories;
            });
        };

        //returns a JSON with all the information for subcategories details/summmary
        //summary table
        // | ProjectName | CategoryName | SubCategoryName | BudgetAmount(subcat) | ActualAmount(subcat) | PercentCompleted |
        //details tablae
        // | ProjectName | CategoryName | SubCategoryName | PartDescription | PercentCompleted | PartUnitPrice | PercentDiscount | SupplierName |
        var _getSubCategoryDetailsAndSummary = function () {
            return $http.get(baseUrl + 'subcategories').then(function (response) {
                subcategories = response.data;
                $http.get(baseUrl + 'categories').then(function (response) {
                    categories = response.data;
                    $http.get(baseUrl + 'projects').then(function (response) {
                        projects = response.data;
                        $http.get(baseUrl + 'quotedetails').then(function (response) {
                            quotedetails = response.data;
                            $http.get(baseUrl + 'quoteheaders').then(function (response) {
                                quoteheaders = response.data;
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
                                    })
                                    quoteheaders.forEach(function (header) {
                                        if (subcategory.QuoteHeaderId == header.QuoteHeaderId) {
                                            subcategory.SupplierName = header.Supplier;
                                            subcategory.PercentDiscount = header.PercentDiscount;
                                        }
                                    })
                                });
                            });
                        });
                    });
                });
                console.log("subcategories");
                return subcategories;
            });
        };

        //returns a JSON with all the information activities (week by week filter?)
        // | ProjectName | PartDescription | AreaRoom | StartDate | EndDate | SupplierName
        var _getActivities = function () {
            return $http.get(baseUrl + 'quoteheaders').then(function (response) {
                quoteheaders = response.data;
                $http.get(baseUrl + 'quotedetails').then(function (response) {
                    quotedetails = response.data;
                    $http.get(baseUrl + 'categories').then(function (response) {
                        categories = response.data;
                        $http.get(baseUrl + 'projects').then(function (response) {
                            projects = response.data;
                            $http.get(baseUrl + 'areas').then(function (response) {
                                areas = response.data;
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
                            });
                        });
                    });
                });
                console.log("activities");
                return quoteheaders;
            });
        };

        return {
            getProject: _getProject,
            getAllProjects: _getAllProjects,

            getAllProjectsBudgetActual: _getAllProjectsBudgetActual,
            getCategoryDetailsAndSummary: _getCategoryDetailsAndSummary,
            getSubCategoryDetailsAndSummary: _getSubCategoryDetailsAndSummary,
            getActivities: _getActivities
        };
    };
    var module = angular.module("diycm");
    module.factory("ReportsService", ReportsService);
}());