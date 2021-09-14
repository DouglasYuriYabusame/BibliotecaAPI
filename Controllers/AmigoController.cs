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
    public class AmigoController : ControllerBase
    {

        public Contexto Contexto { get; set; }
        public AmigoController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;


        }


        [HttpGet]
        public List<Amigo> Get()
        {
            return Contexto.Amigos.ToList();
        }


        [HttpGet("{id}")]
        public Amigo Get(int id)
        {
            return Contexto.Amigos.First(e => e.IdAmigo == id);
        }


        [HttpGet("cidade/{idcidade}")]
        public List<Amigo> filtrar(int idcidade)
        {
            return Contexto.Amigos.Where(e => e.IdCidade == idcidade).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Amigo>> Create(Amigo Amigo)
        {
            Amigo.IdAmigo = 0;
            Contexto.Amigos.Add(Amigo);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Amigo.IdAmigo, Amigo });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Amigo>> Update(Amigo Amigo)
        {
            Contexto.Amigos.Update(Amigo);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Amigo.IdAmigo, Amigo });
        }

    }

}
