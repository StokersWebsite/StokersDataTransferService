using AbstractionLayer;
using Datalayer;

namespace FactoryLayer
{
    public static class IActivityFactory
    {
        public static IActivity Get(StokersContext context)
        {
            return new ActivityDAL(context);
        }
    }
}