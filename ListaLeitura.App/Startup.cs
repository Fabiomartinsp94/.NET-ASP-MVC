using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using ListaLeitura.App.MVC;
using ListaLeitura.App.Logica;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);

            //builder.MapRoute("Livros/ParaLer", LivrosLogica.ParaLer);
            //builder.MapRoute("Livros/Lendo", LivrosLogica.Lendo);
            //builder.MapRoute("Livros/Lidos", LivrosLogica.Lidos);
            //builder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.Detalhes);
            //builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", LivrosLogica.NovoLivro);
            //builder.MapRoute("Cadastro/ExibeFormulario", CadastroLogica.ExibeFormulario);
            //builder.MapRoute("Cadastro/Incluir", CadastroLogica.Incluir);
            var rotas = builder.Build();

            app.UseRouter(rotas);
        }
    }
}