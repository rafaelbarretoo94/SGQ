using FluentValidation;

namespace SGQ.Domain.Validators.Atividade
{
    public class AtividadeAptaParaCadastroValidator : AbstractValidator<Entities.Atividade>
    {
        public AtividadeAptaParaCadastroValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome da atividade obrigatório");
        }
    }
}
