sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatador",
    "../services/repositorio",
    "../services/mensagensDeTela",
    "sap/ui/core/routing/History",
  ],
  function (controller, jsonModel, formatador, repositorio, mensagensDeTela, history) {
    "use strict";
    let _i18n = null;
    const _nomeModeloi18n = "i18n"
    const _rotaTabelaDePets = "tabelaDePets";
    const caminhoControllerDetalhes = "sap.ui.petmais.controller.Detalhes"

    return controller.extend(caminhoControllerDetalhes, {
      formatter: formatador,
      onInit: function () {
        _i18n = this.getOwnerComponent().getModel(_nomeModeloi18n).getResourceBundle();
        const rotaDetalhes = "detalhes";
        var rota = this.getOwnerComponent().getRouter();
        rota
          .getRoute(rotaDetalhes)
          .attachMatched(this._aoCoincidirRota, this);
      },
      _aoCoincidirRota: function (evento) {
        var parametros = evento.getParameters();
        var idDoPet = parametros.arguments.id;
        this.pegarDadosDaApi(idDoPet);
      },
      _processarEvento: function (action) {
        const tipoDaPromise = "catch",
          tipoBuscado = "function";
        try {
          var promise = action();
          if (promise && typeof promise[tipoDaPromise] == tipoBuscado) {
            promise.catch((error) => mensagensDeTela.erro(error.message));
          }
        } catch (error) {
          mensagensDeTela.erro(error.message);
        }
      },
      pegarDadosDaApi: function (id) {
        var modeloDadosDoPet = new jsonModel();
        repositorio.pegarPetPeloId(id)
          .then(dadosDoPet => {
            if (dadosDoPet === false) {
              this.mensagemDePaginaNaoEncontrada()
            } else {
              modeloDadosDoPet.setData({ pet: dadosDoPet })
            }
          })
          .catch((erro) => mensagensDeTela.erro(erro.message))
        this.getView().setModel(modeloDadosDoPet)
      },
      mensagemDePaginaNaoEncontrada: function () {
        const textoPaginaNaoEncontrada = "textoPaginaNaoEncontrada"
        mensagensDeTela.erroComBotao(_i18n.getText(textoPaginaNaoEncontrada), this.irParaTelaInicial.bind(this))
      },
      aoClicarEmVoltar: function () {
        var historico = history.getInstance();
        var hashAnterior = historico.getPreviousHash();

        if (hashAnterior !== undefined) {
          window.history.go(-1);
        } else {
          var rota = this.getOwnerComponent().getRouter();
          rota.navTo(_rotaTabelaDePets, {}, true);
        }
      },
      aoClicarBotaoEditar: function (evento) {
        this._processarEvento(() => {
          const rotaEdicao = "edicao";
          const idPropriedade = "id"
          var rota = this.getOwnerComponent().getRouter();
          const idDoPet = evento
            .getSource()
            .getBindingContext()
            .getProperty(idPropriedade);
          rota.navTo(rotaEdicao, { id: idDoPet });
        })
      },
      aoClicarBotaoRemover: function (evento) {
        this._processarEvento(() => {
          const textoConfirmacaoAoRemover = "textoConfirmacaoAoRemover"
          const idDoPetPropriedade = "id"
          const idDoPet = evento.getSource().getBindingContext().getProperty(idDoPetPropriedade);
          mensagensDeTela.confirmar(_i18n.getText(textoConfirmacaoAoRemover), this.removerPet.bind(this), [idDoPet])
        })
      },
      removerPet: function (idDoPet) {
        const textoPetRemovidoComExito = "textoPetRemovidoComExito"
        repositorio.deletarPet(idDoPet)
          .then((dadosDoPet) => {
            mensagensDeTela.sucesso(_i18n.getText(textoPetRemovidoComExito));
            this.irParaTelaInicial();
          })
          .catch((erro) => mensagensDeTela.erro(erro.message))
      },
      irParaTelaInicial: function () {
        var rota = this.getOwnerComponent().getRouter();
        rota.navTo(_rotaTabelaDePets, {}, true);
      },
    });
  }
);