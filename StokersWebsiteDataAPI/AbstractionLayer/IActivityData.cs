using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLayer;

namespace AbstractionLayer
{
    public interface IActivityData
    {
        public List<ActivityDTO> Read();
        public int AddAcitivtyDAL(ActivityDTO activityDTO);
    }
}
