using MediatR;
using MX.X.Domain;

namespace MX.X.Command.Number
{
    public class NumberLayer
        : Layer<NumberRuleCommand, NumberSplitCommand, NumberAggregateCommand, NumberEmbedCommand, int, int>
    {
        public NumberLayer(IMediator mediator)
            : base(mediator)
        {
        }
    }
}