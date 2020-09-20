﻿using Shop.Core.Domain.Customers.Entities;
using Shop.Core.Domain.Orders.Commands;
using Shop.Core.Domain.Orders.Entities;
using Shop.Core.Domain.Orders.Repositories;
using Shop.Core.Resources.Resources;
using Shop.Framework.Commands;
using Shop.Framework.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Core.ApplicationService.Orders.Commands
{
    public class CheckOutCommandHandler : CommandHandler<CheckOutCommand>
    {
        private readonly IOrderCommandRepository _orderCommandRepository;
        public CheckOutCommandHandler(IResourceManager resourceManager,
            IOrderCommandRepository orderCommandRepository) : base(resourceManager)
        {
            _orderCommandRepository = orderCommandRepository;
        }

        public override CommandResult Handle(CheckOutCommand command)
        {
            if (IsValid(command))
            {
                Order order = new Order();
                order.OrderLines = command.Cart.Lines.Select(c => new OrderLine
                {
                    Count = c.Quantity,
                    MasterProductsId = c.Product.Id,
                    Price = c.Product.Price,
                    Discount = c.Product.Discount

                }).ToList();
                order.Customer = new Customer
                {
                    Address = command.Address,
                    City = command.City,
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    NationalCode = command.NationalCode,
                    Phone = command.Phone,
                    Provience = command.Provience
                };
                _orderCommandRepository.Add(order);
                command.OrderId = order.Id;
                return Ok();
            }
            return Failure();
        }

        private bool IsValid(CheckOutCommand command)
        {
            bool isValid = true;
            if (command.Cart.Lines.Count() == 0)
            {
                AddError(SharedResource.CartIsEmpty);
                isValid = false;
            }
            return isValid;
        }
    }
}
