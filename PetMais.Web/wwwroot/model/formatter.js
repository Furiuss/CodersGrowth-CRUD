sap.ui.define([], function () {
	"use strict";

	return {

		iconesTipo: function (sStatus) {
			switch (sStatus) {
				case "GATO":
					return "../assets/icons-images/gato.png";
				case "CACHORRO":
					return "../assets/icons-images/cachorro.png";
				case "TARTARUGA":
					return "../assets/icons-images/tartaruga.png";
				case "PEIXE":
					return "../assets/icons-images/peixe.png";
				case "COELHO":
					return "../assets/icons-images/coelho.png";
				case "PATO":
					return "../assets/icons-images/pato.png";
				case "PASSARO":
					return "../assets/icons-images/passaro.png";
				default:
					return sStatus;
			}
		},

		iconesSexo: function (sStatus) {
			switch (sStatus) {
				case "MASCULINO":
					return "../assets/icons-images/macho.png";
				case "FEMININO":
					return "../assets/icons-images/femea.png";
				default:
					return sStatus;
			}
		}
	};
});