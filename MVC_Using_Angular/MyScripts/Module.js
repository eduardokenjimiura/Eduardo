    var app = angular.module("ApplicationModule", ["ngRoute"]);

    app.factory("ShareData", function () {
        return { value: 0 }
    });

    app.config(['$routeProvider','$locationProvider', function ($routeProvider,$locationProvider) {
       
        $routeProvider.when('/listaCarro',
                         {
                             templateUrl: 'Carro/listaCarro',
                             controller: 'listaCarroController'
                         });
        $routeProvider.when('/addcarro',
                            {
                                templateUrl: 'Carro/Addcarro',
                                controller: 'AddCarroController'
                            });
        $routeProvider.when("/editcarro",
                            {
                                templateUrl: 'Carro/EditCarro',
                                controller: 'EditCarroController'
                            });
        $routeProvider.when('/deletecarro',
                            {
                                templateUrl: 'Carro/DeleteCarro',
                                controller: 'DeleteCarroController'
                            });
        $routeProvider.otherwise(
                            {
                                redirectTo: '/'
                            });
       // $locationProvider.html5Mode(true);
        $locationProvider.html5Mode(true).hashPrefix('!')
    }]);