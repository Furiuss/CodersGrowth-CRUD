using Microsoft.AspNetCore.StaticFiles;

namespace PetMais.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
		}

		public void Configure(WebApplication app, IWebHostEnvironment environment)
		{
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles(new StaticFileOptions
			{
				ServeUnknownFileTypes = true,
				DefaultContentType = "text/plain;charset=utf-8",
				ContentTypeProvider = new FileExtensionContentTypeProvider(new Dictionary<string, string>
				{
					{".properties", "text/plain;charset=utf-8" }
				})
			});
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
			});
			app.UseAuthorization();
			app.MapControllers();
		}
	}
}
