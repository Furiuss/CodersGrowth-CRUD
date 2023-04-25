using LinqToDB.Configuration;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Infra.Configuracoes
{
	public class MinhasConfiguracoes : ILinqToDBSettings
	{
		public IEnumerable<IDataProviderSettings> DataProviders
			=> Enumerable.Empty<IDataProviderSettings>();

		public string DefaultConfiguration => "SqlServer";
		public string DefaultDataProvider => "SqlServer";

		public IEnumerable<IConnectionStringSettings> ConnectionStrings
		{
			get
			{
				yield return
					new ConnectionStringConfiguracoes
					{
						Name = "ConnectionString",
						ProviderName = ProviderName.SqlServer,
						ConnectionString =
							@"Data Source=DESKTOP-GMPDDMC;Initial Catalog=PetMais;User ID=sa;Password=sap@123"
					};
			}
		}
	}
}
