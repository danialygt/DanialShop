using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Framework.Queries
{
    public class QueryDispatcher
    {

        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Dispatch<TResult>(IQuery query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(TResult) };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _serviceProvider.GetService(handlerType);
            TResult result = handler.Handle((dynamic)query);
            return result;
        }

    }
}
