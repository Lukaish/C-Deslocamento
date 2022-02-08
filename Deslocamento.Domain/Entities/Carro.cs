using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Domain.Entities
{
    public class Carro : BaseEntity
    {
        public Carro(string placa, string descricao)
        {
            Descricao = descricao;

            Placa = placa;
        }

        public string Placa { get; private set;}

        public string Descricao { get; private set;}

        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();
        private readonly List<Deslocamento> _deslocamentos = new();
    }
}
