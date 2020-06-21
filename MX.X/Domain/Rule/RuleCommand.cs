using System.Collections.Generic;
using MediatR;

namespace MX.X.Domain.Rule
{
    public abstract class RuleCommand
        : IExpression, IRequest<IEnumerable<string>>
    {
        public string Expression { get; set; }
    }
}