﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using MX.X.Command;

namespace MX.X
{
    public class Program
    {
        private readonly static IMediator _mediator = MediatorInit();

        public static async Task Main(string[] args)
        {
            var result = await _mediator.Send(new SemaphoreCommand());

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
                .RegisterAssemblyTypes(typeof(SemaphoreCommand).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            return builder.Build().Resolve<IMediator>();
        }
    }
}