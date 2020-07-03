using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspNetCoreIdentity.Config;

namespace AspNetCoreIdentity
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostingEnvironment)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(hostingEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json", true,true)
				.AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true, true)
				.AddEnvironmentVariables();

			if (hostingEnvironment.IsProduction()) {
				builder.AddUserSecrets<Startup>();
			}

			Configuration = builder.Build();
				
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddIdentityCOnfig(Configuration);
			services.AddAutohrizationConfig();
			services.ResolveDepencencies();

			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/erro/500");
				app.UseStatusCodePagesWithRedirects("/erro/{0}");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
