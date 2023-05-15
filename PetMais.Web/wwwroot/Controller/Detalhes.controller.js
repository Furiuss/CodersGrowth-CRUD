sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/core/routing/History",
  ],
  function (Controller, JSONModel, formatter, History) {
    "use strict";

    return Controller.extend("sap.ui.petmais.controller.Detalhes", {
      formatter: formatter,
      onInit: function () {
        var rota = this.getOwnerComponent().getRouter();
        rota
          .getRoute("detalhes")
          .attachMatched(this._aoCoincidirRota, this);
      },
      _aoCoincidirRota: function (evento) {
        var parametros = evento.getParameters();
        var idDoPet = parametros.arguments.id;
        this.pegarDadosDaApi(idDoPet);
      },
      pegarDadosDaApi: function (id) {
        const enderecoApi = "/api/pets/";
        var petsModelo = new JSONModel();
        fetch(enderecoApi + id)
          .then((dados) => dados.json())
          .then((dados) => petsModelo.setData({ pet: dados }));
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
      },
      aoClicarBotaoEditar: function (evento) {
        var rota = this.getOwnerComponent().getRouter();
        const idDoPet = evento
          .getSource()
          .getBindingContext()
          .getProperty("id");
        rota.navTo("edicao", { id: idDoPet });
      },
      aoClicarBotaoRemover: function (evento) {
        const i18n = this.getView().getModel("i18n").getResourceBundle();
        const idDoPet = evento.getSource().getBindingContext().getProperty("id");
        const enderecoApi = "/api/pets/";
        fetch(enderecoApi + idDoPet, {
          method: "DELETE",
        })
          .then((resposta) => {
            if (!resposta.ok) {
              throw new Error(i18n.getText("textoErroAoRemover"));
            }
            sap.m.MessageToast.show(i18n.getText("textoPetRemovidoComExito"));
            this.irParaTelaInicial();
          })
          .catch((erro) => {
            sap.m.MessageToast.show(erro.message);
          });
      },
      irParaTelaInicial: function () {
        var rota = this.getOwnerComponent().getRouter();
        rota.navTo("tabelaDePets", {}, true);
      },
    });
  }
);