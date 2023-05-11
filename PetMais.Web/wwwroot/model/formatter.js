sap.ui.define([], function () {
	"use strict";

	return {

		iconesTipo: function (tipo) {
			switch (tipo) {
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
					return tipo;
			}
		},

		iconesSexo: function (sexo) {
			switch (sexo) {
				case "MASCULINO":
					return "../assets/icons-images/macho.png";
				case "FEMININO":
					return "../assets/icons-images/femea.png";
				default:
					return sexo;
			}
		},

		paraMinusculo: function (valor) {
			return valor?.toLowerCase()
		},

		idadeEmAnos: function(nascimento) {
			var anoNascimento = new Date(nascimento).getFullYear();
			var anoAtual = new Date().getFullYear();
			return anoAtual - anoNascimento;
		},

		idadeEmMeses: function(nascimento) {
			var mesNascimento = new Date(nascimento).getMonth();
			var mesAtual = new Date().getMonth();
			return mesAtual - mesNascimento;
		},
		formatarData: function(data) {
			if (!data) {
				return "Escolha o dia do nascimento do pet"
			}
			var dataMoment = moment(data,"YYYY-MM-DDTHH:mm:ss.MMM");
      var dataHoraFormatada = dataMoment.format("DD/MM/YYYY");
			console.log(dataHoraFormatada)
      return dataHoraFormatada;
		},
		textoBotaoHabilitadoOuNao: function(booleanoHabilitado){
			if (booleanoHabilitado) {
				return "Salvar"
			}
			return "Preencha todos os campos"
		}
	};
});