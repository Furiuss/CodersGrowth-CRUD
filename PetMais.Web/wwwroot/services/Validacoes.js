sap.ui.define([], function () {
  "use strict";

  return {
    validarForm: function (objetoInput, objetoSelectArray, objetoDatePicker) {
      if (this.validarInput(objetoInput) || this.validarSelect(objetoSelectArray) || this.validarDatePicker(objetoDatePicker)) {
        return false
      }

      return true
    },

    validarInput: function (objetoInput) {
      if (this.campoNaoPoderSerVazio(objetoInput)) {
        return false
      }

      return true;
    },

    validarSelect: function (objetoSelectArray) {
      objetoSelectArray.forEach(elemento => {
        return this.campoSelectTemQueSerSelecionado(elemento)
      });

      return false;
    },

    validarDatePicker: function (objetoDatePicker) {
      if (this.campoNaoPoderSerVazio(objetoDatePicker)) {
        return true
      }

      return false;
    },

    campoNaoPoderSerVazio: function (objetoCampo) {
      if (!objetoCampo.getValue()) {
        objetoCampo.setValueState(sap.ui.core.ValueState.Error)
        objetoCampo.setValueStateText("Campo obrigatório")
        return true;
      }
      return false;
    },

    campoSelectTemQueSerSelecionado: function (objetoSelect) {
      if (!objetoSelect.getSelectedKey()) {
        objetoSelect.setValueState(sap.ui.core.ValueState.Error)
        objetoSelect.setValueStateText("Campo obrigatório")
        return true;
      }
      return false;
    }
  }
});