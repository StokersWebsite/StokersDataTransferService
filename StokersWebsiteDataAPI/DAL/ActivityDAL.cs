using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLayer;
using AbstractionLayer;

namespace Datalayer
{
    public class ActivityDAL : IActivity
    {
        private readonly StokersContext stokersContext;
        public ActivityDAL(StokersContext context)
        {
            stokersContext = context;
        }
        public void AddActivity(ActivityDTO activity)
        {
            stokersContext.Activity.Add(activity);
            stokersContext.SaveChanges();
        }

        public List<ActivityDTO> GetActivities()
        {
           return stokersContext.Activity.ToList();
        }
    }
}
