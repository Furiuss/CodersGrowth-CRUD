using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using PetMais.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Infra.Services
{
	public class ConfiguracaoDeMigracoes
	{
		private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

		public static ServiceProvider CriarServicos()
		{
			return new ServiceCollection()
				.AddFluentMigratorCore()
				.ConfigureRunner(rb => rb
					.AddSqlServer()
					.WithGlobalConnectionString(connectionString)
					.ScanIn(typeof(_20230419131240_CriacaoDePets).Assembly).For.Migrations())
				.AddLogging(lb => lb.AddFluentMigratorConsole())
				.BuildServiceProvider(false);
		}

		public static void AtualizarBancoDeDados(IServiceProvider provedorDeServico)
		{
			var runner = provedorDeServico.GetRequiredService<IMigrationRunner>();
			runner.MigrateUp();
		}
	}
}
