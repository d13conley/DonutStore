var myApp = angular.module("myApp", ["ui.router"]);
myApp.controller("MainController", MainController);

myApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
	$stateProvider.state('main', {
		url: '/',
		templateUrl: '/NgApp/views/main.html',
		controller: MainController,
		controllerAs: 'controller'
	});
	$urlRouterProvider.otherwise('/notFound');
	$locationProvider.html5Mode(true);
}); 