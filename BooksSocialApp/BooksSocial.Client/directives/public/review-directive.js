app.directive('review', [function(){
	return {
		restrict: 'E', // E = Element, A = Attribute, C = Class, M = Comment
		replace: true,
		templateUrl: 'templates/public/review.html'
	};
}]);