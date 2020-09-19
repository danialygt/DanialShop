using Shop.Core.Domain.Masters.Commands;
using Shop.Core.Domain.Masters.Entities;
using Shop.Core.Domain.Masters.Repositories;
using Shop.Core.Domain.Photos.Entities;
using Shop.Core.Resources.Resources;
using Shop.Framework.Commands;
using Shop.Framework.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.ApplicationService.Masters.Commands
{
    public class AddMasterCommandHandler:CommandHandler<AddMasterCommand>
    {
        private IMasterCommandRepository _masterCommandRepository;
        public AddMasterCommandHandler(IResourceManager resourceManager, IMasterCommandRepository masterCommandRepository) : base(resourceManager)
        {
            _masterCommandRepository = masterCommandRepository;
        }


        public override CommandResult Handle(AddMasterCommand command)
        {
            if (IsValid(command))
            {
                Master master = new Master
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    Description = command.Description,
                    ShortDescription = command.ShortDescription,
                    MembershipDate = DateTime.Now,
                    Photo = new Photo
                    {
                        Url = command.PhotoUrl
                    }
                };
                _masterCommandRepository.Add(master);
                 return Ok();
            }
            return Failure();
        }


        private bool IsValid(AddMasterCommand command)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(command.FirstName))
            {
                AddError(SharedResource.Required, SharedResource.FirstName);
                isValid = false;
            }
            if (string.IsNullOrEmpty(command.LastName))
            {
                AddError(SharedResource.Required, SharedResource.LastName);
                isValid = false;
            }
            if (string.IsNullOrEmpty(command.PhotoUrl))
            {
                AddError(SharedResource.Required, SharedResource.Photo);
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

            return isValid;
        }
    }
}
