using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dev_week_Pottencial.src.Models;

namespace dev_week_Pottencial.src.Controllers
{
    //Definição se é o controller da API
    [ApiController]
    //Controle de Rota
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Person GetPerson(){
 
            Person pessoa = new Person(name: "Marcelo Magalhaes",idade: 33, cpf: 123456789);
            Contracts novoContrato = new Contracts(tokenId: "0001234", valor: 50.99, pago: true);

            pessoa.Contratos.Add(novoContrato);

            return pessoa;
        }

        [HttpPost]
        public Person PostPerson([FromBody]Person pessoa)
        {
            return pessoa;
        }

        [HttpPut("{id}")]
        public string Update([FromRoute]int id, [FromBody]Person pessoa)
        {
            return "Dados do id " + id + "modificados";
        }

        [HttpDelete("{id}")]
        public string Delete([FromRoute]int id)
        {
            return "Dados do id " + id + " apagados";
        }
 
    }
}