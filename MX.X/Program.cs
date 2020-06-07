using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using MX.X.Command.Number;

namespace MX.X
{
    public class Program
    {
        private readonly static IMediator _mediator = MediatorInit();

        public static async Task Main(string[] args)
        {
            bool allow;

            var expression = " - 1 + 2 - 3 + 4 - 5 ";

            do
            {
                allow = await _mediator.Send(new NumberRuleCommand { Expression = expression });

                if (!allow)
                {
                    break;
                }

                var result = await _mediator.Send(new NumberSplitCommand { Expression = expression });
            }
            while (false);

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
    }
}