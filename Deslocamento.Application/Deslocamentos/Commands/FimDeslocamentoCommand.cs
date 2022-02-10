using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Application.Deslocamentos.Commands
{
    public class FimDeslocamento : IRequest
    {
        public long DeslocamentoId { get; set; }
        public string Observacao { get; set; }
        public decimal QuilometragemFinal { get; set; }
    }

    public class FimDeslocamentoCommandHandler   : IRequestHandler<FimDeslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FimDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task <Unit> IRequestHandler<FimDeslocamento, Unit>.Handle(FimDeslocamento request, CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamento>();
            var deslocamento = await repositoryDeslocamento
               .FindBy(d => d.Id == request.DeslocamentoId)
               .FirstAsync(cancellationToken);

            deslocamento.FimDeslocamento(request.Observacao, request.QuilometragemFinal);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
