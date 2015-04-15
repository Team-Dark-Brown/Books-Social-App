app.directive('book', [function(){
	return {
		// name: '',
		// priority: 1,
		// terminal: true,
		// scope: {}, // {} = isolate, true = child, false/undefined = no change
		// controller: function($scope, $element, $attrs, $transclude) {},
		// require: 'ngModel', // Array = multiple requires, ? = optional, ^ = check parent elements
		
		// template: '',
		
		
		// transclude: true,
		// compile: function(tElement, tAttrs, function transclude(function(scope, cloneLinkingFn){ return function linking(scope, elm, attrs){}})),
		restrict: 'E', // E = Element, A = Attribute, C = Class, M = Comment
		replace: true,
		templateUrl: 'templates/public/book.html'
	};
}]);