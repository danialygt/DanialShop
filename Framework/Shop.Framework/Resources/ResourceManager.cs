using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Framework.Resources
{
    public class ResourceManager<TResource> : IResourceManager
    {
        private readonly IStringLocalizer<TResource> _stringLocalizer;

        public ResourceManager(IStringLocalizer<TResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }


        public string this[string name] { get => _stringLocalizer[name]; }
        public string this[string name, params string[] parameters] { get => _stringLocalizer[name, parameters]; }

        public string GetName(string name)
        {
            return _stringLocalizer.GetString(name);
        }

        public string GetName(string name, params string[] arguments)
        {
            return _stringLocalizer.GetString(name, arguments);
        }

    }
}
