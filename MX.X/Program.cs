using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using MX.X.Command.Multiply;
using MX.X.Command.Number;
using MX.X.Domain;

namespace MX.X
{
    public class Program
    {
        private readonly static IMediator _mediator = MediatorInit();

        public static async Task Main(string[] args)
        {
            var expression = "  -  10  *  -  20  /  30  +  10  *  -  20  /  30  +  10  *  -  20  /  30  ";

            var layers = new ILayer[]
            {
                new MultiplyLayer(_mediator)
            };

            var result = layers.Select(layer => layer.NextAsync(expression)).ToArray();

            foreach (var item in result)
            {
                Console.WriteLine(await item);
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
    }
}