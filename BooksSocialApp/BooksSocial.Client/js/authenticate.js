app.service('AuthenticateService', ['$http', '$rootScope', 'baseServiceUrl', function($http, $rootScope, baseServiceUrl) {

	this.login = function(user, pass){
		var loginReq = { "username": user, "password": pass };
		resource = $http.post(baseServiceUrl + "user/login", loginReq)
		.then(function(response){
			console.log(response);
			sessionStorage.loginToken = response.data.access_token;
			sessionStorage.username = response.data.username;
			self.broadcastUser();
		});
	};

	this.logout = function(){
		delete(sessionStorage.loginToken) ;
		delete(sessionStorage.username);
		delete(sessionStorage.adminRights);
	
		self.broadcastUser();
		self.broadcastAdmin();

		resource = $http.post(baseServiceUrl + "Account/Logout")
		.then(function(response){
			console.log("logged out");
		});
	};
	
	this.registerUser = function(user, email, pass, confimPass, phone){
		var registerReq = { "username": user, 		
							"email": email, 
							"password": pass, 
							"confirmPassword": confirmPass, 
							"phone":phone
						};
		resource = $http.post(baseServiceUrl + "Account/Register", registerReq)
		.then(function(response){
			sessionStorage.loginToken = response.data.access_token;
			sessionStorage.username = response.data.username;
			self.broadcastUser();
		});
	};


	this.broadcastUser = function(){
		$rootScope.$broadcast('AuthenticationUser', {key: 'user', newvalue: sessionStorage.username});
		$rootScope.$broadcast('AuthenticationToken', {key: 'token', newvalue: sessionStorage.loginToken});
	};

	this.broadcastAdmin = function(){
		$rootScope.$broadcast('AuthenticationAdmin', {key: 'admin', newvalue: sessionStorage.adminRights});
	};

	var self = this;
}]);