using AbstractionLayer;

namespace FactoryLayer
{
    public static class IActivityDataFactory
    {
        public static IActivityData Get()
        {
            return new DataLayer.AddActivityDAL();
        }
    }
}