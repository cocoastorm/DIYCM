var app = angular.module('diycm', ['ngRoute']);

// setup the routing
app.config(function ($routeProvider) {

    $routeProvider
      .when('/', {
          templateUrl: 'views/home.html',
          controller: 'homeController'
      });

});
