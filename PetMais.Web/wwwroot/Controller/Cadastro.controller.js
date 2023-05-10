sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "../services/Validacoes",
    "sap/ui/core/routing/History",
  ],
  function (Controller, JSONModel, formatter, Validacoes, History) {
    "use strict";

    return Controller.extend("sap.ui.petmais.controller.Cadastro", {
      formatter: formatter,
      onInit: function () {
        var rota = this.getOwnerComponent().getRouter();
        rota.getRoute("cadastro").attachMatched(this._aoCoincidirRota, this);
        this.zerarValidacoes()
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
          dataDeNascimento: dadosNovoPet.dataNascimento,
        };

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
            this.zerarValidacoes();
          })
          .catch((erro) => {
            sap.m.MessageToast.show(erro.message);
          });
      },
      aoClicarBotaoCancelar: function () {
        this.voltarParaHome();
        this.zerarValidacoes()
        this.limparFormulario();
      },
      aoMudarValorInput: function () {
        var oInputNome = this.getView().byId("nome");
        var resultadoValidacaoInput = Validacoes.validarInput(oInputNome);
        this.validacaoResultado.nome = resultadoValidacaoInput;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      aoMudarValorSelectTipo: function () {
        var oSelectTipo = this.getView().byId("tipo");
        var resultadoValidacaoSelect = Validacoes.validarSelect(oSelectTipo);
        this.validacaoResultado.selectTipo = resultadoValidacaoSelect;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      aoMudarValorSelectSexo: function () {
        var oSelectSexo= this.getView().byId("sexo");
        var resultadoValidacaoSelect = Validacoes.validarSelect(oSelectSexo);
        this.validacaoResultado.selectSexo = resultadoValidacaoSelect;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      aoMudarValorSelectCor: function () {
        var oSelectCor = this.getView().byId("cor");
        var resultadoValidacaoSelect = Validacoes.validarSelect(oSelectCor);
        this.validacaoResultado.selectCor = resultadoValidacaoSelect;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      aoMudarValorDatePicker: function () {
        var oDatePickerNascimento = this.getView().byId("dataNascimento");
        var resultadoValidacaoDatePicker = Validacoes.validarDatePicker(oDatePickerNascimento);
        this.validacaoResultado.data = resultadoValidacaoDatePicker;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      openDatePicker: function(oEvent) {
        this.getView().byId("dataNascimento").openBy(oEvent.getSource().getDomRef());
      },
      aoValidarAtivarOuNaoBotaoSalvar: function () {
        var botaoSalvar = this.byId("salvar");
        console.log(this.validacaoResultado)
        if (
          this.validacaoResultado.nome &&
          this.validacaoResultado.selectTipo &&
          this.validacaoResultado.selectCor &&
          this.validacaoResultado.selectSexo &&
          this.validacaoResultado.data
        ) {
          botaoSalvar.setEnabled(true);
        } else {
          botaoSalvar.setEnabled(false);
        }
      },
      zerarValidacoes: function () {
        this.validacaoResultado = {
          nome: false,
          selectTipo: false,
          selectSexo: false,
          selectCor: false,
          data: false,
        };
        var botaoSalvar = this.byId("salvar");
        botaoSalvar.setEnabled(false);
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
      },
    });
  }
);