sap.ui.define([
  "./MensagensDeTela"
], function (MensagensDeTela) {
  "use strict";
  return {
    _urlBase: "/api",

    _mandarRequisicao: function (urlDoMetodo, opcoesDoMetodo) {
      var urlInteira = this._urlBase + urlDoMetodo;
      return fetch(urlInteira, opcoesDoMetodo).then((resposta) => {
        if (resposta.status === 404) {
          return false
        }
        if (!resposta.ok) {
          throw new Error(i18n.getText("textoErroAoCadastrar"));
        } else if (resposta.status === 204) {
          return {};
        } else {
          return resposta.json();
        }
      });
    },

    _get: function (endpoint) {
      return this._mandarRequisicao(endpoint, { method: "GET" });
    },

    _post: function (endpoint, dadosPet) {
      return this._mandarRequisicao(endpoint, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(dadosPet),
      });
    },

    _put: function (endpoint, dadosPet) {
      return this._mandarRequisicao(endpoint, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(dadosPet),
      });
    },

    _delete: function (endpoint) {
      return this._mandarRequisicao(endpoint, { method: "DELETE" });
    },

    pegarPets: function () {
      return this._get("/pets");
    },

    pegarPetPeloId: function (id) {
      return this._get("/pets/" + id);
    },

    criarPet: function (pet) {
      return this._post("/pets", pet);
    },

    editarPet: function (id, pet) {
      return this._put("/pets/" + id, pet);
    },

    deletarPet: function (id) {
      return this._delete("/pets/" + id);
    },
  };
});