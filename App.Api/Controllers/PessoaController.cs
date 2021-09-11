using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        private IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet("ListaPessoas")]
        public JsonResult ListaPessoas(string nome, int pesoMinimo, int pesoMaximo)
        {
            return Json(new { Pessoas = _service.listaPessoas(nome, pesoMinimo, pesoMaximo) });
        }

        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorId(Guid id)
        {
            return Json(new { Pessoa = _service.BuscaPorId(id) });
        }

        [HttpGet("Salvar")]
        public JsonResult Salvar(string nome, int peso, DateTime dataNascimento, bool ativo, Guid cidadeId)
        {
            var obj = new Pessoa
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                Peso = peso,
                Ativo = ativo,
                CidadeId = cidadeId
            };
            _service.Salvar(obj);
            return Json(true);
        }
    }
}
