using Microsoft.AspNetCore.StaticFiles;
using PetMais;
using PetMais.Infra.Persistencia.Repositorio;
using PetMais.Repository.Interfaces;
using PetMais.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository, LINQ2DBRepositorio>();

var app = builder.Build();

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



app.Run();
