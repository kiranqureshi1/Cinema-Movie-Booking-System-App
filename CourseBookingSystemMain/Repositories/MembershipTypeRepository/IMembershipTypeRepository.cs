using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using WebApplication2.Models;



namespace WebApplication2.Repositories.MembershipTypeRepository

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