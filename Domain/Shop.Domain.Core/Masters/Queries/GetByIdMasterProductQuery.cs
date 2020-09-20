using Shop.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Masters.Queries
{
    public class GetByIdMasterProductQuery:IQuery
    {
        public int ProductId { get; set; }
    }
}
