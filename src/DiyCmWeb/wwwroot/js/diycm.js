var app = angular.module('diycm', ['ngRoute']);

// setup the routing
app.config(function ($routeProvider) {

    $routeProvider
      .when('/', {
          templateUrl: 'views/home.html',
          controller: 'homeController'
      });

    $routeProvider
     .when('/projects', {
         templateUrl: 'views/projects.html',
         controller: 'homeController'
     });

    $routeProvider
    .when('/singleProject', {
        templateUrl: 'views/singleProject.html',
        controller: 'homeController'
    });

});
