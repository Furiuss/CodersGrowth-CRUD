using PetMais.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Infra.Servicos
{
	public class StringParaEnum
	{
		public static Enum TipoStringParaTipoEnum(string tipo)
		{
			return (TipoPet)Enum.Parse(typeof(TipoPet), tipo);
		}

		public static Enum SexoStringParaTipoEnum(string sexo)
		{
			return (SexoPet)Enum.Parse(typeof(SexoPet), sexo);
		}

		public static Enum CorStringParaTipoEnum(string cor)
		{
			return (CorPet)Enum.Parse(typeof(CorPet), cor);
		}
	}
}
