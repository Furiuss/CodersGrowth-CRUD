sap.ui.define(
  [
    "./BaseController.controller",
    "sap/ui/model/json/JSONModel",
    "../model/Formatador",
    "../services/Validacoes",
    "sap/ui/core/routing/History",
    "../services/Repositorio",  
    "../services/MensagensDeTela",
  ],
  function (BaseController, JSONModel, Formatador, Validacoes, History, Repositorio, MensagensDeTela) {
    "use strict";
    let _i18n = null;
    const _nomeModeloi18n = "i18n"
    const _nomeModeloDadosDoPet = "dadosDoPet";
    const _idDatePickerNascimento = "datePickerDataNascimento";
    const _idInputNome = "inputNome";
    const _idBotaoSalvar = "botaoSalvar";
    const caminhoCadastroController = "sap.ui.petmais.controller.Cadastro";
    const _textoBotaoSalvarValidado = "textoBotaoSalvarValidado"
    const _textoBotaoSalvarNaoValidado = "textoBotaoSalvarNaoValidado"

    return BaseController.extend(caminhoCadastroController, {
      formatter: Formatador,
      onInit: function () {
        const nomeDaRotaCadastro = "cadastro";
        const nomeDaRotaEdicao = "edicao";
        _i18n = this.getOwnerComponent().getModel(_nomeModeloi18n).getResourceBundle();
        Validacoes.criarModeloI18n(_i18n);
        var rota = this.getOwnerComponent().getRouter();
        rota
          .getRoute(nomeDaRotaCadastro)
          .attachMatched(this._aoCoincidirRotaCadastro, this);
        rota
          .getRoute(nomeDaRotaEdicao)
          .attachMatched(this._aoCoincidirRotaEdicao, this);
      },
      _aoCoincidirRotaCadastro: function () {
        this._processarEvento(() => {
          this.zerarvalidacoes(false);
          this.limparFormulario();
          this.configurarCampoData();
          var novoObjetoModeloPet = new JSONModel({});
          this.getView().setModel(novoObjetoModeloPet, _nomeModeloDadosDoPet);
        })
      },
      _aoCoincidirRotaEdicao: function (evento) {
        this._processarEvento(() => {
          this.zerarvalidacoes(true);
          this.limparFormulario();
          this.configurarCampoData();
          var parametros = evento.getParameters();
          var idDoPet = parametros.arguments.id;
          this.pegarDadosDaApi(idDoPet);
        })
      },
      pegarDadosDaApi: function (id) {
        var petModelo = new JSONModel();
        Repositorio.pegarPetPeloId(id)
          .then(dados => petModelo.setData(dados))
          .catch((erro) => MensagensDeTela.erro(erro.message))
        this.getView().setModel(petModelo, _nomeModeloDadosDoPet)
      },
      aoClicarBotaoSalvar: function () {
        this._processarEvento(() => {
          var modeloPet = this.getView().getModel(_nomeModeloDadosDoPet);
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
        })
      },
      cadastrarNovoPet: function (objetoNovoPet) {
        const textoPetCadastradoComExito = "textoPetCadastradoComExito";
        Repositorio.criarPet(objetoNovoPet)
          .then((dados) => {
            MensagensDeTela.sucesso(_i18n.getText(textoPetCadastradoComExito));
            this.irParaTelaDetalhes(dados.id);
          })
          .catch((erro) => {
            MensagensDeTela.erro(erro.message);
          });
      },
      editarPetExistente: function (objetoPetExistente, idPetExistente) {
        const textoPetEditadoComExito = "textoPetEditadoComExito";
        Repositorio.editarPet(idPetExistente, objetoPetExistente)
          .then((dados) => {
            MensagensDeTela.sucesso(_i18n.getText(textoPetEditadoComExito));
            this.irParaTelaDetalhes(idPetExistente);
          })
          .catch((erro) => {
            MensagensDeTela.erro(erro.message);
          });
      },
      aoClicarBotaoCancelar: function () {
        this._processarEvento(() => {
          this.voltarPagina();
        })
      },
      aoMudarValorInput: function () {
        var oInputNome = this.getView().byId(_idInputNome);
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
          const idSelectTipo = "selectTipo";
          const idSelectCor = "selectCor";
          const idSelectSexo = "selectSexo";

          switch (idTratado) {
            case idSelectTipo:
              this.validacaoResultado.selectTipo = resultadoValidacaoSelect;
              break;
            case idSelectCor:
              this.validacaoResultado.selectCor = resultadoValidacaoSelect;
              break;
            case idSelectSexo:
              this.validacaoResultado.selectSexo = resultadoValidacaoSelect;
              break;
          }
          this.aoValidarAtivarOuNaoBotaoSalvar();
        })
      },
      aoMudarValorDatePicker: function () {
        var oDatePickerNascimento = this.getView().byId(
          _idDatePickerNascimento
        );
        var resultadoValidacaoDatePicker = Validacoes.validarDatePicker(
          oDatePickerNascimento
        );
        this.validacaoResultado.data = resultadoValidacaoDatePicker;
        this.aoValidarAtivarOuNaoBotaoSalvar();
      },
      abrirDatePicker: function (oEvent) {
        this.getView()
          .byId(_idDatePickerNascimento)
          .openBy(oEvent.getSource().getDomRef());
      },
      aoValidarAtivarOuNaoBotaoSalvar: function () {
        var botaoSalvar = this.byId(_idBotaoSalvar);
        if (
          this.validacaoResultado.nome &&
          this.validacaoResultado.selectTipo &&
          this.validacaoResultado.selectCor &&
          this.validacaoResultado.selectSexo &&
          this.validacaoResultado.data
        ) {
          botaoSalvar.setEnabled(true);
          botaoSalvar.setText(_i18n.getText(_textoBotaoSalvarValidado));
        } else {
          botaoSalvar.setEnabled(false);
          botaoSalvar.setText(_i18n.getText(_textoBotaoSalvarNaoValidado));
        }
      },
      tratarIdElemento: function (idNaoTratado) {
        var arrayDoIdNaoTratado = idNaoTratado.split("--");
        const posicaoOndeIDSeEncontra = 2
        return arrayDoIdNaoTratado[posicaoOndeIDSeEncontra];
      },
      configurarCampoData: function () {
        var oDatePicker = this.getView().byId(_idDatePickerNascimento);
        var oDate = new Date();
        const idadeMaximaDoPet = 150;
        oDate.setFullYear(oDate.getFullYear() - idadeMaximaDoPet);
        oDatePicker.setMinDate(oDate);
        oDatePicker.setMaxDate(new Date());
      },
      configuracaoInicialBotaoSalvar: function (estado) {
        var botaoSalvar = this.byId(_idBotaoSalvar);
        if (!estado) {
          botaoSalvar.setEnabled(false);
          botaoSalvar.setText(_i18n.getText(_textoBotaoSalvarNaoValidado));
        } else {
          botaoSalvar.setEnabled(true);
          botaoSalvar.setText(_i18n.getText(_textoBotaoSalvarValidado));
        }
      },
      zerarvalidacoes: function (estado) {
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
        const idSelectTipo = "selectTipo";
        const idSelectCor = "selectCor";
        const idSelectSexo = "selectSexo";
        const valorVazio = "";

        var oNomeInput = this.byId(_idInputNome);
        var oTipoSelect = this.byId(idSelectTipo);
        var oCorSelect = this.byId(idSelectCor);
        var oSexoSelect = this.byId(idSelectSexo);
        var oDataNascimentoDatePicker = this.byId(_idDatePickerNascimento);

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
        const rotaTabelaDePets = "tabelaDePets";
        this.aoNavegar(rotaTabelaDePets)
      },
      irParaTelaDetalhes: function (idDoPetCriado) {
        const rotaDetalhes = "detalhes";
        this.aoNavegar(rotaDetalhes, idDoPetCriado)
      },
      voltarPagina: function () {
        var historico = History.getInstance();
        var hashAnterior = historico.getPreviousHash();
        if (hashAnterior !== undefined) {
          window.history.go(-1);
        } else {
          this.voltarParaHome();
        }
      } 
    });
  }
);