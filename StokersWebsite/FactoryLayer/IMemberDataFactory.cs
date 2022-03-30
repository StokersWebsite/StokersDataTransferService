using AbstractionLayer;

namespace FactoryLayer
{
    public static class IMemberDataFactory
    {
        public static IMembersData GetMemberData()
        {
            return new DataLayer.RegisterDAL();
        }
    }
}