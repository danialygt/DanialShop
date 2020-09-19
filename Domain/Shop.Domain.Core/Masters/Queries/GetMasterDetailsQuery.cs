using Shop.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Masters.Queries
{
    public class GetByIdMasterQuery:IQuery
    {
        public long MasterId { get; set; }
    }
}
