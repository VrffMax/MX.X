using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MX.X.Domain.Split;
using static MX.X.Command.Multiply.MultiplySplitCommand;
using static MX.X.Command.Multiply.MultiplySplitCommand.MultiplyItem;

namespace MX.X.Command.Multiply
{
    public class MultiplySplitCommand
        : SplitCommand<MultiplyItem>
    {
        private readonly Regex whiteSpaceRegex = new Regex(@"\s+", RegexOptions.Compiled);
        private readonly Regex operationRegex = new Regex(@"[*/]?", RegexOptions.Compiled);
        private readonly Regex numberRegex = new Regex(@"[+-]?[1-9]\d*", RegexOptions.Compiled);

        public override Task<MultiplyItem> MapItemAsync(string value)
        {
            var operationNumber = whiteSpaceRegex.Replace(value, string.Empty);

            var operation = operationRegex.Match(operationNumber).Value switch
            {
                "*" => OperationType.Multiply,
                "/" => OperationType.Divide,
                _ => OperationType.Value
            };

            var number = int.Parse(numberRegex.Match(operationNumber).Value);

            return Task.FromResult(new MultiplyItem
            {
                Operation = operation,
                Number = number
            });
        }

        public class MultiplyItem
        {
            public enum OperationType
            {
                Value,
                Multiply,
                Divide
            }

            public OperationType Operation { get; set; }

            public int Number { get; set; }

        }
    }
}