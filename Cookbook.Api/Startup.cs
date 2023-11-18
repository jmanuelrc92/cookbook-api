using Cookbook.Application.Repositories;
using Cookbook.Domain.Models.Configuration;
using Microsoft.Extensions.Options;
using Recipes.Infrastructure.Repositories;

namespace Cookbook.WebApi;

public class Startup
{
	public IConfiguration Configuration { get; }

	public Startup(IConfiguration configuration)
	{
		this.Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.Configure<MongoDbSettings>(this.Configuration.GetSection("MongoDbSettings"));
		services.AddSingleton<MongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		services.AddControllers();
		services.AddSwaggerGen();
	}

	public void Configure(WebApplication app, IHostApplicationLifetime lifetime)
	{
		app.MapControllers();
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}
	}
}