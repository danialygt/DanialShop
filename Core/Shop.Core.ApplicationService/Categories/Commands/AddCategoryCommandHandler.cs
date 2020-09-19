using Shop.Core.Domain.Categories.Commands;
using Shop.Core.Domain.Categories.Entities;
using Shop.Core.Domain.Categories.Repositories;
using Shop.Core.Domain.Masters.Repositories;
using Shop.Core.Domain.Photos.Entities;
using Shop.Core.Resources.Resources;
using Shop.Framework.Commands;
using Shop.Framework.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.ApplicationService.Categories.Commands
{

    public class AddCategoryCommandHandler : CommandHandler<AddCategoryCommand>
    {
        private ICategoryCommandRepository _categoryCommandRepository;
        public AddCategoryCommandHandler(IResourceManager resourceManager, ICategoryCommandRepository categoryCommandRepository) : base(resourceManager)
        {
            _categoryCommandRepository = categoryCommandRepository;
        }


        public override CommandResult Handle(AddCategoryCommand command)
        {
            if (IsValid(command))
            {
                Category category  = new Category
                {
                    Name = command.Name,
                    ParentId = command.ParentId,
                    Photo = new Photo
                    {
                        Url = command.PhotoUrl
                    }
                };
                _categoryCommandRepository.Add(category);
                return Ok();
            }
            return Failure();
        }


        private bool IsValid(AddCategoryCommand command)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(command.Name))
            {
                AddError(SharedResource.Required, SharedResource.CategoryName);
                isValid = false;
            }
           
            if (string.IsNullOrEmpty(command.PhotoUrl))
            {
                AddError(SharedResource.Required, SharedResource.Photo);
                isValid = false;
            }
          

            return isValid;
        }
    }
}
