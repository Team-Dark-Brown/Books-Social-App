app.controller('homeCtrl', ['$scope', 'AuthenticateService', 'DataService', function($scope, AuthenticateService, DataService){
	$scope.title = "what";
	$scope.login = function(user, pass){
		AuthenticateService.login(user,pass);
		console.log("debug-login");
	};

	$scope.logout = function(){
		AuthenticateSerivce.logout();
		console.log("debug-logout");
	};

	$scope.registerUser = function(user, email, pass, confirmPass, phone){
		AuthenticateService.registerUser(user, email, pass, confirmPass, phone);
		console.log("debug-register");
	};

	$scope.getBooks = function(){
		DataService.getAllBooks(function(response){
			$scope.books = response.books;
		});
	};

	$scope.getUserShelves = function(userId){
		DataService.getUserShelves(function(response){
			$scope.shelves = response.shelves;
		});
	};

	$scope.createUserShelf = function(){
		//TODO
	};

	$scope.createBook = function(){
		//TODO
	};

	$scope.createGenre = function(){
		//TODO
	};
}]);