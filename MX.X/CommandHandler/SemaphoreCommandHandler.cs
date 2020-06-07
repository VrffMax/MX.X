using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MX.X.Command;

namespace MX.X.CommandHandler
{
    public class SemaphoreCommandHandler
        : IRequestHandler<SemaphoreCommand, bool>
    {
        public SemaphoreCommandHandler()
        {
        }

        public Task<bool> Handle(SemaphoreCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}