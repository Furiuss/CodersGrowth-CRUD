sap.ui.define(
  [
    "./BaseController.controller",
    "sap/ui/model/json/JSONModel",
    "../services/repositorio",
    "../model/formatador",
    "../services/mensagensDeTela",
  ],
  function (BaseController, JSONModel, Repositorio, Formatador, MensagensDeTela) {
    "use strict";
    let _i18n = null;
    const _nomeModeloi18n = "i18n"
    const caminhoControllerDetalhes = "sap.ui.petmais.controller.Detalhes"

    return BaseController.extend(caminhoControllerDetalhes, {
      formatter: Formatador,
      onInit: function () {
        _i18n = this.getOwnerComponent().getModel(_nomeModeloi18n).getResourceBundle();
        const rotaDetalhes = "detalhes";
        var rota = this.getOwnerComponent().getRouter();
        rota
          .getRoute(rotaDetalhes)
          .attachMatched(this._aoCoincidirRota, this);
      },
      _aoCoincidirRota: function (evento) {
        this._processarEvento(() => {
          var parametros = evento.getParameters();
          var idDoPet = parametros.arguments.id;
          this.pegarDadosDaApi(idDoPet);
        })
      },
      pegarDadosDaApi: function (id) {
        var modeloDadosDoPet = new JSONModel();
        Repositorio.pegarPetPeloId(id)
          .then(dadosDoPet => {
            if (dadosDoPet === false) {
              this.mensagemDePaginaNaoEncontrada()
            } else {
              modeloDadosDoPet.setData({ pet: dadosDoPet })
            }
          })
          .catch((erro) => MensagensDeTela.erro(erro.message))
        this.getView().setModel(modeloDadosDoPet)
      },
      mensagemDePaginaNaoEncontrada: function () {
        const textoPaginaNaoEncontrada = "textoPaginaNaoEncontrada"
        MensagensDeTela.erroComBotao(_i18n.getText(textoPaginaNaoEncontrada), this.voltarParaHome.bind(this))
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
          MensagensDeTela.confirmar(_i18n.getText(textoConfirmacaoAoRemover), this.removerPet.bind(this), [idDoPet])
        })
      },
      removerPet: function (idDoPet) {
        const textoPetRemovidoComExito = "textoPetRemovidoComExito"
        Repositorio.deletarPet(idDoPet)
          .then((dadosDoPet) => {
            MensagensDeTela.sucesso(_i18n.getText(textoPetRemovidoComExito));
            this.aoClicarEmVoltar();
          })
          .catch((erro) => MensagensDeTela.erro(erro.message))
      },
      aoClicarEmVoltar: function () {
        this._processarEvento(() => {
          const rotaTabela = "tabelaDePets"
          this.aoNavegar(rotaTabela);
        })
      },
    });
  }
);