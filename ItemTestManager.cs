namespace AutofacCircDepResolution
{
    using System;
    using AutofacCircDepResolution.Interfaces;

    public class ItemTestManager : IItemTestManager
    {
        private readonly Lazy<IItemManager> _itemManager;

        public ItemTestManager(Lazy<IItemManager> itemManager)
        {
            _itemManager = itemManager;
        }

        public void Test(object[] items)
        {
            Console.WriteLine("Items are okay.");
        }

        public void StandaloneTest()
        {
            var items = _itemManager.Value.GetItems();
            Test(items);

            Console.WriteLine("Finished Standalone Test.");
        }
    }
}
