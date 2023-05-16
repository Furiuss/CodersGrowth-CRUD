sap.ui.define(
  [
    "sap/ui/core/mvc/Controller"
  ],
  function (Controller) {
    "use strict";
    const caminhoAppController = "sap.ui.petmais.controller.BaseController"

    return Controller.extend(caminhoAppController, {
      aoClicarEmVoltar: function () {
        var historico = History.getInstance();
        var hashAnterior = historico.getPreviousHash();
        if (hashAnterior !== undefined) {
          window.history.go(-1);
        } else {
          this.voltarParaHome();
        }
      },
    });
  }
);
