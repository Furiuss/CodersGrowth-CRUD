sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../model/formatter",
    "sap/m/MessageBox",
    "../services/ChamadasApi",
    "../services/MensagensDeTela",
    "sap/ui/core/routing/History",
  ],
  function (Controller, JSONModel, formatter, MessageBox, ChamadasApi, MensagensDeTela, History) {
    "use strict";

    const _stringRotaTabelaDePets = "tabelaDePets";
    const _stringModeloi18n = "i18n"

    return Controller.extend("sap.ui.petmais.controller.Detalhes", {
      formatter: formatter,
      onInit: function () {
        const stringRotaNome = "detalhes";
        var rota = this.getOwnerComponent().getRouter();
        rota
          .getRoute(stringRotaNome)
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
            promise.catch((error) => MensagensDeTela.erro(error.message));
          }
        } catch (error) {
          MensagensDeTela.erro(error.message);
        }
      },
      pegarDadosDaApi: function (id) {
        var petModelo = new JSONModel();
        ChamadasApi.pegarPetPeloId(id)
          .then(dados => {
            if (dados === false) {
              this.mensagemDePaginaNaoEncontrada()
            } else {
              petModelo.setData({ pet: dados })
            }
          })
          .catch((erro) => MensagensDeTela.erro(erro.message))
        this.getView().setModel(petModelo)
      },
      mensagemDePaginaNaoEncontrada: function () {
        const i18n = this.getView().getModel(_stringModeloi18n).getResourceBundle();
        MessageBox.error(i18n.getText("textoPaginaNaoEncontrada"), {
          onClose: function () {
            this.irParaTelaInicial()
          }.bind(this)
        })
      },
      aoClicarEmVoltar: function () {
        var historico = History.getInstance();
        var hashAnterior = historico.getPreviousHash();

        if (hashAnterior !== undefined) {
          window.history.go(-1);
        } else {
          var rota = this.getOwnerComponent().getRouter();
          rota.navTo(_stringRotaTabelaDePets, {}, true);
        }
      },
      aoClicarBotaoEditar: function (evento) {
        this._processarEvento(() => {
          const stringRotaNome = "edicao";
          const stringPropriedadeId = "id"
          var rota = this.getOwnerComponent().getRouter();
          const idDoPet = evento
            .getSource()
            .getBindingContext()
            .getProperty(stringPropriedadeId);
          rota.navTo(stringRotaNome, { id: idDoPet });
        })
      },
      aoClicarBotaoRemover: function (evento) {
        this._processarEvento(() => {
          const idDoPet = evento.getSource().getBindingContext().getProperty("id");
          const i18n = this.getView().getModel(_stringModeloi18n).getResourceBundle();
          MessageBox.confirm(i18n.getText("textoConfirmacaoAoRemover"), {
            actions: [MessageBox.Action.YES, MessageBox.Action.NO],
            onClose: function (acao) {
              if (acao === MessageBox.Action.YES) {
                return this.removerPet(idDoPet)
              }
              return
            }.bind(this)
          })
        })
      },
      removerPet: function (idDoPet) {
        const i18n = this.getView().getModel(_stringModeloi18n).getResourceBundle();
        ChamadasApi.deletarPet(idDoPet)
          .then((dados) => {
            MensagensDeTela.sucesso(i18n.getText("textoPetRemovidoComExito"));
            this.irParaTelaInicial();
          })
          .catch((erro) => MensagensDeTela.erro(erro.message))
      },
      irParaTelaInicial: function () {
        var rota = this.getOwnerComponent().getRouter();
        rota.navTo(_stringRotaTabelaDePets, {}, true);
      },
    });
  }
);