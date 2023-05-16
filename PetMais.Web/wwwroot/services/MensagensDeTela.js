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
    erroComBotao: function (mensagem, funcaoCallback, thisDaFuncaoCallback, args = null) {
      return MessageBox.error(mensagem, {
        actions: [MessageBox.Action.YES],
        onClose: function (acao) {
          if (acao === MessageBox.Action.YES) {
            return funcaoCallback.apply(thisDaFuncaoCallback, args)
          }
        }.bind(this)
      })
    },
    confirmar: function (mensagem, funcaoCallback, args, thisDaFuncaoCallback) {
      return MessageBox.confirm(mensagem, {
        actions: [MessageBox.Action.YES, MessageBox.Action.NO],
        onClose: function (acao) {
          if (acao === MessageBox.Action.YES) {
            return funcaoCallback.apply(thisDaFuncaoCallback, args)
          }
          return
        }.bind(this)
      })
    }
  }
});