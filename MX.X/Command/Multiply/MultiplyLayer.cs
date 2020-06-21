using MediatR;
using MX.X.Domain;
using static MX.X.Command.Multiply.MultiplySplitCommand;

namespace MX.X.Command.Multiply
{
    public class MultiplyLayer
        : Layer<MultiplyRuleCommand, MultiplySplitCommand, MultiplyAggregateCommand, MultiplyEmbedCommand, MultiplyItem, int>
    {
        public MultiplyLayer(IMediator mediator)
            : base(mediator)
        {
        }
    }
}