using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Domain.Entities
{
    public class Deslocamento : BaseEntity
    {
        private decimal quilometragemInicial;

        public Deslocamento(long carroId, long clienteId, long condutorId, decimal quilometragemInicial, string observacao)
        {
            CarroId = carroId;
            ClienteId = clienteId;
            CondutorId = condutorId;
            QuilometragemInicial = quilometragemInicial;
            Observacao = observacao;
            DataHoraRegistro = DateTime.Now;

        }

        private Deslocamento()
        {

        }

        public DateTime DataHoraRegistro { get; private set; }

        public decimal QuilometragemInicial { get; private set; }

        public string Observacao { get; private set; }

        public long ClienteId { get; private set; }

        public long CarroId { get; private set; }

        public long CondutorId { get; private set; }

        public Cliente Cliente { get; private set; }

        public Carro Carro { get; private set; }

        public Condutor Condutor { get; private set; }

        public DateTime? DataHoraFim { get; private set; }
        public decimal QuilometragemFinal { get; private set; }

        public void FimDeslocamento(string observacao, decimal quilometragemFinal)
        {
            QuilometragemFinal = quilometragemFinal;
            DataHoraFim = DateTime.Now;
            Observacao = observacao;
        }



    }
}
