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
    public class CidadeController : ControllerBase
    {


        public Contexto Contexto { get; set; }
        public CidadeController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;


        }


        [HttpGet]
        public List<Cidade> Get()
        {
            return Contexto.Cidades.ToList();
        }


        [HttpGet("{id}")]
        public Cidade Get(int id)
        {
            return Contexto.Cidades.First(e => e.IdCidade == id);
        }


        [HttpGet("uf/{uf}")]
        public List<Cidade> filtrar(String uf)
        {
            return Contexto.Cidades.Where(e => e.Uf == uf).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Cidade>> Create(Cidade cidade)
        {
            cidade.IdCidade = 0;
            Contexto.Cidades.Add(cidade);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = cidade.IdCidade, cidade });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Cidade>> Update(Cidade cidade)
        {
            Contexto.Cidades.Update(cidade);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = cidade.IdCidade, cidade });
        }

    }

}