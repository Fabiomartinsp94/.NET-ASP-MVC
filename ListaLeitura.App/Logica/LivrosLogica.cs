using Alura.ListaLeitura.App.Repositorio;
using Alura.ListaLeitura.App.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;
using ListaLeitura.App.HTML;
using System.Collections.Generic;

namespace ListaLeitura.App.Logica
{
    public class LivrosLogica
    {

        public static Task Detalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());
        }
        public static Task NovoLivro(HttpContext context)
        {
            var Livro = new Livro()
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("Autor").ToString()
            };
            var repo = new LivroRepositorioCSV();
            repo.Incluir(Livro);
            return context.Response.WriteAsync("Livro Incluido com Sucesso");
        }


        public static Task ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = Listagem("paraler", _repo.ParaLer.Livros);
            return context.Response.WriteAsync(html);
    
        }

        private static string Listagem(string tipo ,IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML(tipo);

            foreach (var livro in livros)
            {
                conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }

        
            return conteudoArquivo.Replace("#NOVO-ITEM#", "");
           
        }

        public static Task Lendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = Listagem("lendo" , _repo.Lendo.Livros);
            return context.Response.WriteAsync(html);
        }

        public static Task Lidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = Listagem("lido", _repo.Lidos.Livros);
            return context.Response.WriteAsync(html);
        }

        public static Task teste(HttpContext context)
        {
            return context.Response.WriteAsync("OK");
        }

    }
}
