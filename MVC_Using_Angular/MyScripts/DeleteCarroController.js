app.controller("DeleteCarroController", function ($scope, $location, ShareData, SinglePageCRUDService) {

    getCarro();
    function getCarro() {

        var promiseGetcarro = SinglePageCRUDService.getCarro(ShareData.value);

        promiseGetcarro.then(function (pl) {
            $scope.carro = pl.data;
        },
              function (errorPl) {
                  $scope.error = 'Erro', errorPl;
              });
    }

    $scope.delete = function () {
        var promiseDeletecarro = SinglePageCRUDService.delete(ShareData.value);
    };

});