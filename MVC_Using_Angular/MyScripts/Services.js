////Serviço contento as funções de manipulação da entidade carro
app.service("SinglePageCRUDService", function ($http) {

    ///função para listar todos os carros
    this.getCarros = function () {
        return $http.get("api/CarroApi");
    };
    
    //Função para pegar um carro especifico 
    this.getCarro = function (id) {
     
        return $http.get("api/CarroApi/" + id);
    };

    ///função para criar um novo carro
    this.post = function (carro) {
       
        var request = $http({
           
            method: "post",
            url: "/api/CarroApi",
            data: carro
        });
        return request;
    };

    ///função para alterar um carro
    this.put = function (id, Carro) {
       
        var request = $http({
            method: "put",
            url: "/api/CarroApi/" + id,
            data: carro
        });
        return request;
    };

    //Função para deletar um carro
    this.delete = function (id) {
        console.log('delete')
        var request = $http({
            method: "delete",
            url: "/api/CarroApi/" + id
        });
        return request;
    };
});








