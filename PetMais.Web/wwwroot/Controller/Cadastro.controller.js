sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "../services/Validacoes",
    "sap/ui/core/routing/History",
    "../services/ChamadasApi",
    "../services/MensagensDeTela",
  ],
  function (Controller, JSONModel, formatter, Validacoes, History, ChamadasApi, MensagensDeTela) {
    "use strict";
    const _stringModeloi18n = "i18n"
    const _stringNomeDoModelo = "dados";
    const _stringDatePickerNascimentoId = "datePickerDataNascimento";
    const _stringInputNomeId = "inputNome";
    const _stringBotaoSalvarId = "botaoSalvar";

    return Controller.extend("sap.ui.petmais.controller.Cadastro", {
      formatter: formatter,
      onInit: function () {
        const modeloi18n = this.getOwnerComponent().getModel(_stringModeloi18n).getResourceBundle()
        Validacoes.criarModeloI18n(modeloi18n);
        var rota = this.getOwnerComponent().getRouter();
        rota
          .getRoute("cadastro")
          .attachMatched(this._aoCoincidirRotaCadastro, this);
        rota
          .getRoute("edicao")
          .attachMatched(this._aoCoincidirRotaEdicao, this);
      },
      _aoCoincidirRotaCadastro: function () {
        this.zerarValidacoes(false);
        this.limparFormulario();
        this.configurarCampoData();
        var novoObjetoModeloPet = new JSONModel({});
        this.getView().setModel(novoObjetoModeloPet, _stringNomeDoModelo);
      },
      _aoCoincidirRotaEdicao: function (evento) {
        this._processarEvento(() => {
          this.zerarValidacoes(true);
          this.limparFormulario();
          this.configurarCampoData();
          var parametros = evento.getParameters();
          var idDoPet = parametros.arguments.id;
          this.pegarDadosDaApi(idDoPet);
        })
      },
      _processarEvento: function (action) {
        const tipoDaPromise = "catch",
          tipoBuscado = "function";
        try {
          var promise = action();
          if (promise && typeof promise[tipoDaPromise] == tipoBuscado) {
            promise.catch((error) => MensagensDeTela.erro(error.message));
          }
        } catch (error) {
          MensagensDeTela.erro(error.message);
        }
      },
      pegarDadosDaApi: function (id) {
        var petModelo = new JSONModel();
        ChamadasApi.pegarPetPeloId(id)
          .then(dados => petModelo.setData(dados))
          .catch((erro) => MensagensDeTela.erro(erro.message))
        this.getView().setModel(petModelo, _stringNomeDoModelo)
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
        var modeloPet = this.getView().getModel(_stringNomeDoModelo);
        var dadosPet = modeloPet.getData();

        var pet = {
          nome: dadosPet.nome,
          tipo: dadosPet.tipo,
          cor: dadosPet.cor,
          sexo: dadosPet.sexo,
          dataDeNascimento: dadosPet.dataDeNascimento,
        };

        if (dadosPet.id) {
          return this.editarPetExistente(pet, dadosPet.id)
        }

        return this.cadastrarNovoPet(pet)
      },
      cadastrarNovoPet: function (objetoNovoPet) {
        const i18n = this.getView().getModel(_stringModeloi18n).getResourceBundle();
        ChamadasApi.criarPet(objetoNovoPet)
          .then((dados) => {
            MensagensDeTela.sucesso(i18n.getText("textoPetCadastradoComExito"));
            this.irParaTelaDetalhes(dados.id);
          })
          .catch((erro) => {
            MensagensDeTela.erro(erro.message);
          });
      },
      editarPetExistente: function (objetoPetExistente, idPetExistente) {
        const i18n = this.getView().getModel(_stringModeloi18n).getResourceBundle();
        ChamadasApi.editarPet(idPetExistente, objetoPetExistente)
          .then((dados) => {
            MensagensDeTela.sucesso(i18n.getText("textoPetCadastradoComExito")); 
            this.irParaTelaDetalhes(idPetExistente);
          })
          .catch((erro) => {
            MensagensDeTela.erro(erro.message);
          });
      },
      aoClicarBotaoCancelar: function () {
        this.voltarParaHome();
      },
      aoMudarValorInput: function () {

        var oInputNome = this.getView().byId(_stringInputNomeId);
        var resultadoValidacaoInput = Validacoes.validarInput(oInputNome);
        this.validacaoResultado.nome = resultadoValidacaoInput;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      aoMudarValorSelect: function (evento) {
        this._processarEvento(() => {
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
          this.aoValidarAtivarOuNaoBotaoSalvar();
        })
      },
      aoMudarValorDatePicker: function () {
        
        var oDatePickerNascimento = this.getView().byId(
          _stringDatePickerNascimentoId
        );
        var resultadoValidacaoDatePicker = Validacoes.validarDatePicker(
          oDatePickerNascimento
        );
        this.validacaoResultado.data = resultadoValidacaoDatePicker;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      abrirDatePicker: function (oEvent) {
        this.getView()
          .byId(_stringDatePickerNascimentoId)
          .openBy(oEvent.getSource().getDomRef());
      },
      aoValidarAtivarOuNaoBotaoSalvar: function () {
        var i18n = this.getView().getModel(_stringModeloi18n).getResourceBundle();
        var botaoSalvar = this.byId(_stringBotaoSalvarId);
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
        const posicaoOndeIdSeEncontra = 2
        return arrayDoIdNaoTratado[posicaoOndeIdSeEncontra];
      },
      configurarCampoData: function () {
        var oDatePicker = this.getView().byId(_stringDatePickerNascimentoId);
        var oDate = new Date();
        const idadeMaximoDoPet = 150;
        oDate.setFullYear(oDate.getFullYear() - idadeMaximoDoPet);
        oDatePicker.setMinDate(oDate);
        oDatePicker.setMaxDate(new Date());
      },
      configuracaoInicialBotaoSalvar: function (estado) {
        var i18n = this.getView().getModel(_stringModeloi18n).getResourceBundle();
        var botaoSalvar = this.byId(_stringBotaoSalvarId);
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
        const stringSelectTipo = "selectTipo";
        const stringSelectCor = "selectCor";
        const stringSelectSexo = "selectSexo";
        const valorVazio = "";

        var oNomeInput = this.byId(_stringInputNomeId);
        var oTipoSelect = this.byId(stringSelectTipo);
        var oCorSelect = this.byId(stringSelectCor);
        var oSexoSelect = this.byId(stringSelectSexo);
        var oDataNascimentoDatePicker = this.byId(_stringDatePickerNascimentoId);

        oNomeInput?.setValue(valorVazio);
        oTipoSelect?.setSelectedKey(valorVazio);
        oCorSelect?.setSelectedKey(valorVazio);
        oSexoSelect?.setSelectedKey(valorVazio);
        oDataNascimentoDatePicker?.setValue(valorVazio);

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
        const stringRotaTabelaDePets = "tabelaDePets";
        var rota = this.getOwnerComponent().getRouter();
        rota.navTo(stringRotaTabelaDePets, {}, true);
      },
      irParaTelaDetalhes: function (idDoPetCriado) {
        const stringRotaDetalhes = "detalhes";
        var rota = this.getOwnerComponent().getRouter();
        rota.navTo(stringRotaDetalhes, { id: idDoPetCriado });
      },
    });
  }
);