var app = angular.module('diycm', ['ngRoute', 'LocalStorageModule']);

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
        controller: 'homeController',
        title: 'Projects'
    })
    .when('/singleProject', {
        templateUrl: 'views/singleProject.html',
        controller: 'homeController',
        title: 'Project Details'
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
