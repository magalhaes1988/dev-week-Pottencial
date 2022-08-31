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
 
            Person pessoa = new Person();
            Contracts novoContrato = new Contracts("abc123",50.23);
            pessoa.Name = "Marcelo";
            pessoa.Contratos.Add(novoContrato);

            return pessoa;
        }
 
    }
}