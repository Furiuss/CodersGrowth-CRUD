sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatador",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "../services/repositorio",
    "../services/mensagensDeTela"
  ],
  function (Controller, JSONModel, formatador, filter, filterOperator, repositorio, mensagensDeTela) {
    "use strict";

    return Controller.extend("sap.ui.petmais.controller.TabelaDePets", {
      formatter: formatador,
      onInit: function () {
        const rotaTabelaDePets = "tabelaDePets"
        var rota = this.getOwnerComponent().getRouter();
        rota.getRoute(rotaTabelaDePets).attachMatched(this._aoCoincidirRota, this);
      },
      _aoCoincidirRota: function () {
        this.pegarDadosDaApi();
      },
      _processarEvento: function (action) {
        const tipoDaPromise = "catch",
          tipoBuscado = "function";
        try {
          var promise = action();
          if (promise && typeof promise[tipoDaPromise] == tipoBuscado) {
            promise.catch((error) => mensagensDeTela.erro(error.message));
          }
        } catch (error) {
          mensagensDeTela.erro(error.message);
        }
      },
      pegarDadosDaApi: function () {
        var petsModelo = new JSONModel();
        repositorio.pegarPets()
          .then(dados => petsModelo.setData({pets: dados}))
          .catch((erro) => mensagensDeTela.sucesso(erro.message))
        this.getView().setModel(petsModelo)
      },
      aoClicarBotaoAdicionar: function () {
        const rotaCadastro = "cadastro"
        var rota = this.getOwnerComponent().getRouter();
        rota.navTo(rotaCadastro);
      },
      aoPesquisar: function (evento) {
        this._processarEvento(() => {
          const query = "query"
          var aFiltro = [];
          var sQuery = evento.getParameter(query);
          if (sQuery) {
            aFiltro.push(
              new filter("nome", filterOperator.Contains, sQuery)
            );
          }
          const idPetsTable = "petsTable"
          const bindingItems = "items"
          var oTabela = this.byId(idPetsTable);
          var oBinding = oTabela.getBinding(bindingItems);
          oBinding.filter(aFiltro);
        })
      },
      aoClicarNoItem: function (evento) {
        this._processarEvento(() => {
          const rotaDetalhes = "detalhes"
          const idPropriedadeItem = "id"
          var idDoItem = evento.getSource().getBindingContext().getProperty(idPropriedadeItem);
          var rota = this.getOwnerComponent().getRouter();
          rota.navTo(rotaDetalhes, {id : idDoItem});
        })
      },
    });
  }
);