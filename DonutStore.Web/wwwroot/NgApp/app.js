var myApp = angular.modules("myApp", ["ui-router"]);
myApp.controller("MainController", MainController);

myApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider.state('main', {
        url: '/',
        templateUrl: '/NgApp/Views/main.html',
        controller: MainController,
        controllerAs: 'controller'

    });
    $urlRouterProvider.otherwise('/notFound');
    $locationProvider.html5Mode(true);
});
