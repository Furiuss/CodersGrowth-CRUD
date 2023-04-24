using System;
using System.Configuration;
using System.Linq;

using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;

using Microsoft.Extensions.DependencyInjection;
using PetMais.Infra.Services;
using PetMais.Repository;
using PetMais.Repository.Interfaces;

namespace PetMais
{
	internal static class Program
	{	
		[STAThread]
		static void Main()
		{
			using (var serviceProvider = MigrationsConfig.CreateServices())
			using (var scope = serviceProvider.CreateScope())
			{
				MigrationsConfig.UpdateDatabase(scope.ServiceProvider);
			}

			ApplicationConfiguration.Initialize();
			Application.Run(new TelaDeVisualizacao(new BDRepositorio()));			
		}
	}
}