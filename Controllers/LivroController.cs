using BibliotecaApiVesp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiVesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {

        public Contexto Contexto { get; set; }
        public LivroController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;


        }


        [HttpGet]
        public List<Livro> Get()
        {
            return Contexto.Livros.ToList();
        }


        [HttpGet("{id}")]
        public Livro Get(int id)
        {
            return Contexto.Livros.First(e => e.IdLivro == id);
        }


        [HttpGet("autor/{autor}")]
        public List<Livro> filtrar(string autor)
        {
            return Contexto.Livros.Where(e => e.Autor == autor).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Livro>> Create(Livro Livro)
        {
            Livro.IdLivro = 0;
            Contexto.Livros.Add(Livro);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Livro.IdLivro, Livro });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Livro>> Update(Livro Livro)
        {
            Contexto.Livros.Update(Livro);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Livro.IdLivro, Livro });
        }

    }

}
