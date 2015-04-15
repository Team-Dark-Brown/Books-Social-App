app.directive('category-list', [function(){
	return {
		restrict: 'E', // E = Element, A = Attribute, C = Class, M = Comment
		replace: true,
		templateUrl: 'templates/public/category-list.html'
	};
}]);