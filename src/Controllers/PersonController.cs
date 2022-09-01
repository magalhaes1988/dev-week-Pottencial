using System.Net;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using dev_week_Pottencial.src.Models;
using dev_week_Pottencial.src.Persistence;


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
        public ActionResult<List<Person>> GetPerson(){

            // Person pessoa = new Person(name: "Marcelo Magalhaes",idade: 33, cpf: 123456789);
            // Contracts novoContrato = new Contracts(tokenId: "0001234", valor: 50.99, pago: true);

            // pessoa.Contratos.Add(novoContrato);

            var result = _context.Pessoas.Include(c=>c.Contratos).ToList();

            if (!result.Any())
            {
                return NoContent();
            } else
            {
                return Ok(result);
            }

        }

        [HttpPost]
        public ActionResult<Person> PostPerson([FromBody]Person pessoa)
        {
            try
            {
                _context.Pessoas.Add(pessoa);
                _context.SaveChanges();

                return Created("Criado", pessoa);
            }
            catch(SystemException)
            {
                return BadRequest(new
                {
                    msg = "Nao Criado",
                    status = HttpStatusCode.BadRequest
                });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Object> Update([FromRoute]int id, [FromBody]Person pessoa)
        {
            
            try{
                var result = _context.Pessoas.SingleOrDefault(p => p.Id == id);
                if (result is null)
                {
                    return NotFound(new
                    {
                        msg = "Error",
                        status = HttpStatusCode.NotFound
                    });
                }
                _context.Pessoas.Update(pessoa);
                _context.SaveChanges();
            }
            catch (SystemException)
            {
                return BadRequest(new
                {
                    msg = "Error",
                    status = HttpStatusCode.BadRequest
                });
            }
            
            return new
            {
                msg = "Dados atualizados",
                status = HttpStatusCode.OK
        };
        }

        // [HttpDelete("{id}")]
        // public string Delete([FromRoute]int id)
        // {
        //     var result = _context.Pessoas.SingleOrDefault(p => p.Id == id);
        //     _context.Pessoas.Remove(result);
        //     _context.SaveChanges();
        //     return "Dados do id " + id + " apagados";
        // }

        [HttpDelete("{id}")]
        public ActionResult<Object> Delete([FromRoute] int id)
        {
            var result = _context.Pessoas.SingleOrDefault(p => p.Id == id);
            if(result is null)
                return BadRequest(new {
                    msg = "Conteudo inexistente, solicitação inválida",
                    status = HttpStatusCode.BadRequest
                });
            else{
                _context.Pessoas.Remove(result);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "Pessoa Deletada",
                    status = HttpStatusCode.OK
            });
            }
                

        }
 
    }
}