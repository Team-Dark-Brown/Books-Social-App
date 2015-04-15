var app = angular.module('booksApp', ['ngRoute', 'ngResource']);

app.constant('baseServiceUrl', 'http://bookssocial.azurewebsites.net/api/');

app.config(['$routeProvider', '$locationProvider', '$filterProvider', function($routeProvider, $locationProvider, $filterProvider){
    $routeProvider.
		when('/', { templateUrl: 'views/public/home.html', controller: 'homeCtrl'}).
		when('/login', { templateUrl: 'views/public/login.html', controller: 'homeCtrl'}).
		when('/register', {	templateUrl: 'views/public/register.html',	controller: 'homeCtrl'}).
		when('/user/books', { templateUrl: 'views/user/books.html', controller: 'homeCtrl'}).
		when('/admin/add-book', { templateUrl : 'views/admin/book-editor.html', controller: 'homeCtrl'}).
		when('/admin/add-genre', { templateUrl : 'views/admin/genre-editor.html', controller: 'homeCtrl'}).
		when('/user/add-list', { templateUrl : 'views/user/reading-list-editor.html', controller: 'homeCtrl'}).
		when('/user/view-lists', { templateUrl : 'views/user/list-of-reading-lists.html', controller: 'homeCtrl'}).
		when('/logout', { templateUrl: 'views/public/logout.html', controller: 'homeCtrl'}).
		otherwise({ redirectTo: "/"	});
}]);
