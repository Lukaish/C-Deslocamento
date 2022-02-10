using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Application.Clientes.Queries
{
    public class GetClientQuery : IRequest<List<Cliente>>
    {
        
    }

    public class GetClientQueryHandler :
        IRequestHandler<GetClientQuery, List<Cliente>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Cliente>> Handle(
            GetClientQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryCliente =
                _unitOfWork.GetRepository<Cliente>();

            var clientes = await repositoryCliente
                .GetAll()
                .ToListAsync(cancellationToken);

            return clientes;
        }
    }
}
