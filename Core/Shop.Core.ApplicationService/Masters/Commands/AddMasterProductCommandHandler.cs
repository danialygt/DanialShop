using Shop.Core.Domain.Masters.Commands;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Repositories;
using Shop.Core.Domain.Photos.Entities;
using Shop.Core.Resources.Resources;
using Shop.Framework.Commands;
using Shop.Framework.Resources;
using System.Collections.Generic;

namespace Shop.Core.ApplicationService.Masters.Commands
{
    public class AddMasterProductCommandHandler : CommandHandler<AddMasterProductCommand>
    {
        private readonly IMasterProductCommandRepository _commandRepository;
        public AddMasterProductCommandHandler(IResourceManager resourceManager, IMasterProductCommandRepository commandRepository) : base(resourceManager)
        {
            _commandRepository = commandRepository;
        }

        public override CommandResult Handle(AddMasterProductCommand command)
        {
            if (IsValid(command))
            {
                var photos = new List<Photo>();

                foreach (var item in command.Photos)
                {
                    photos.Add(new Photo() { Url = item});
                }


                MasterProduct masterProduct = new MasterProduct
                {
                    Name = command.Name,
                    Price = command.Price,
                    Discount = command.Discount,
                    Description = command.Description,
                    ShortDescription = command.ShortDescription,
                    MasterId = command.MasterId,
                    CategoryId = command.CategoryId,
                    Photos = photos
                };
                _commandRepository.Add(masterProduct);
                return Ok();
            }
            return Failure();
        }


        private bool IsValid(AddMasterProductCommand command)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(command.Name))
            {
                AddError(SharedResource.Required, SharedResource.ProductName);
                isValid = false;
            }
            if (string.IsNullOrEmpty(command.Description))
            {
                AddError(SharedResource.Required, SharedResource.Description);
                isValid = false;
            }
            if (string.IsNullOrEmpty(command.ShortDescription))
            {
                AddError(SharedResource.Required, SharedResource.ShortDescription);
                isValid = false;
            }
            //if (command.Price == null)
            //{
            //    AddError(SharedResource.Required, SharedResource.Price);
            //    isValid = false;
            //}
            //if (command.Discount == null)
            //{
            //    AddError(SharedResource.Required, SharedResource.Discount);
            //    isValid = false;
            //}
            //if (command.MasterId == null)
            //{
            //    AddError(SharedResource.Required, SharedResource.Master);
            //    isValid = false;
            //}

                                          
            return isValid;
        }


    }
}
