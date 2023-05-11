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
        this.rota = this.getOwnerComponent().getRouter();
        this.rota.getRoute("cadastro").attachMatched(this._aoCoincidirRota, this);
      },
      _aoCoincidirRota: function () {
        var modeloBotao = new JSONModel({
          isEnabled: false
        })
        var objetoModeloPet = new JSONModel({});
        this.getView().setModel(objetoModeloPet, "dados");
        this.getView().setModel(modeloBotao, "modeloBotao");
        this.configurarCampoData();
        this.zerarValidacoes();
        this.limparFormulario();
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
            this.irParaTelaDetalhes(dados.id);
          })
          .catch((erro) => {
            sap.m.MessageToast.show(erro.message);
          });
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
          case 'selectTipo': 
            this.validacaoResultado.selectTipo = resultadoValidacaoSelect;
            break;
          case 'selectCor':
            this.validacaoResultado.selectCor = resultadoValidacaoSelect;
            break;
          case 'selectSexo':
            this.validacaoResultado.selectSexo = resultadoValidacaoSelect;
            break;
        }
        console.log(this.validacaoResultado)
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      aoMudarValorDatePicker: function () {
        var oDatePickerNascimento = this.getView().byId("datePickerDataNascimento");
        var resultadoValidacaoDatePicker = Validacoes.validarDatePicker(oDatePickerNascimento);
        this.validacaoResultado.data = resultadoValidacaoDatePicker;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      abrirDatePicker: function(oEvent) {
        this.getView().byId("datePickerDataNascimento").openBy(oEvent.getSource().getDomRef());
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
          botaoSalvar.setText("Salvar")
        } else {
          botaoSalvar.setEnabled(false);
          botaoSalvar.setText("Preencha todos os campos")
        }
      },
      tratarIdElemento: function(idNaoTratado) {
        var arrayDoIdNaoTratado = idNaoTratado.split("--")
        return arrayDoIdNaoTratado[2]
      },
      configurarCampoData: function() {
        var oDatePicker = this.getView().byId("datePickerDataNascimento");
        var oDate = new Date();
        oDate.setFullYear(oDate.getFullYear() - 150);
        oDatePicker.setMinDate(oDate);
        oDatePicker.setMaxDate(new Date());
      },
      zerarValidacoes: function () {
        this.validacaoResultado = {
          nome: false,
          selectTipo: false,
          selectSexo: false,
          selectCor: false,
          data: false,
        };
        var botaoSalvar = this.byId("botaoSalvar");
        botaoSalvar.setEnabled(false);
        botaoSalvar.setText("Preencha todos os campos")
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

        const arrayDeCampos = [oNomeInput, oTipoSelect, oCorSelect, oSexoSelect, oDataNascimentoDatePicker]
        arrayDeCampos.forEach(elemento => Validacoes.removerMensagemDeErro(elemento));
      },
      voltarParaHome: function () {
        this.rota.navTo("tabelaDePets", {}, true);
      },
      irParaTelaDetalhes: function (idDoPetCriado) {
        this.rota.navTo("detalhes", {id : idDoPetCriado});
      }
    });
  }
);