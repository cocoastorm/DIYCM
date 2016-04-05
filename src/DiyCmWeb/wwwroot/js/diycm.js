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
        templateUrl: 'views/projects.html',
        controller: 'projectsController',
        title: 'Projects'
    })
    .when('/singleProject', {
        templateUrl: 'views/singleProject.html',
        controller: 'singleProjectController',
        title: 'Project Details'
    })
    .when('/quotes', {
        templateUrl: 'views/quotes.html',
        controller: 'quoteheadersController',
        title: 'Quotes'
    })
    .when('/quotes-details', {
        templateUrl: 'views/quotes-details.html',
        controller: 'homeController',
        title: 'Quote Details'
      })
    .when('/categories', {
        templateUrl: 'views/categories.html',
        controller: 'homeController',
        title: 'All Categories'
    })
    .when('/subCategories', {
        templateUrl: 'views/subCategories.html',
        controller: 'homeController',
        title: 'All Sub-Categories'
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
