using System;
using Castle.Core.Interceptor;

namespace StructureMapAopNotify.CastleDynamicProxy
{
    public class NotifyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            // let the original call go through first, so we can notify *after*
            invocation.Proceed();

            if (invocation.Method.Name.StartsWith("set_"))
            {
                string propertyName = invocation.Method.Name.Substring(4);
                RaisePropertyChangedEvent(invocation, propertyName, invocation.TargetType);
            }
        }

        void RaisePropertyChangedEvent(IInvocation invocation, string propertyName, Type type)
        {
            // get the field storing the delegate list that are stored by the event.
            var methodInfo = type.GetMethod("RaisePropertyChanged");

            if (methodInfo == null)
            {
                if (type.BaseType != null)
                    RaisePropertyChangedEvent(invocation, propertyName, type.BaseType);
            }
            else // info != null
            {
                methodInfo.Invoke(invocation.InvocationTarget, new object[] {propertyName});
            }
        }
    }
}