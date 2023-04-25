using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Migrations
{
	[Migration(20230419131240)]
	public class _20230419131240_CriacaoDePets : Migration
	{

		public override void Up()
		{
			Create.Table("Pet")
				.WithColumn("Id").AsInt64().PrimaryKey().Identity()
				.WithColumn("Nome").AsString(20).NotNullable()
				.WithColumn("Tipo").AsString(20).NotNullable()
				.WithColumn("Cor").AsString(20).NotNullable()
				.WithColumn("Sexo").AsString(15).NotNullable()
				.WithColumn("DataDeNascimento").AsDateTime().NotNullable()
				.WithColumn("DataDeCadastro").AsDateTime().NotNullable();
		}

		public override void Down()
		{
			Delete.Table("Pets");
		}
	}
}
