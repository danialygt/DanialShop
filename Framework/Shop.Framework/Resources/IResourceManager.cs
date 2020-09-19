using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Framework.Resources
{
    public interface IResourceManager
    {
        
        string GetName(string name);
        string GetName(string name, params string[] arguments);
        string this[string name] { get; }
        string this[string name, params string[] parameters] { get; }
    }
}
