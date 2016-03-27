
(function () {
    var projects = null;
    var ProjectsService = function ($http) {
        var baseUrl = 'http://localhost:49983/api/';
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

        //returns project with summed budget and actual from categories api
        //table
        //projects.ProjectName | projects.BudgetAmount | projects.ActualAmount
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
                return projects;
            });
        };

        //detailsbycategory
        //table
        //categories.ProjectName | categories.CategoryName | categories.PartDescription | categories.PartUnitPrice | categories.SupplierName
        var _getAllProjectsDetailsCategory = function () {
            return $http.get(baseUrl + 'categories').then(function (response) {
                var categories = response.data;
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
                                        category.PartId = detail.PartId;
                                        category.PartDescription = detail.PartDescription;
                                        category.QuoteHeaderId = detail.QuoteHeaderId;
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
                return categories;
            });
        };

        //detailsbysubcategory
        //table
        //subcategories.ProjectName | subcategories.SubcategoryName | subcategories.CategoryName | subcategories.SubcategoryBudget/Actual | subcategories.PartDescription 
        var _getAllProjectsDetailsSubCategory = function () {
            return $http.get(baseUrl + 'subcategories').then(function (response) {
                var subcategories = response.data;
                $http.get(baseUrl + 'categories').then(function (response) {
                    var categories = response.data;
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
                                        }
                                    })
                                });
                            });
                        });
                    });
                });
                return subcategories;
            });
        };

        return {
            getProject: _getProject,
            getAllProjectsBudgetActual: _getAllProjectsBudgetActual,
            getAllProjectsDetailsCategory: _getAllProjectsDetailsCategory,
            getAllProjectsDetailsSubCategory: _getAllProjectsDetailsSubCategory,
            getAllProjects: _getAllProjects
        };
    };
    var module = angular.module("diycm");
    module.factory("ProjectsService", ProjectsService);
}());