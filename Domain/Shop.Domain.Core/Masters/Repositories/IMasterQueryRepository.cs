﻿using Shop.Core.Domain.Masters.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Domain.Masters.Repositories
{
    public interface IMasterQueryRepository
    {
        List<Master> GetAll();

        Master GetById(long id);

    }
}
