sap.ui.define(
    [
        "sap/ui/core/UIComponent",
        "sap/ui/model/json/JSONModel"
    ],
    function (UIComponent, JSONModel) {
        "use strict";
        return UIComponent.extend("sap.ui.petmais.Component", {
            metadata: {
                interfaces: ["sap.ui.core.IAsyncContentCreation"],
                manifest: "json",
            },
            init: function () {
                UIComponent.prototype.init.apply(this, arguments);
  
                this.getRouter().initialize()
  
              var dados =  {
                  "nome": "",
                  "tipo": "",
                  "cor": "",
                  "sexo": "",
                  "dataNascimento": "",
              };
  
              var modelo = new JSONModel(dados);
              this.setModel(modelo, "dados");
            },
        });
    }
  );