sap.ui.define(
  [
    "./BaseController.controller",
    "sap/ui/model/json/JSONModel",
    "../services/repositorio",
    "../model/formatador",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "../services/mensagensDeTela"
  ],
  function (BaseController, JSONModel, Repositorio, Formatador, Filter, FilterOperator, MensagensDeTela) {
    "use strict";
    const caminhoControllerTabelaDePets = "sap.ui.petmais.controller.TabelaDePets"
    return BaseController.extend(caminhoControllerTabelaDePets, {
      formatter: Formatador,
      onInit: function () {
        const rotaTabelaDePets = "tabelaDePets"
        var rota = this.getOwnerComponent().getRouter();
        rota.getRoute(rotaTabelaDePets).attachMatched(this._aoCoincidirRota, this);
      },
      _aoCoincidirRota: function () {
        this._processarEvento(() => {
          this.pegarDadosDaApi();
        })
      },
      pegarDadosDaApi: function () {
        var petsModelo = new JSONModel();
        Repositorio.pegarPets()
          .then(dados => petsModelo.setData({pets: dados}))
          .catch((erro) => MensagensDeTela.sucesso(erro.message))
        this.getView().setModel(petsModelo)
      },
      aoClicarBotaoAdicionar: function () {
        this._processarEvento(() => {
          const rotaCadastro = "cadastro";
          this.aoNavegar(rotaCadastro);
        })
      },
      aoPesquisar: function (evento) {
        this._processarEvento(() => {
          const query = "query"
          var aFiltro = [];
          var sQuery = evento.getParameter(query);
          if (sQuery) {
            aFiltro.push(
              new Filter("nome", FilterOperator.Contains, sQuery)
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
          this.aoNavegar(rotaDetalhes, idDoItem)
        })
      },
    });
  }
);