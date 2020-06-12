using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using MX.X.Command.Number;
using MX.X.Domain.Rule;

namespace MX.X
{
    public class Program
    {
        private readonly static IMediator _mediator = MediatorInit();

        public static async Task Main(string[] args)
        {
            var expression = " - 1 + 2 - 3 + 4 - 5 ";

            foreach(var rule in GetRules(expression))
            {
                if (!await _mediator.Send(new NumberRuleCommand { Expression = expression }))
                {
                    continue;
                }

                var values = await _mediator.Send(new NumberSplitCommand { Expression = expression });
                var result = await _mediator.Send(new NumberAggregateCommand { Values = values });

                Console.WriteLine(result);
            }

            Console.WriteLine(nameof(Task.CompletedTask));
        }

        private static IMediator MediatorInit()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return type => componentContext.Resolve(type);
            });

            builder
                .RegisterAssemblyTypes(typeof(NumberRuleCommand).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            return builder.Build().Resolve<IMediator>();
        }

        private static IEnumerable<RuleCommand> GetRules(string expression)
        {
            yield return new NumberRuleCommand { Expression = expression };
        }
    }
}