using GovukRegistersApiClientNet.Implementation.Interfaces;
using GovukRegistersApiClientNet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GovukRegistersApiClientNet.Implementation.Commands
{
    public class AddItemCommandHandler : IRsfCommandHandler
    {
        private readonly IItemFactory _itemFactory;

        public AddItemCommandHandler(IItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public string GetName()
        {
            return "add-item";
        }

        public void Parse(string[] rsfComponents, IDataStore dataStore)
        {
            var json = rsfComponents[1];

            dataStore.AddItem(_itemFactory.CreateItem(json));
        }
    }
}
