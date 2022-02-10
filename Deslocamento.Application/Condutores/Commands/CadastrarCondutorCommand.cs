using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;

namespace DeslocamentoApi.Application.Condutores.Commands
{
    public class CadastrarCondutorCommand : IRequest<Condutor>
    {
        public string Nome { get; set; }

        public string Email { get; set; }
    }

    public class CadastrarCondutorCommandHandler : IRequestHandler<CadastrarCondutorCommand, Condutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CadastrarCondutorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Condutor> Handle(
            CadastrarCondutorCommand request,
            CancellationToken cancellationToken)
        {
            var condutorInserir = new Condutor(
                 request.Nome,
                 request.Email);

            var repositoryCondutor =
                _unitOfWork.GetRepository<Condutor>();

            repositoryCondutor.Add(condutorInserir);

            await _unitOfWork.CommitAsync();

            return condutorInserir;
        }
    }
}
