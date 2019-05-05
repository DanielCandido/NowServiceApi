var ViewModel = function () {
    var self = this;
    self.prestadors = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.categorias= ko.observableArray();
    self.newPrestador = {
        Categoria: ko.observable(),
        Nome: ko.observable(),
        Sobrenome: ko.observable(),
        Email: ko.observable(),
        Cpf: ko.observable(),
        Rg: ko.observable(),
        Nascimento: ko.observable(),
        Senha: ko.observable()
    }


    var apiUrl = '/api/Prestadors/';
    var categoriaUrl = '/api/Categorias/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllPrestadors() {
        ajaxHelper(apiUrl, 'GET').done(function (data) {
            self.prestadors(data);
        });
    }

    self.getPrestadorDetail = function (item) {
        ajaxHelper(apiUrl + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    function getCategorias() {
        ajaxHelper(categoriaUrl, 'GET').done(function (data) {
            self.categorias(data);
        });
    }

  
    self.addPrestador = function (formElement) {
        var prestador = {
            CategoriaId: self.newPrestador.Categoria().Id,
            Nome: self.newPrestador.Nome(),
            Sobrenome: self.newPrestador.Sobrenome(),
            Email: self.newPrestador.Email(),
            Cpf: self.newPrestador.Cpf(),
            Rg: self.newPrestador.Rg(),
            Nascimento: self.newPrestador.Nascimento(),
            Senha: self.newPrestador.Senha()         
        };

        ajaxHelper(apiUrl, 'POST', prestador).done(function (item) {
            self.prestadors.push(item);
        }).then(s => {
            console.log(s);
        }).catch(e => {
            console.log(e);
        });
    }
    
    // Fetch the initial data.
    getAllPrestadors();
    getCategorias();
};


ko.applyBindings(new ViewModel());