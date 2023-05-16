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
    },
    erroComBotao: function (mensagem, funcaoCallback, args = null) {
      return MessageBox.error(mensagem, {
        actions: [MessageBox.Action.YES],
        onClose: (acao) => {
          if (acao === MessageBox.Action.YES) {
            return funcaoCallback.apply(this, args)
          }
        }
      })
    },
    confirmar: function (mensagem, funcaoCallback, id) {
      return MessageBox.confirm(mensagem, {
        actions: [MessageBox.Action.YES, MessageBox.Action.NO],
        onClose: (acao) => {
          if (acao === MessageBox.Action.YES) {
            return funcaoCallback.apply(this, id)
          }
          return 
        }
      })
    }
  }
});