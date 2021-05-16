namespace AutofacCircDepResolution.Interfaces
{
    public interface IItemTestManager
    {
        void StandaloneTest();
        void Test(object[] items);
    }
}