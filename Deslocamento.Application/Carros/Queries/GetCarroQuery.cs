using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentosApi.WebAPI.Controllers
{
    
        public class GetCarroQuery : IRequest<Carro>
        {
            public long CarroId { get; set; }
        }

        public class GetCarroQueryHandler : IRequestHandler<GetCarroQuery, Carro>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCarroQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Carro> Handle(GetCarroQuery request, CancellationToken cancellationToken)
            {
                var repositoryDocumento = _unitOfWork.GetRepository<Carro>();

                var documento = await repositoryDocumento
                    .FindBy(d => d.Id == request.CarroId)
                    .FirstAsync(cancellationToken);

                return documento;
            }
        }
}