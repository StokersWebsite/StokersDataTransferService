using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLayer;

namespace AbstractionLayer
{
    public interface IActivity
    {
        public void AddActivity(ActivityDTO activityDTO);
        public List<ActivityDTO> GetActivities();
    }
}
