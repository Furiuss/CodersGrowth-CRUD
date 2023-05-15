sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "../services/ChamadasApi"
  ],
  function (Controller, JSONModel, formatter, Filter, FilterOperator, ChamadasApi) {
    "use strict";

    return Controller.extend("sap.ui.petmais.controller.TabelaDePets", {
      formatter: formatter,
      onInit: function () {
        const stringRotaNome = "tabelaDePets"
        var rota = this.getOwnerComponent().getRouter();
        rota.getRoute(stringRotaNome).attachMatched(this._aoCoincidirRota, this);
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
            promise.catch((error) => MessageBox.error(error.message));
          }
        } catch (error) {
          MessageBox.error(error.message);
        }
      },
      pegarDadosDaApi: function () {
        var petsModelo = new JSONModel();
        ChamadasApi.pegarPets()
          .then(dados => petsModelo.setData({pets: dados}))
          .catch((erro) => MessageToast.show(erro.message))
        this.getView().setModel(petsModelo)
      },
      aoClicarBotaoAdicionar: function () {
        const stringRotaNome = "cadastro"
        var rota = this.getOwnerComponent().getRouter();
        rota.navTo(stringRotaNome);
      },
      aoPesquisar: function (evento) {
        this._processarEvento(() => {
          const stringQuery = "query"
          var aFiltro = [];
          var sQuery = evento.getParameter(stringQuery);
          if (sQuery) {
            aFiltro.push(
              new Filter("nome", FilterOperator.Contains, sQuery)
            );
          }
          const stringPetsTableId = "petsTable"
          const stringBinding = "items"
          var oTabela = this.byId(stringPetsTableId);
          var oBinding = oTabela.getBinding(stringBinding);
          oBinding.filter(aFiltro);
        })
      },
      aoClicarNoItem: function (evento) {
        this._processarEvento(() => {
          const stringRotaNome = "detalhes"
          const stringIdDoItem = "id"
          var idDoItem = evento.getSource().getBindingContext().getProperty(stringIdDoItem);
          var rota = this.getOwnerComponent().getRouter();
          rota.navTo(stringRotaNome, {id : idDoItem});
        })
      },
    });
  }
);