using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MX.X.Domain.Rule
{
    public abstract class RuleCommandHandler<TRuleCommand>
        : IRequestHandler<TRuleCommand, IEnumerable<string>> where TRuleCommand : RuleCommand
    {
        private readonly IRule<TRuleCommand> _rule;

        public RuleCommandHandler(IRule<TRuleCommand> rule) =>
            _rule = rule;

        public Task<IEnumerable<string>> Handle(TRuleCommand request, CancellationToken cancellationToken) =>
            _rule.ExtractAsync(request);
    }
}