using SGQ.Domain.Entities;

namespace SGQ.Application.Models
{
    public class AtividadeModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }

        public static Atividade ConverterViewParaEntity(AtividadeModel atividadeModel)
        {
            Atividade atividade = new Atividade();
            atividade.Nome = atividadeModel.Nome;
            atividade.Descricao = atividadeModel.Descricao;
            atividade.Ordem = atividadeModel.Ordem;

            return atividade;
        }
    }
}
