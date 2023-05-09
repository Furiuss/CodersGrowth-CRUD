sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "../services/Validacoes",
    "sap/m/MessageToast",
    "sap/ui/core/routing/History",
  ],
  function (Controller, JSONModel, formatter, Validacoes, MessageToast, History) {
    "use strict";

    return Controller.extend("sap.ui.petmais.controller.Cadastro", {
      formatter: formatter,
      onInit: function () {
        var rota = this.getOwnerComponent().getRouter();
        rota.getRoute("cadastro").attachMatched(this._aoCoincidirRota, this);
      },
      _aoCoincidirRota: function () {
        var objetoModeloPet = new JSONModel({});
        this.getView().setModel(objetoModeloPet, "dados");
      },
      aoClicarEmVoltar: function () {
        var historico = History.getInstance();
        var hashAnterior = historico.getPreviousHash();

        if (hashAnterior !== undefined) {
          window.history.go(-1);
        } else {
          this.voltarParaHome();
        }
      },
      aoClicarBotaoSalvar: function () {
        var modeloPet = this.getView().getModel("dados");
        var dadosNovoPet = modeloPet.getData();

        var novoPet = {
          nome: dadosNovoPet.nome,
          tipo: dadosNovoPet.tipo,
          cor: dadosNovoPet.cor,
          sexo: dadosNovoPet.sexo,
          dataDeNascimento: dadosNovoPet.dataNascimento
        };

        var oInputNome = this.getView().byId("nome")
        var oSelectTipo = this.getView().byId("tipo")
        var oSelectCor = this.getView().byId("cor")
        var oSelectSexo = this.getView().byId("sexo")
        var oDatePickerNascimento = this.getView().byId("dataNascimento")

        var arrayDeObjetosSelect = [oSelectTipo, oSelectCor, oSelectSexo]

        Validacoes.validarForm(oInputNome, arrayDeObjetosSelect, oDatePickerNascimento)

        fetch("/api/pets", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(novoPet),
        })
          .then((resposta) => {
            if (!resposta.ok) {
              throw new Error("Erro ao cadastrar o pet");
            }
            return resposta.json();
          })
          .then((dados) => {
            sap.m.MessageToast.show("Pet cadastrado com sucesso!");
            this.voltarParaHome();
          })
          .catch((erro) => {
            sap.m.MessageToast.show(erro.message);
          });

        this.limparFormulario();

      },
      aoClicarBotaoCancelar: function () {
        this.voltarParaHome();
        this.limparFormulario();
      },
      limparFormulario: function () {
        var oNomeInput = this.byId("nome");
        var oTipoSelect = this.byId("tipo");
        var oCorSelect = this.byId("cor");
        var oSexoSelect = this.byId("sexo");
        var oDataNascimentoDatePicker = this.byId("dataNascimento");

        oNomeInput.setValue("");
        oTipoSelect.setSelectedKey("");
        oCorSelect.setSelectedKey("");
        oSexoSelect.setSelectedKey("");
        oDataNascimentoDatePicker.setValue("");
      },
      voltarParaHome: function () {
        var rota = this.getOwnerComponent().getRouter();
        rota.navTo("tabelaDePets", {}, true);
      }
    });
  }
);