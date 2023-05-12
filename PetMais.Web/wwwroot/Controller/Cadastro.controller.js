sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/ui/model/resource/ResourceModel",
    "../services/Validacoes",
    "sap/ui/core/routing/History",
  ],
  function (Controller, JSONModel, formatter, ResourceModel, Validacoes, History) {
    "use strict";

    var i18nModel = new ResourceModel({
      bundleName: "sap.ui.petmais.i18n.i18n",
      bundleUrl: "../i18n/i18n.properties"
    });
    const i18n = i18nModel.getResourceBundle();

    return Controller.extend("sap.ui.petmais.controller.Cadastro", {
      formatter: formatter,
      onInit: function () {
        this.rota = this.getOwnerComponent().getRouter();
        this.rota
          .getRoute("cadastro")
          .attachMatched(this._aoCoincidirRotaCadastro, this);
        this.rota
          .getRoute("edicao")
          .attachMatched(this._aoCoincidirRotaEdicao, this);
      },
      _aoCoincidirRotaCadastro: function () {
        this.zerarValidacoes(false);
        this.limparFormulario();
        this.configurarCampoData();
        var novoObjetoModeloPet = new JSONModel({});
        this.getView().setModel(novoObjetoModeloPet, "dados");
      },
      _aoCoincidirRotaEdicao: function (evento) {
        this.zerarValidacoes(true);
        this.limparFormulario();
        this.configurarCampoData();
        var parametros = evento.getParameters();
        var idDoPet = parametros.arguments.id;
        this.pegarDadosDaApi(idDoPet);
      },
      pegarDadosDaApi: function (id) {
        var oModel = new JSONModel();
        oModel.loadData("/api/pets/" + id);
        this.getView().setModel(oModel, "dados");
        console.log(oModel);
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
        var dadosPet = modeloPet.getData();

        var pet = {
          nome: dadosPet.nome,
          tipo: dadosPet.tipo,
          cor: dadosPet.cor,
          sexo: dadosPet.sexo,
          dataDeNascimento: dadosPet.dataDeNascimento,
        };

        if (dadosPet.id) {
          fetch(`/api/pets/${dadosPet.id}`, {
            method: "PUT",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(pet),
          })
            .then((resposta) => {
              if (!resposta.ok) {
                throw new Error("Erro ao editar o pet");
              }
              sap.m.MessageToast.show("Pet editado com sucesso!");
              this.irParaTelaDetalhes(dadosPet.id);
            })
            .catch((erro) => {
              sap.m.MessageToast.show(erro.message);
            });
        } else {
          fetch("/api/pets", {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(pet),
          })
            .then((resposta) => {
              if (!resposta.ok) {
                throw new Error("Erro ao cadastrar o pet");
              }
              return resposta.json();
            })
            .then((dados) => {
              sap.m.MessageToast.show("Pet cadastrado com sucesso!");
              this.irParaTelaDetalhes(dados.id);
            })
            .catch((erro) => {
              sap.m.MessageToast.show(erro.message);
            });
        }
      },
      aoClicarBotaoCancelar: function () {
        this.voltarParaHome();
      },
      aoMudarValorInput: function () {
        var oInputNome = this.getView().byId("inputNome");
        var resultadoValidacaoInput = Validacoes.validarInput(oInputNome);
        this.validacaoResultado.nome = resultadoValidacaoInput;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      aoMudarValorSelect: function (evento) {
        var campoSelect = evento.getSource();
        var resultadoValidacaoSelect = Validacoes.validarSelect(campoSelect);
        var idNaoTratado = campoSelect.getId();
        var idTratado = this.tratarIdElemento(idNaoTratado);

        switch (idTratado) {
          case "selectTipo":
            this.validacaoResultado.selectTipo = resultadoValidacaoSelect;
            break;
          case "selectCor":
            this.validacaoResultado.selectCor = resultadoValidacaoSelect;
            break;
          case "selectSexo":
            this.validacaoResultado.selectSexo = resultadoValidacaoSelect;
            break;
        }
        console.log(this.validacaoResultado);
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      aoMudarValorDatePicker: function () {
        var oDatePickerNascimento = this.getView().byId(
          "datePickerDataNascimento"
        );
        var resultadoValidacaoDatePicker = Validacoes.validarDatePicker(
          oDatePickerNascimento
        );
        this.validacaoResultado.data = resultadoValidacaoDatePicker;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      abrirDatePicker: function (oEvent) {
        this.getView()
          .byId("datePickerDataNascimento")
          .openBy(oEvent.getSource().getDomRef());
      },
      aoValidarAtivarOuNaoBotaoSalvar: function () {
        var botaoSalvar = this.byId("botaoSalvar");
        if (
          this.validacaoResultado.nome &&
          this.validacaoResultado.selectTipo &&
          this.validacaoResultado.selectCor &&
          this.validacaoResultado.selectSexo &&
          this.validacaoResultado.data
        ) {
          botaoSalvar.setEnabled(true);
          botaoSalvar.setText(i18n.getText("textoBotaoSalvarValidado"));
        } else {
          botaoSalvar.setEnabled(false);
          botaoSalvar.setText(i18n.getText("textoBotaoSalvarNaoValidado"));
        }
      },
      tratarIdElemento: function (idNaoTratado) {
        var arrayDoIdNaoTratado = idNaoTratado.split("--");
        return arrayDoIdNaoTratado[2];
      },
      configurarCampoData: function () {
        var oDatePicker = this.getView().byId("datePickerDataNascimento");
        var oDate = new Date();
        oDate.setFullYear(oDate.getFullYear() - 150);
        oDatePicker.setMinDate(oDate);
        oDatePicker.setMaxDate(new Date());
      },
      configuracaoInicialBotaoSalvar: function (estado) {
        var botaoSalvar = this.byId("botaoSalvar");
        if (!estado) {
          botaoSalvar.setEnabled(false);
          botaoSalvar.setText(i18n.getText("textoBotaoSalvarNaoValidado"));
        } else {
          botaoSalvar.setEnabled(true);
          botaoSalvar.setText(i18n.getText("textoBotaoSalvarValidado"));
        }
      },
      zerarValidacoes: function (estado) {
        this.validacaoResultado = {
          nome: estado,
          selectTipo: estado,
          selectSexo: estado,
          selectCor: estado,
          data: estado
        };

        this.configuracaoInicialBotaoSalvar(estado)
      },
      limparFormulario: function () {
        var oNomeInput = this.byId("inputNome");
        var oTipoSelect = this.byId("selectTipo");
        var oCorSelect = this.byId("selectCor");
        var oSexoSelect = this.byId("selectSexo");
        var oDataNascimentoDatePicker = this.byId("datePickerDataNascimeento");

        oNomeInput?.setValue("");
        oTipoSelect?.setSelectedKey("");
        oCorSelect?.setSelectedKey("");
        oSexoSelect?.setSelectedKey("");
        oDataNascimentoDatePicker?.setValue("");

        const arrayDeCampos = [
          oNomeInput,
          oTipoSelect,
          oCorSelect,
          oSexoSelect,
          oDataNascimentoDatePicker,
        ];
        arrayDeCampos.forEach((elemento) =>
          Validacoes.removerMensagemDeErro(elemento)
        );
      },
      voltarParaHome: function () {
        this.rota.navTo("tabelaDePets", {}, true);
      },
      irParaTelaDetalhes: function (idDoPetCriado) {
        this.rota.navTo("detalhes", { id: idDoPetCriado });
      },
    });
  }
);