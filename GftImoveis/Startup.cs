using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using GftImoveis.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GftImoveis.Repositories;

namespace GftImoveis
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

            var conexao = Configuration.GetConnectionString("Default");
            services.AddDbContext<ApplicationDbContext>(op => op.UseMySql(conexao));

            services.AddDefaultIdentity<IdentityUser>(options => {options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireNonAlphanumeric = false;})
                .AddEntityFrameworkStores<ApplicationDbContext>();
                
                //Habilitando serviços para o Repository via injeção.
                services.AddTransient<IQuartoRepository, QuartoRepository>();
                services.AddTransient<IBairroRepository, BairroRepository>();
                services.AddTransient<IMunicipioRepository, MunicipioRepository>();
                services.AddTransient<IEnderecoRepository, EnderecoRepository>();
                services.AddTransient<ICategoriaRepository, CategoriaRepository>();
                services.AddTransient<INegocioRepository, NegocioRepository>();
                services.AddTransient<IImovelRepository, ImovelRepository>();

                //Adicionar politicas de controle. Para acesso do Administrador um chave de acesso.
                services.AddAuthorization(op =>  
                 op.AddPolicy("Adm", policy => 
                policy.RequireClaim("Chave", "00010")));

            services.AddControllersWithViews();
           services.AddRazorPages();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
               
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Imoveis}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            InicializaDb.Initialize(context); // Para alimentar o banco de dados ao iniciar a aplicação.
        }
    }
}
