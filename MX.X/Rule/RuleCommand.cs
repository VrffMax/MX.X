using MediatR;

namespace MX.X.Rule
{
    public abstract class RuleCommand
        : IRequest<bool>
    {
        public string Expression { get; set; }
    }
}