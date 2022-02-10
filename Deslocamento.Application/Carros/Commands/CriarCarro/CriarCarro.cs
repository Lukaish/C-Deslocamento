using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;

namespace DeslocamentoApp.Application.CarrosCommands
{
    public class CriarCarroCommand : IRequest<Carro>
    {
        public string Placa { get; set; }

        public string Descricao { get; set; }
    }
    public class CriarCarroCommandHandler :
        IRequestHandler<CriarCarroCommand, Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarCarroCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(
            CriarCarroCommand request,
            CancellationToken cancellationToken)
        {
            var carroInserir = new Carro(
                 request.Placa,
                 request.Descricao);

            var repositoryCarro =
                _unitOfWork.GetRepository<Carro>();

            repositoryCarro.Add(carroInserir);

            await _unitOfWork.CommitAsync();

            return carroInserir;
        }
    }
}