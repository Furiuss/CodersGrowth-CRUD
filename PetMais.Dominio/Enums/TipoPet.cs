using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Enums
{
	public enum TipoPet
	{
		SELECIONAR,
		[LinqToDB.Mapping.MapValue(Value = "GATO")]
		GATO,
		[LinqToDB.Mapping.MapValue(Value = "CACHORRO")]
		CACHORRO,
		[LinqToDB.Mapping.MapValue(Value = "TARTARUGA")]
		TARTARUGA,
		[LinqToDB.Mapping.MapValue(Value = "COELHO")]
		COELHO,
		[LinqToDB.Mapping.MapValue(Value = "PATO")]
		PATO,
		[LinqToDB.Mapping.MapValue(Value = "PASSARO")]
		PASSARO
	}
}
