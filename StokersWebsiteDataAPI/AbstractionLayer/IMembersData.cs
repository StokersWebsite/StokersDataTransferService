using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLayer;

namespace AbstractionLayer
{
    public interface IMembersData
    {
        public List<MemberDTO> Read();
        public int RegisterMember(MemberDTO memberDTO);
    }
}
