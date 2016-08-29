using System;
using System.Collections.Generic;
using Sms.Data.Interfaces;

namespace Sms.Data
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, Func<object>> services;

        public ServiceLocator()
        {
            this.services = new Dictionary<Type, Func<object>>();
        }

        public void Register<T>(Func<T> resolver)
        {
            this.services[typeof(T)] = () => resolver();
        }

        public T Resolve<T>()
        {
            return (T)this.services[typeof(T)]();
        }
    }
}