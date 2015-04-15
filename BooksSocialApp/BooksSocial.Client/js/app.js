var app = angular.module('booksApp', ['ngRoute', 'ngResource']);

app.constant('baseServiceUrl', 'http://bookssocial.azurewebsites.net/api/');

app.config(['$routeProvider', '$locationProvider', '$filterProvider', function($routeProvider, $locationProvider, $filterProvider){
    $routeProvider.
		when('/', { templateUrl: 'views/public/home.html', controller: 'homeCtrl'}).
		when('/login', { templateUrl: 'views/public/login.html', controller: 'homeCtrl'}).
		when('/register', {	templateUrl: 'views/public/register.html',	controller: 'homeCtrl'}).
		when('/user/books', {templateUrl: 'views/user/books.html', controller: 'homeCtrl'}).
		when('/logout', {redirectTo: 'views/user/logout.html'}).
		otherwise({ redirectTo: "/"	});
}]);
