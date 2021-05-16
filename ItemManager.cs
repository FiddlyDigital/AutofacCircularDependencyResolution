
namespace AutofacCircDepResolution
{
    using System;
    using AutofacCircDepResolution.Interfaces;

    public class ItemManager : IItemManager
    {
        object[] _items;
        private readonly Lazy<IItemTestManager> _itemTestManager;

        public ItemManager(Lazy<IItemTestManager> itemTestManager)
        {
            _itemTestManager = itemTestManager;
            _items = new object[] { "5", "2", "4", "3", "1" };
        }

        public object[] GetItems()
        {
            return _items;
        }

        public void LoadAndTest()
        {
            var items = GetItems();
            Console.WriteLine("Looking over:");
            foreach (var o in items)
            {
                Console.WriteLine(o.ToString());
            }

            _itemTestManager.Value.Test(items);

            Console.WriteLine("Finished Load and Test.");
        }
    }
}
