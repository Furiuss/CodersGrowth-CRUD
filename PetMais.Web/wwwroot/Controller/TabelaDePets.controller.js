sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
  ],
  function (Controller, JSONModel, formatter, Filter, FilterOperator) {
    "use strict";

    return Controller.extend("sap.ui.petmais.controller.TabelaDePets", {
      formatter: formatter,
      onInit: function () {
        this.pegarDadosDaApi();        
      },
      pegarDadosDaApi: function () {
        var petsModelo = new JSONModel();
        fetch("/api/pets")
          .then(dados => dados.json())
          .then(dados => petsModelo.setData({ pets: dados }))  
        this.getView().setModel(petsModelo)
      },
      aoPesquisar: function (oEvent) {
        var aFiltro = [];
        var sQuery = oEvent.getParameter("query");
        if (sQuery) {
          aFiltro.push(
            new Filter("nome", FilterOperator.Contains, sQuery)
          );
        }

        var oTabela = this.byId("petsTable");
        var oBinding = oTabela.getBinding("items");
        oBinding.filter(aFiltro);
      },
      aoClicarNoItem: function (oEvent) {
        var idDoItem = oEvent.getSource().getBindingContext().getProperty("id");
        var oRota = this.getOwnerComponent().getRouter();
        oRota.navTo("detalhes", {id : idDoItem});
      },
    });
  }
);
