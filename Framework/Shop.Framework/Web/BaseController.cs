using Microsoft.AspNetCore.Mvc;
using Shop.Framework.Commands;
using Shop.Framework.Queries;
using Shop.Framework.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Framework.Web
{
    public class BaseController:Controller
    {
        protected readonly CommandDispatcher _commandDispatcher;
        protected readonly QueryDispatcher _queryDispatcher;
        protected readonly IResourceManager _resourceManager;


        public BaseController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _resourceManager = resourceManager;
        }
    }
}
