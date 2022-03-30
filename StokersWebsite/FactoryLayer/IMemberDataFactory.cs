using AbstractionLayer;

namespace FactoryLayer
{
    public static class IMemberDataFactory
    {
        public static IMembersData Get()
        {
            return new DataLayer.RegisterDAL();
        }
    }
}