sap.ui.define([
], function () {
  "use strict";

  return {
    _i18n: null,
    criarModeloI18n: function (i18nModel) {
      this._i18n = i18nModel;
    },
    validarInput: function (input) {
      const nome = input.getValue();
      if (!nome) {
        const textoInputVazio = "textoInputVazio"
        this.mostrarMensagemDeErro(input, this._i18n.getText(textoInputVazio));
        return false;
      }
      if (!this.validarNome(nome)) {
        const textoValidacaoDoNome = "textoValidacaoDoNome"
        this.mostrarMensagemDeErro(input, this._i18n.getText(textoValidacaoDoNome));
        return false;
      }
      if (!this.validarTamanhoMinimoNome(nome)) {
        const textoValidarTamanhoMinimo = "textoValidarTamanhoMinimo"
        this.mostrarMensagemDeErro(input, this._i18n.getText(textoValidarTamanhoMinimo));
        return false;
      }
      this.removerMensagemDeErro(input);
      return true;
    },

    validarSelect: function (select) {
      const valorSelect = select.getSelectedKey();
      if (!valorSelect) {
        const textoValidarSelect = "textoValidarSelect"
        this.mostrarMensagemDeErro(select, this._i18n.getText(textoValidarSelect));
        return false;
      }
      this.removerMensagemDeErro(select);
      return true;
    },

    validarDatePicker: function (datePicker) {
      const valorDatePicker = datePicker.getValue();
      if (!valorDatePicker) {
        const textoValidarDatePicker = "textoValidarDatePicker"
        this.mostrarMensagemDeErro(datePicker, this._i18n.getText(textoValidarDatePicker));
        return false;
      }
      this.removerMensagemDeErro(datePicker);
      return true;
    },

    validarNome: function (nome) {
      const regex = /^[a-zA-Z\s]+$/;
      return regex.test(nome);
    },

    validarTamanhoMinimoNome: function (nome) {
      return nome.length >= 2;
    },

    mostrarMensagemDeErro: function (campo, mensagem) {
      campo.setValueState(sap.ui.core.ValueState.Error);
      campo.setValueStateText(mensagem);
    },

    removerMensagemDeErro: function (campo) {
      campo?.setValueState(sap.ui.core.ValueState.None);
    },
  };
});