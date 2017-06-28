
app.controller('listaCarroController', function ($scope, $location, SinglePageCRUDService, ShareData) {

    carregarCarros();

    ///Função que busca todos os carros da base
    function carregarCarros() {
        var carrosLista = SinglePageCRUDService.getCarros();

        carrosLista.then(function (pl) { $scope.carros = pl.data },
              function (errorPl) {
                  $scope.error = 'erro ao carregar carros', errorPl;
              });
    }


    //Method to route to the addemployee
    $scope.addCarro = function () {
        $location.path("/listaCarro");
    }

    //Method to route to the editEmployee
    //The EmpNo passed to this method is further set to the ShareData
    //This value can then be used to communicate across the Controllers
    $scope.editCarro = function (Id) {
        ShareData.value = Id;
        $location.path("/editcarro");
    }

    //Method to route to the deleteEmployee
    //The EmpNo passed to this method is further set to the ShareData
    //This value can then be used to communicate across the Controllers
    $scope.deleteCarro = function (Id) {
        
        ShareData.value = Id;
        $location.path("/deletecarro");
    }
});