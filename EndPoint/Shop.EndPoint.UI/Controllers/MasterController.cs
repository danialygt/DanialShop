using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Domain.Masters.Dto;
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



        public IActionResult List()
        {
            var masterCollection = _queryDispatcher.Dispatch<List<DtoMaster>>(new GetAllMasterQuery());
            if (masterCollection != null)
            {
                return View(masterCollection);
            }
            return NotFound();
        }

        public IActionResult Detail(long id)
        {
            var master = _queryDispatcher.Dispatch<DtoMasterDetail>(new GetByIdMasterQuery { MasterId = id });
            if (master != null)
            {
                return View(master);
            }
            return NotFound();
        }



    }
}
