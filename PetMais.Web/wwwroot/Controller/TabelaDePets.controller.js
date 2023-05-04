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
        var modelo = this.pegarDadosDaApi();
        this.getView().setModel(modelo)
      },
      pegarDadosDaApi: function () {
        var petsModelo = new JSONModel();
        fetch("/api/pets")
          .then(dados => dados.json())
          .then(dados => petsModelo.setData({ pets: dados }))  
        return petsModelo;        
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
      // onPress: function (oEvent) {
      //   var oItem = oEvent.getSource();
      //   var oRouter = this.getOwnerComponent().getRouter();
      //   oRouter.navTo("detail", {
      //     invoicePath: window.encodeURIComponent(
      //       oItem.getBindingContext("invoice").getPath().substring(1)
      //     ),
      //   });
      // },
    });
  }
);
