using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Queries;
using Shop.Framework.Commands;
using Shop.Framework.Queries;
using Shop.Framework.Resources;
using Shop.Framework.Web;

namespace Shop.EndPoints.WebUI.Controllers
{
    public class MasterController : BaseController
    {


        public MasterController(CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher, IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }



        //public IActionResult List()
        //{
        //    var masterCollection = _queryDispatcher.Dispatch<List<Master>>(new GetAllMasterQuery());
        //    return View(masterCollection);
        //}

        //public IActionResult Detail(long id)
        //{
        //    var master = _queryDispatcher.Dispatch<Master>(new GetByIdMasterQuery { MasterId = id });
        //    return View(master);
        //}



    }
}
