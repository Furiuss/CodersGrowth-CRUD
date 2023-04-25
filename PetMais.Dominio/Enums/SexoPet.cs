using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Enums
{
	public enum SexoPet
	{
		SELECIONAR,
		[LinqToDB.Mapping.MapValue(Value = "MASCULINO")]
		MASCULINO,
		[LinqToDB.Mapping.MapValue(Value = "FEMININO")]
		FEMININO
	}
}
