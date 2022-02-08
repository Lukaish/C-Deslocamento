using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Application.Carros.Commands.AdicionarCarro
{
    public class AdicionarCarroCommand : IRequest<Carro>
    {
        public string Descricao { get; set; }

        public string Placa { get; set; }
    }

    public class AdicionarCarroCommandHandler : IRequestHandler<AdicionarCarroCommand, Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarCarroCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(AdicionarCarroCommand request, CancellationToken cancellationToken)
        {
            var adcicionarCarro = new Carro(request.Placa, request.Descricao);

            var repositoryDocumento = _unitOfWork.GetRepository<Carro>();

            repositoryDocumento.Add(adcicionarCarro);

            await _unitOfWork.CommitAsync();

            return adcicionarCarro;
        }
    }
}
