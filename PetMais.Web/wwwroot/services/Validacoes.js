sap.ui.define([], function () {
  "use strict";

  return {
    validarInput: function (objetoInput) {
      if (this.campoNaoPoderSerVazio(objetoInput) && this.campoNomeNaoPodeConterNumerosOuCaracteresEspeciais(objetoInput)) {
        return true
      }

      return false
    },

    validarSelect: function (objetoSelect) {
      return this.campoSelectTemQueSerSelecionado(objetoSelect);
    },

    validarDatePicker: function (objetoDatePicker) {
      if (this.campoNaoPoderSerVazio(objetoDatePicker)) {
        return true
      }

      return false
    },


    campoNaoPoderSerVazio: function (objetoCampo) {
      if (!objetoCampo.getValue()) {
        this.mostrarMensagemDeErro(objetoCampo, "Campo obrigatório")
        return false;
      }
      this.removerMensagemDeErro(objetoCampo)
      return true;
    },

    campoSelectTemQueSerSelecionado: function (objetoSelect) {
      if (!objetoSelect.getSelectedKey()) {
        this.mostrarMensagemDeErro(objetoSelect, "Campo obrigatório")
        return false;
      }
      this.removerMensagemDeErro(objetoSelect)
      return true;
    },
    campoDatePickerNaoPodeTerMaisDe10Caracteres: function (objetoDatePicker) {
      var valorData = objetoDatePicker.getValue()
      if (valorData.length > 10) {
        this.mostrarMensagemDeErro(objetoDatePicker, "Campo não pode conter mais de 8 números")
        return false
      }
      this.removerMensagemDeErro(objetoDatePicker)
      return true
    },
    campoNomeNaoPodeConterNumerosOuCaracteresEspeciais: function (objetoInput) {
      var regex = /^[a-zA-Z\s]+$/;
      var valorInput = objetoInput.getValue();
      if (regex.test(valorInput) === false) {
        this.mostrarMensagemDeErro(objetoInput, "Campo não pode conter números ou caracteres")
        return false
      }
      this.removerMensagemDeErro(objetoInput)
      return true
    },

    mostrarMensagemDeErro: function (objetoDoCampo, mensagemDeErro) {
      objetoDoCampo.setValueState(sap.ui.core.ValueState.Error)
      objetoDoCampo.setValueStateText(mensagemDeErro)
    },
    removerMensagemDeErro: function (objetoDoCampo) {
      objetoDoCampo.setValueState(sap.ui.core.ValueState.None)
    }
  }
});