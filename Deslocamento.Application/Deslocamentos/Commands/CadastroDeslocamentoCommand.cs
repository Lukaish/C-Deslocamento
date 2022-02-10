using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Application.Deslocamentos.Commands
{
    public class CadastroDeslocamentoCommand : IRequest<Deslocamento>
    {
        public long CarroId { get; set; }
        public long ClienteId { get; set; }
        public long CondutorId { get; set; }
        public decimal QuilometragemInicial { get; set; }
        public string Observacao { get;  set; }
    }

    public class CadastrarDeslocamentoCommandHandler :
        IRequestHandler<CadastroDeslocamentoCommand, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CadastrarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(
            CadastroDeslocamentoCommand request,
            CancellationToken cancellationToken)
        {
            var deslocamentoInserir = new Deslocamento(
                 request.CarroId,
                 request.ClienteId,
                 request.CondutorId,
                 request.QuilometragemInicial,
                 request.Observacao);

            var repositoryDeslocamento =
                _unitOfWork.GetRepository<Deslocamento>();

            repositoryDeslocamento.Add(deslocamentoInserir);

            await _unitOfWork.CommitAsync();

            return deslocamentoInserir;
        }
    }



}
