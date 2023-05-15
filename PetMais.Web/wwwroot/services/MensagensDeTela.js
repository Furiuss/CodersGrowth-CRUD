sap.ui.define([
  "sap/m/MessageBox",
  "sap/m/MessageToast"
], function (MessageBox, MessageToast) {
  "use strict";

  return {
    sucesso: function (mensagem) {
      return MessageToast.show(mensagem);
    },
    erro: function (mensagem) {
      return MessageBox.error(mensagem);
    }
  }
});