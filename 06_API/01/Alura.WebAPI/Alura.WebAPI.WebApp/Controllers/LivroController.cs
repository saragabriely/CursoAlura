using System.Linq;
using Alura.ListaLeitura.Persistencia;
using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.WebApp.Controllers
{
    [Authorize] // o usuário precisa estar logado/identificado
    public class LivroController : Controller
    {
        private readonly IRepository<Livro> _repo;

        public LivroController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View(new LivroUpload());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Novo(LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                _repo.Incluir(model.ToLivro());
                return RedirectToAction("Index", "Home"); // volta para a pagina inicial 
            }
            return View(model); // volta para o formulário com o modelo
        }

        [HttpGet]
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

        // Esse metodo também pode ser usado como uma Action!
        // Como o retorno é o objeto, ele pode ser convertido em JSON
        public Livro RecuperaLivro(int id)
        {
            return _repo.Find(id);
            /*
             var livro = _repo.Find(id);
             if (livro == null)
            {
                return NotFound(); // NÃO É POSSÍVEL UTILIZAR O NOTFOUND NESSE MÉTODO
            }
            return livro; 
             */

            // É possível chamar esse método a partir do navegador, porém, 
            // a imagem retornará em forma de texto, e caso seja inserido um código(id)
            // inexistente, o navegador retornará a resposta da pesquisa anterior.
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var model = RecuperaLivro(id); //_repo.Find(id);
            if (model == null)
            {
                return NotFound(); // 404
            }
            return View(model.ToModel()); 
            // a View é quem entrega uma instancia de ViewResult (HTML)
            // e o estágio de executar o executável, ele verifica o filho "é viewresul?"
            // caso seja, o Razor será chamado, a aplicação será renderizada - será 
            // feito um merge do HTML com o modelo e será gerado um HTML resultante,
            // e isso será entregue como resposta da requisição.
        }

        /*
        [HttpGet]
        public IActionResult DetalhesSemHTML(int id)
        {
            var model = RecuperaLivro(id); //_repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            // retorno sem HTML - foramto JSON
            return Json(model.ToModel()); // retorna um JsonResult
        } */

        // Nesse método, é possivel utilizar o NOTFOUND
        public ActionResult<LivroUpload> DetalhesJson(int id)
        {
            var model = RecuperaLivro(id);
            if(model == null)
            {
                return NotFound();
            }
            return model.ToModel(); // a capa retorna como NULL
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detalhes(LivroUpload model)
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
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _repo.Excluir(model);
            return RedirectToAction("Index", "Home");
        }
    }
}