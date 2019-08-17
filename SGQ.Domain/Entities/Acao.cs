using SGQ.Domain.Entities;
using System;

namespace SGQ.Domain.Entities
{
    class Acao : BaseEntity
    {
        public int Status { get; set; } //: pendente ou concluido
        public int TipoAcao { get; set; } //preventivo ou corretivo
        public DateTime Prazo { get; set; } // data para atendimento do plano
        public string ResponsavelExecucao { get; set; } //responsável pela execução: código do usuario
        public string Descricao { get; set; }


    }
}
