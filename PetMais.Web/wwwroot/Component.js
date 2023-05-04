sap.ui.define(
    [
        "sap/ui/core/UIComponent",
        "sap/ui/model/resource/ResourceModel",
        "sap/ui/model/json/JSONModel"
    ],
    function (UIComponent, ResourceModel, JSONModel) {
        "use strict";
        return UIComponent.extend("sap.ui.petmais.Component", {
            metadata: {
                interfaces: ["sap.ui.core.IAsyncContentCreation"],
                manifest: "json",
            },
            init: function () {
                UIComponent.prototype.init.apply(this, arguments);
            },
        });
    }
);
