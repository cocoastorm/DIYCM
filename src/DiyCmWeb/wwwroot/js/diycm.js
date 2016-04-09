var app = angular.module('diycm', ['ngRoute', 'LocalStorageModule', 'ngAnimate', 'ui.bootstrap']);

// setup the routing
app.config(function ($routeProvider) {

    $routeProvider
    .when('/home', {
        templateUrl: 'views/home.html',
        controller: 'homeController',
        title: 'Home'
    })
    .when('/projects', {
        templateUrl: 'views/projects/projects.html',
        controller: 'projectsController',
        title: 'Projects'
    })
    .when('/projects/:id', {
        templateUrl: 'views/projects/singleProject.html',
        controller: 'singleProjectController',
        title: 'Project Details'
    })
    .when('/quotes', {
        templateUrl: 'views/quotes/quotes.html',
        controller: 'quoteheadersController',
        title: 'Quotes'
    })
    .when('/quotes-details', {
        templateUrl: 'views/quotes/quotes-details.html',
        controller: 'homeController',
        title: 'Quote Details'
      })
    .when('/categories', {
        templateUrl: 'views/categories/categories.html',
        controller: 'homeController',
        title: 'All Categories'
    })
    .when('/subCategories', {
        templateUrl: 'views/subcategories/subCategories.html',
        controller: 'homeController',
        title: 'All Sub-Categories'
    })
    .when('/documents', {
        templateUrl: 'views/documents/documents.html',
        controller: 'documentsController',
        title: 'All Documents'
    });
    $routeProvider.otherwise({ redirectTo: "/home" });

});

// Controls the rootscope
app.run(function ($rootScope, $route) {
    $rootScope.$on("$routeChangeSuccess", function (currentRoute, previousRoute) {
        //Change page title, based on Route information
        $rootScope.title = $route.current.title;
    });
});
