using MediatR;

namespace MX.X.Domain.Rule
{
    public abstract class RuleCommand
        : IExpression, IRequest<bool>
    {
        public string Expression { get; set; }
    }
}