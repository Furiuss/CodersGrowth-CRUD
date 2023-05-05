sap.ui.define([
  "sap/ui/core/mvc/Controller",
  "sap/ui/model/json/JSONModel",
  "../model/formatter",
  "sap/ui/core/routing/History",
], function (Controller, JSONModel, formatter, History) {
  "use strict";

  return Controller.extend("sap.ui.petmais.controller.Detalhes", {
    formatter: formatter,
    onInit: function () {
      var rota = this.getOwnerComponent().getRouter();
      rota.getRoute("detalhes").attachMatched(this._onRouteMatched, this);
    },
    _onRouteMatched: function (oEvent) {
      var parametros = oEvent.getParameters();
      var idDoPet = parametros.arguments.id;
      this.pegarDadosDaApi(idDoPet)
    },
    pegarDadosDaApi: function (id) {
      var petsModelo = new JSONModel();
      fetch(`/api/pets/${id}`)
        .then(dados => dados.json())
        .then(dados => petsModelo.setData({ pet: dados }))  
      this.getView().setModel(petsModelo);
    },
    aoClicarEmVoltar: function () {
			var historico = History.getInstance();
			var hashAnterior = historico.getPreviousHash();

			if (hashAnterior !== undefined) {
				window.history.go(-1);
			} else {
				var rota = this.getOwnerComponent().getRouter();
				rota.navTo("tabelaDePets", {}, true);
			}
		}
  });
});