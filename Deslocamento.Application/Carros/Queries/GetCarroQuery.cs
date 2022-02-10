using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentosApi.WebAPI.Controllers
{
    
        public class GetCarroQuery : IRequest<List<Carro>>
        {
            
        }

        public class GetCarroQueryHandler : IRequestHandler<GetCarroQuery,List<Carro>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCarroQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<Carro>> Handle(GetCarroQuery request, CancellationToken cancellationToken)
            {
                var repositoryCarro = _unitOfWork.GetRepository<Carro>();

                var car = await repositoryCarro
                    .GetAll()
                    .ToListAsync(cancellationToken);

                return car;
        }
     }
}