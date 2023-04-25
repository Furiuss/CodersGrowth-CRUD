using System;
using System.Configuration;
using System.Linq;

using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using LinqToDB.Data;
using Microsoft.Extensions.DependencyInjection;
using PetMais.Infra.Configuracoes;
using PetMais.Infra.Persistencia.Repositorio;
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
			DataConnection.DefaultSettings = new MinhasConfiguracoes();

			using (var serviceProvider = ConfiguracaoDeMigracoes.CriarServicos())
			using (var scope = serviceProvider.CreateScope())
			{
				ConfiguracaoDeMigracoes.AtualizarBancoDeDados(scope.ServiceProvider);
			}

			ApplicationConfiguration.Initialize();
			Application.Run(new TelaDeVisualizacao(new LINQ2DBRepositorio()));
		}
	}
}