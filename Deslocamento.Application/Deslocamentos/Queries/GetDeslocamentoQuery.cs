using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Application.Deslocamentos.Queries
{
    public class GetDeslocamentoQuery : IRequest<List<Deslocamento>>
    {
  
    }

    public class GetDeslocamentoQueryHandler : IRequestHandler<GetDeslocamentoQuery, List<Deslocamento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task <List<Deslocamento>> Handle(GetDeslocamentoQuery request, CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamento>();

            var deslocamento = await repositoryDeslocamento
                .GetAll()
                .ToListAsync(cancellationToken);

            return deslocamento;
        }
    }
}
