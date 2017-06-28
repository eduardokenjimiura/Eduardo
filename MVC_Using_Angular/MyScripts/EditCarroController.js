app.controller("EditCarroController", function ($scope, $location, ShareData, SinglePageCRUDService, $http) {

 
    getcarro();
  
    function getcarro() {
       
        var promiseGetcarro = SinglePageCRUDService.getCarro(ShareData.value);
  
        promiseGetcarro.then(function (pl)
        {
            $scope.carro = {
                Id: 0,
                Ano: '',
                Cor: '',
                Nome: '',
                Placa: '',
                Modelo: ''
            };
            console.log(pl.data)
            $scope.carro = pl.data;
        },
        function (errorPl) {
            $scope.error = 'failure loading Employee', errorPl;
        });
    }


    $scope.save = function () {
        var carro = {
        
            Id: $scope.carro.Id,
            Ano: $scope.carro.Ano,
            Cor: $scope.carro.Cor,
            Nome:  $scope.carro.Nome,
            Placa: $scope.carro.Placa
        };
        console.log(carro)

        var request = $http({
            method: "put",
            url: "/api/CarroApi/" + carro.Id,
            data: carro
        });
       
        // var promisePutCarro = SinglePageCRUDService.put($scope.carro.Id,carro);
      
         
    };

});