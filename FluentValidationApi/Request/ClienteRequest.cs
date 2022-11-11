using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace FluentValidationApi.Request
{
    public class ClienteRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public string[] Tags { get; set; }

        public IEnumerable<string> Validate()
        {
            ClienteRequestValidation validator = new ClienteRequestValidation();
            ValidationResult results = validator.Validate(this);
            var erros = new List<string>();

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    erros.Add("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
            return erros;
        }

    }
}
