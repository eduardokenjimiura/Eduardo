///novo controller para adicionar um carro
app.controller('AddCarroController', function ($scope, SinglePageCRUDService) {
    ///colca o Id igual a zero 
    $scope.Id = 0;
    $scope.carro = {
        Id: 0,
        Ano:'',
        Cor: '',
        Nome:'',
        Placa: '',
        Modelo:''
    };
    ///salva um novo carro
    $scope.save = function () {
        var carro = {

            Id: 0,
            Ano: $scope.carro.Ano,
            Cor: $scope.carro.Cor,
            Nome: $scope.carro.Nome,
            Placa: $scope.carro.Placa,
            Modelo: $scope.carro.Modelo
        };
        console.log(carro)
        ///realiza o post
        var promisePost = SinglePageCRUDService.post(carro);

        ////realiza o alerta com id do carro cadastrado
        promisePost.then(function (pl) {
            $scope.Id = pl.data.Id;
            alert("Novo carro " );
        },
              function (errorPl) {
                  $scope.error = 'erro', errorPl;
              });

    };

});