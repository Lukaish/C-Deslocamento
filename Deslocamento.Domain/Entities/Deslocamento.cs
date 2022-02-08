using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Domain.Entities
{
    public class Deslocamento : BaseEntity
    {
        public Deslocamento(double quilometragemInicial, string observacao)
        {
            QuilometragemInicial = quilometragemInicial;
            Obersavacao = observacao;
            DataHoraRegistro = DateTime.Now;
        }

        public Deslocamento()
        {
           
        }

        public DateTime DataHoraRegistro { get; private set; }

        public string Obersavacao { get; private set; }

        public double QuilometragemInicial { get; private set; }

        public long ClienteId { get; private set; }

        public long CarroId { get; private set; }

        public long CondutorId { get; private set; }

        public Cliente Cliente { get; private set; }

        public Carro Carro { get; private set; }

        public Condutor Condutor { get; private set; }




         


    }
}
