using FluentValidation;
using System;
namespace FluentValidationApi.Request
{
    public class ClienteRequestValidation : AbstractValidator<ClienteRequest>
    {
        public ClienteRequestValidation()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Campo ID não pode ser vazio ou nulo");
            RuleFor(x => x.Id).GreaterThan(6).WithMessage("O Id precisa ser maior que 6");
            RuleFor(x => x.Id).LessThan(99).WithMessage("O Id precisa ser menor que 99");
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("Campo Nome não pode ser vazio ou nulo");
            RuleFor(x => x.Nome).MinimumLength(3).WithMessage("O nome precisa ter mais de 3 caracteres");
            RuleFor(x => x.Cpf).NotNull().NotEmpty().WithMessage("Campo CPF não pode ser vazio ou nulo");
            RuleFor(x => x.Cpf).Length(11).WithMessage("O cpf precisa ter 11 caracteres");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Campo Email não pode ser vazio ou nulo");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Formato de e-mail inválido");
            RuleFor(x => x.Nascimento).NotNull().NotEmpty().WithMessage("Campo Nascimento não pode ser vazio ou nulo");
            RuleFor(x => x.Nascimento).LessThan(Convert.ToDateTime("2010-01-01")).WithMessage("Só são aceitas pessoas nascidas antes de 2010");
            RuleFor(x => x.Tags).NotNull().NotEmpty().WithMessage("Campo Tags não pode ser vazio ou nulo");
            RuleForEach(x => x.Tags).ChildRules(x =>
            {
                x.RuleFor(t => t).MinimumLength(5).WithMessage("Cada tag precisa ter mais de 5 caracteres");
            });
        }
    }
}
