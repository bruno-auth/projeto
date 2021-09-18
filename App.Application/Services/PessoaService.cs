using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private IRepositoryBase<Pessoa> _repository { get; set; }
        public PessoaService(IRepositoryBase<Pessoa> repository)
        {
            _repository = repository;
        }

        public Pessoa BuscaPorId(Guid id)
        {
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Pessoa> listaPessoas(string nome, int pesoMinimo, int pesoMaximo)
        {
            var query= _repository.Query(x => 
            x.Nome.ToUpper().Contains(nome.ToUpper()) 
            && (pesoMinimo == 0 || x.Peso >= pesoMinimo )
            && (pesoMaximo == 0 || x.Peso < pesoMaximo)) 
                .Select(p => new Pessoa
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Peso = p.Peso,
                    Cidade = new Cidade
                    {
                        Nome = p.Cidade.Nome
                    }
                }).OrderByDescending(x => x.Nome);
            return query.ToList();
        }

        public void Salvar(Pessoa obj)
        {
            if (String.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informe o  Nome!");
            }
            _repository.Save(obj);
            _repository.SaveChanges();
        }
    }
}
