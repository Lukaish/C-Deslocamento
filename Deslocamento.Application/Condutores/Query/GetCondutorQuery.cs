using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Application.Condutores.Query
{
    public class GetCondutorQuery : IRequest<List<Condutor>>
    {
    }

    public class GetCondutorQueryHandler :
        IRequestHandler<GetCondutorQuery, List<Condutor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCondutorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Condutor>> Handle(
            GetCondutorQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryCondutor =
                _unitOfWork.GetRepository<Condutor>();

            var condutores = await repositoryCondutor
                .GetAll()
                .ToListAsync(cancellationToken);

            return condutores;
        }
    }
}
