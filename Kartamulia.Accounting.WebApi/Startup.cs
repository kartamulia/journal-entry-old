using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kartamulia.Accounting.BusinessRules;
using Kartamulia.Accounting.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kartamulia.Accounting.WebApi
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
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<IGeneralJournalRepository, GeneralJournalRepository>();
            services.AddSingleton<IJournalValidator, JournalValidator>();

            services.AddCors(setup =>
            {
                setup.AddPolicy("AllowSpecificOrigin",
                    policy => policy.WithOrigins("http://localhost"));
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseMvc();
        }
    }
}
