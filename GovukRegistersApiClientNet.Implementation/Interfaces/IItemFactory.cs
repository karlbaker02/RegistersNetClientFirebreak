using GovukRegistersApiClientNet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovukRegistersApiClientNet.Implementation.Interfaces
{
    public interface IItemFactory
    {
        Item CreateItem(string json);
    }
}
