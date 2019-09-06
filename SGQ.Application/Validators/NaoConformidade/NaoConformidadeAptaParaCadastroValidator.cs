using FluentValidation;

namespace SGQ.Application.Validators.NaoConformidade
{
    public class NaoConformidadeAptaParaCadastroValidator : AbstractValidator<Models.NaoConformidadeViewModel>
    {
        public NaoConformidadeAptaParaCadastroValidator()
        {
            RuleFor(x => x.ProcessoId)
                .NotEmpty().WithMessage("O campo \"Processo\" da não conformidade é obrigatório.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo \"Descrição\" da não conformidade é obrigatório.")
                .Length(10, 300).WithMessage("O campo \"Descrição\" da não conformidade deve conter entre 10 e 300 caracteres.");

            RuleFor(x => x.AnaliseCausaRaiz)
                .NotEmpty().WithMessage("O campo \"Analise Causa Raiz\" da não conformidade é obrigatório.")
                .Length(10, 300).WithMessage("o campo \"Analise Causa Raiz\" da não conformidade deve conter entre 10 e 300 caracteres.");

            RuleFor(x => x.Evidencia)
                .NotEmpty().WithMessage("O campo \"Evidência\" da não conformidade é obrigatório.")
                .Length(10, 300).WithMessage("o campo \"Evidência\" da não conformidade deve conter entre 10 e 300 caracteres.");

            RuleFor(x => x.DataAvaliacao)
                .NotEmpty().WithMessage("O campo \"Data Avaliação\" da não conformidade é obrigatório.");
        }

    }
}
