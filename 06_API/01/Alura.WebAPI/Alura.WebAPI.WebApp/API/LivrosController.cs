using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;

namespace Alura.WebAPI.WebApp.API
{
    [ApiController]
    [Route("api/[controller]")]
    // ControllerBase - Classe base para um CTRL MVC sem suporte a View.
    public class LivrosController : ControllerBase
    {
        // Controlador especifico para atender a API

        private readonly IRepository<Livro> _repo;

        public LivrosController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        #region Recuperar(int id)
        [HttpGet]
        public IActionResult ListaDeLivros()
        {
            var lista = _repo.All.Select(l => l.ToApi()).ToList(); // l.ToModel()

            return Ok(lista);
        }
        #endregion

        #region Recuperar(int id)
        [HttpGet("{id}")]
        public IActionResult Recuperar(int id)
        {
            var model = _repo.Find(id);

            if (model == null)
            {
                return NotFound();
            }
           // return Json(model.ToModel()); //- Controller
            return Ok(model.ToApi()); // ToModel // ControllerBase
            // retorna o codigo 200 e o objeto passado
        }
        #endregion

        #region ImagemCapa
        [HttpGet("{id}/capa")]
        public IActionResult ImagemCapa(int id)
        {
            byte[] img = _repo.All
                .Where(l => l.Id == id)
                .Select(l => l.ImagemCapa)
                .FirstOrDefault();
            if (img != null)
            {
                return File(img, "image/png");
            }
            return File("~/images/capas/capa-vazia.png", "image/png");
        }
        #endregion

        #region Incluir(LivroUpload model)
        [HttpPost]
        public IActionResult Incluir([FromBody]LivroUpload model) // trata a imagem da capa
        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();
                _repo.Incluir(livro);

                var uri = Url.Action("Recuperar", new { id = livro.Id }); // cria a URL

                return Created(uri, livro); // retorna o livro criado
                // código status '201' - o recurso foi realmente criado
            }
            return BadRequest(); // Código 400 - Requisição inválida
        }
        #endregion

        #region Alterar(LivroUpload model)
        [HttpPut]
        public IActionResult Alterar([FromBody]LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();
                if (model.Capa == null)
                {
                    livro.ImagemCapa = _repo.All
                                            .Where(l => l.Id == livro.Id)
                                            .Select(l => l.ImagemCapa)
                                            .FirstOrDefault();
                }
                _repo.Alterar(livro);

                return Ok(); // Cód: 200 // não está dizendo que foi criado, e não tem um código
                // especifico para alteração
            }
            return BadRequest(); // não deu certo - Código '400'
        }
        #endregion

        #region Remover(int id)
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _repo.Excluir(model);
            return NoContent(); // Ok, mas agora não tem conteudo nenhum - Cod: 204
            //Ok();
            // mostra que não tem mais conteudo apontando para este identificador
        }
        #endregion


    }
}
