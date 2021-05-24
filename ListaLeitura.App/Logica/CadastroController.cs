using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using ListaLeitura.App.HTML;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public string Incluir(Livro livro)
        {

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return "O livro foi incluído";
        }

        public IActionResult ExibeFormulario()
        {
            var html = new ViewResult{ ViewName = "formulario"};
            return html;
        }

    }
}
