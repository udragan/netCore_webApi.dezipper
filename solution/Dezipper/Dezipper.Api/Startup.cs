﻿using com.udragan.netCore.webApi.Dezipper.Domain.Interfaces;
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

			services.AddMvc();

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

			app.UseMvc();
		}

		private static void SeedTestData(DezipperContext context)
		{
			LocationInfo loc1 = new LocationInfo(1000, "Location One");
			LocationInfo loc2 = new LocationInfo(2000, "Location Two");

			context.LocationInfos.Add(loc1);
			context.LocationInfos.Add(loc2);

			context.SaveChanges();
		}
	}
}
