using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Repositories.CustomersRepositories
{
    interface IMembershipTypeRepository
    {
        IEnumerable<MembershipType> GetMembershipTypes();
        MembershipType GetMembershipTypeByID(int Id);
        void InsertMembershipType(MembershipType MembershipType);
        void DeleteMembershipType(int Id);
        void DeleteAllMembershipTypes();
        void UpdateMembershipType(MembershipType MemerbershipType);
        void Save();
    }
}
