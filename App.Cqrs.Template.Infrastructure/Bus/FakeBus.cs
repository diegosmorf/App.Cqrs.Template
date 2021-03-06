﻿using App.Cqrs.Core.Bus;
using App.Cqrs.Core.Command;
using App.Cqrs.Core.Event;
using Autofac;
using System;
using System.Collections.Generic;

namespace App.Cqrs.Template.Infrastructure.Bus
{
    public class FakeBus : IBus
    {
        private readonly IComponentContext context;

        public FakeBus(IComponentContext context)
        {
            this.context = context;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = context.Resolve<ICommandHandler<TCommand>>();
            handler.Handle(command);
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(@event));
            }

            var eventHandlers = context.ResolveNamed<IEnumerable<IEventHandler<IEvent>>>(@event.GetType().Name);

            foreach (var handler in eventHandlers)
            {
                handler.Handle(@event);
            }
        }
    }
}