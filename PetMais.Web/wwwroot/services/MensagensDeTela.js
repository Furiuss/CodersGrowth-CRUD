sap.ui.define([
  "sap/m/MessageBox",
  "sap/m/MessageToast"
], function (messageBox, messageToast) {
  "use strict";

  return {
    sucesso: function (mensagem) {
      return messageToast.show(mensagem);
    },
    erro: function (mensagem) {
      return messageBox.error(mensagem);
    },
    erroComBotao: function (mensagem, funcaoCallback, args = null) {
      return messageBox.error(mensagem, {
        actions: [messageBox.Action.YES],
        onClose: (acao) => {
          if (acao === messageBox.Action.YES) {
            return funcaoCallback.apply(this, args)
          }
        }
      })
    },
    confirmar: function (mensagem, funcaoCallback, id) {
      return messageBox.confirm(mensagem, {
        actions: [messageBox.Action.YES, messageBox.Action.NO],
        onClose: (acao) => {
          if (acao === messageBox.Action.YES) {
            return funcaoCallback.apply(this, id)
          }
          return 
        }
      })
    }
  }
});