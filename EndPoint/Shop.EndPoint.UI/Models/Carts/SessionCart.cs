using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shop.Core.Domain.Carts;
using Shop.Core.Domain.Masters.Entities;
using Shop.EndPoints.WebUI.Infrastructures;
using System;


namespace Shop.EndPoints.WebUI.Models.Carts
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.session = session;
            return cart;
        }


        [JsonIgnore]
        public ISession session { get; set; }



        public override void AddItem(MasterProduct product, int quantity)
        {
            base.AddItem(product, quantity);
            session.SetJson("Cart", this);

        }

        public override void RemoveLine(MasterProduct product, int quantity)
        {
            base.RemoveLine(product, quantity);
            session.SetJson("Cart", this);
            ////////

        }


        public override void Clear()
        {
            base.Clear();
            session.Remove("Cart");
        }



    }
}
