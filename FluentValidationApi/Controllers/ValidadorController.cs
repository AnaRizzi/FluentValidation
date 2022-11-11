using FluentValidationApi.Request;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FluentValidationApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValidadorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("A API está funcionando, agora tente passar os parâmetros!");
        }

        [HttpGet("{id}/{nome}")]
        public IActionResult Get(int id, string nome)
        {
            return Ok($"{nome}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteRequest request)
        {
            ClienteRequestValidation validator = new ClienteRequestValidation();

            ValidationResult results = validator.Validate(request);

            if (!results.IsValid)
            {
                var erros = new List<string>();
                foreach (var failure in results.Errors)
                {
                    erros.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }

                //string allMessages = results.ToString(" ~ "); //outra forma de passar todos os erros

                return BadRequest(erros);
            }

            return Ok($"Valores passados: {request.Nome}, CPF: {request.Cpf}, nascimento: {request.Nascimento}");
        }

        [HttpPost("OutraValidacao")]
        public IActionResult PostValidacaoNaClasse([FromBody] ClienteRequest request)
        {
            var erros = request.Validate();
            if (erros.Count() != 0)
            {
                return BadRequest(erros);
            }

            return Ok($"Valores passados: {request.Nome}, CPF: {request.Cpf}, nascimento: {request.Nascimento}");
        }
    }
}
