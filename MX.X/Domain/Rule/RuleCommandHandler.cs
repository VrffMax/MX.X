using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MX.X.Domain.Rule
{
    public abstract class RuleCommandHandler<T>
        : IRequestHandler<T, IEnumerable<string>> where T : RuleCommand
    {
        private readonly IRule<T> _rule;

        public RuleCommandHandler(IRule<T> rule) =>
            _rule = rule;

        public Task<IEnumerable<string>> Handle(T request, CancellationToken cancellationToken) =>
            _rule.IsMatchAsync(request);
    }
}