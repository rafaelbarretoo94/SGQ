using FluentValidation;

namespace SGQ.Application.Validators
{
    public class NaoConformidadeCadastroValidator : AbstractValidator<Models.NaoConformidadeModel>
    {

        public NaoConformidadeCadastroValidator()
        {

             //RuleFor(x => x.Nome)
             //   .NotEmpty().WithMessage("O campo \"Nome\" da atividade é obrigatório.")
             //   .Length(10, 100).WithMessage("O nome da atividade deve conter entre 10 e 100 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo \"Descrição\" da atividade é obrigatório.")
                .Length(10, 3000).WithMessage("A descrição da atividade deve conter entre 10 e 3000 caracteres.");
        }

    }
}
