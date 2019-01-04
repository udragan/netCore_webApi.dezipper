using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using com.udragan.netCore.webApi.Dezipper.Domain.Interfaces;
using com.udragan.netCore.webApi.Dezipper.Domain.Models;
using com.udragan.netCore.webApi.Dezipper.Infrastructure.Contexts;
using com.udragan.netCore.webApi.Dezipper.Infrastructure.Repositories;
using com.udragan.netCore.webApi.Dezipper.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace com.udragan.netCore.webApi.Dezipper.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DezipperContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDatabase"));

			services.AddScoped<ILocationInfoRepository, LocationInfoRepository>();
			services.AddScoped<IDezipperUnitOfWork, DezipperUnitOfWork>();

			services.AddMvcCore()
				.AddApiExplorer()
				.AddAuthorization()
				.AddJsonFormatters();

			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

			services.AddAuthentication(options =>
			{
				options.DefaultScheme = "Cookies";
				options.DefaultChallengeScheme = "oidc";
			})
				.AddCookie("Cookies")
				.AddOpenIdConnect("oidc", options =>
				{
					options.SignInScheme = "Cookies";

					options.Authority = Configuration.GetSection("Auth:IdentityServerAddress").Value;
					options.RequireHttpsMetadata = false;

					options.ClientId = "dezipper.api";
					options.SaveTokens = true;
				});

			services.AddSwaggerGen(x =>
			{
				x.SwaggerDoc("v0.1", new Info { Title = "DezipperAPI", Version = "v0.1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
				{
					DezipperContext context = serviceScope.ServiceProvider.GetRequiredService<DezipperContext>();

					SeedTestData(context);
				}

				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v0.1/swagger.json", "DezipperAPI");
			});

			app.UseAuthentication();

			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();
		}

		private static void SeedTestData(DezipperContext context)
		{
			IList<LocationInfo> testLocations = new List<LocationInfo>();

			testLocations.Add(new LocationInfo(90000,
				"Los Angeles",
				"California",
				"CA",
				latitude: 34.052235,
				longitude: -118.243683));
			testLocations.Add(new LocationInfo(77000,
				"Austin",
				"Texas",
				"TX",
				latitude: 30.274613,
				longitude: -97.740353));
			testLocations.Add(new LocationInfo(58000,
				"Phoenix",
				"Arizona",
				"AZ",
				latitude: 33.739650,
				longitude: -112.054554));

			testLocations.Add(new LocationInfo(60000,
				"Chicago",
				"Illinois",
				"IL",
				latitude: 41.875430,
				longitude: -87.619033));
			testLocations.Add(new LocationInfo(30000,
				"Atlanta",
				"Georgia",
				"GA",
				latitude: 33.761086,
				longitude: -84.388335));

			context.LocationInfos.AddRange(testLocations);

			context.SaveChanges();
		}
	}
}
