app.directive('topBar', [ function(){
	// Runs during compile
	return {
		restrict: 'E', // E = Element, A = Attribute, C = Class, M = Comment
		templateUrl: 'templates/public/top-bar.html',
		replace: true,
	};
}]);