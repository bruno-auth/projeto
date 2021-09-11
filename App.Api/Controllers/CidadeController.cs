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
    public class CidadeController : Controller
    {
        private ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet("ListaCidades")]
        public JsonResult ListaCidades()
        {
            return Json(new { Cidades = _service.listaCidades() });
        }

        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorId(Guid id)
        {
            return Json(new { Cidade = _service.BuscaPorId(id) });
        }

        [HttpGet("Salvar")]
        public JsonResult Salvar(string cep, string uf, string nome)
        {
            var obj = new Cidade
            {
                Cep = cep,
                Uf = uf,
                Nome = nome
            };
            _service.Salvar(obj);
            return Json(true);
        }

        [HttpGet("Remover")]
        public JsonResult Remover(Guid id)
        {
            _service.Remover(id);
            return Json(true);
        }
    }
}
