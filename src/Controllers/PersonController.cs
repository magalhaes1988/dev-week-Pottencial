using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dev_week_Pottencial.src.Models;
using dev_week_Pottencial.src.Persistence;
using Microsoft.EntityFrameworkCore;
namespace dev_week_Pottencial.src.Controllers
{
    //Definição se é o controller da API
    [ApiController]
    //Controle de Rota
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        
        private DataBaseContext _context { get; set; }
        private readonly ILogger<PersonController> _logger;

        // public PersonController(ILogger<PersonController> logger)
        // {
        //     _logger = logger;
        // }

        public PersonController(DataBaseContext context)
        { 
          this._context = context;  
        }

        [HttpGet]
        public List<Person> GetPerson(){

            // Person pessoa = new Person(name: "Marcelo Magalhaes",idade: 33, cpf: 123456789);
            // Contracts novoContrato = new Contracts(tokenId: "0001234", valor: 50.99, pago: true);

            // pessoa.Contratos.Add(novoContrato);

            

            return _context.Pessoas.Include(c=>c.Contratos).ToList();
        }

        [HttpPost]
        public Person PostPerson([FromBody]Person pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return pessoa;
        }

        [HttpPut("{id}")]
        public string Update([FromRoute]int id, [FromBody]Person pessoa)
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();

            return "Dados do id " + id + "modificados";
        }

        [HttpDelete("{id}")]
        public string Delete([FromRoute]int id)
        {
            var result = _context.Pessoas.SingleOrDefault(p => p.Id == id);
            _context.Pessoas.Remove(result);
            _context.SaveChanges();
            return "Dados do id " + id + " apagados";
        }
 
    }
}