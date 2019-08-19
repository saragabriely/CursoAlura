using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;
// Esse "Lista" é um alias para evitar que ocorra conflito entre o nome ListaLeitura
//  e o namespace "ListaLeitura"

namespace Alura.WebAPI.WebApp.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListasLeituraController : ControllerBase
    {
        private readonly IRepository<Livro> _repo;

        public ListasLeituraController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        private Lista CriaLista(TipoListaLeitura tipo)
        {
            return new Lista
            {
                Tipo = tipo.ParaString(),
                Livros = _repo.All
                              .Where(l => l.Lista == tipo)
                              .Select(l => l.ToApi())
                              .ToList()
                //Livros = _repo.All.Where(l => l.Lista == tipo).ToList()
            };
        }

        [HttpGet]
        public IActionResult TodasListas()
        {
            Lista paraLer   = CriaLista(TipoListaLeitura.ParaLer);
            Lista lendo     = CriaLista(TipoListaLeitura.Lendo);
            Lista lidos     = CriaLista(TipoListaLeitura.Lidos);

            var colecao = new List<Lista> { paraLer, lendo, lidos };

            return Ok(colecao);
        }

        [HttpGet("{tipo}")]
        public IActionResult Recuperar(TipoListaLeitura tipo)
        {
            var lista = CriaLista(tipo);
            return Ok(lista);
        }

    }
}
