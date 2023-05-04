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
        var oModel = new JSONModel();
        fetch("/api/pets")
          .then(data => data.json())
          .then(data => oModel.setData({ pets: data }))

        console.log(oModel)
        this.getView().setModel(oModel)

      },
      aoPesquisar: function (oEvent) {
        var aFilter = [];
        var sQuery = oEvent.getParameter("query");
        if (sQuery) {
          aFilter.push(
            new Filter("nome", FilterOperator.Contains, sQuery)
          );
        }

        var oList = this.byId("petsTable");
        var oBinding = oList.getBinding("items");
        oBinding.filter(aFilter);
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
