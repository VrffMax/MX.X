using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MX.X.Rule
{
    public abstract class RuleCommandHandler<T>
        : IRequestHandler<T, bool> where T : RuleCommand
    {
        private readonly IRule<T> _rule;

        public RuleCommandHandler(IRule<T> rule) =>
            _rule = rule;

        public Task<bool> Handle(T request, CancellationToken cancellationToken) =>
            _rule.IsMatch(request);
    }
}