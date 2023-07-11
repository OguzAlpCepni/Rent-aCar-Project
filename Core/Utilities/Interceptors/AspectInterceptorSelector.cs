﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>         // git classın attributelerini oku 
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)                                      // git metodun attributelerini oku 
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);                                             // ve onları bir listeye koy 

            return classAttributes.OrderBy(x => x.Priority).ToArray();                              // yalnız onların çalışma sırasını priortye göre sırala 
        }
    }
}
