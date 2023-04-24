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
	public class MigrationsConfig
	{
		private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

		public static ServiceProvider CreateServices()
		{
			return new ServiceCollection()
				.AddFluentMigratorCore()
				.ConfigureRunner(rb => rb
					.AddSqlServer()
					.WithGlobalConnectionString(connectionString)
					.ScanIn(typeof(CriacaoDePets).Assembly).For.Migrations())
				.AddLogging(lb => lb.AddFluentMigratorConsole())
				.BuildServiceProvider(false);
		}

		public static void UpdateDatabase(IServiceProvider serviceProvider)
		{
			var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
			runner.MigrateUp();
		}
	}
}
