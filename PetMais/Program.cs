using System;
using System.Configuration;
using System.Linq;

using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;

using Microsoft.Extensions.DependencyInjection;
using PetMais.Migrations;

namespace PetMais
{
	internal static class Program
	{
		private static string connectionString = ConfigurationManager.ConnectionStrings["PetMais"].ConnectionString;

		[STAThread]
		static void Main()
		{

			ApplicationConfiguration.Initialize();
			Application.Run(new TelaDeVisualizacao());

			using (var serviceProvider = CreateServices())
			using (var scope = serviceProvider.CreateScope())
			{
				UpdateDatabase(scope.ServiceProvider);
			}
		}

		private static ServiceProvider CreateServices()
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

		private static void UpdateDatabase(IServiceProvider serviceProvider)
		{
			var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
			runner.MigrateUp();
		}
	}
}