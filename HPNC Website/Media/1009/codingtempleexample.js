alert("Oh, hello.");

var animal = "giraffe";

angular.module('codingTemple', []).directive('myDirective', function(){
	return {
		template: '<div> This is a directive!</div>'
	}	
}); 
	