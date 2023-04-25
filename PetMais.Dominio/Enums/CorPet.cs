using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Enums
{
	public enum CorPet
	{	
		SELECIONAR,
		[LinqToDB.Mapping.MapValue(Value = "AMARELO")]
		AMARELO,
		[LinqToDB.Mapping.MapValue(Value = "CHOCOLATE")]
		CHOCOLATE,
		[LinqToDB.Mapping.MapValue(Value = "BRANCO")]
		BRANCO,
		[LinqToDB.Mapping.MapValue(Value = "PRETO")]
		PRETO,
		[LinqToDB.Mapping.MapValue(Value = "CINZENTO")]
		CINZENTO,
		[LinqToDB.Mapping.MapValue(Value = "DOURADO")]
		DOURADO,
		[LinqToDB.Mapping.MapValue(Value = "CREME")]
		CREME,
	}
}
