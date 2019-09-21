using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication5.Models;


namespace WebApplication5.Repositories.CustomersRepositories
{
    public class MembershipTypeRepository : IMembershipTypeRepository, IDisposable
    {
        private DataContext context;

        public MembershipTypeRepository(DataContext context)
        {
            this.context = context;
        }
        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return context.MembershipTypes.ToList();
        }
        public MembershipType GetMembershipTypeByID(int Id)
        {
            return context.MembershipTypes.Find(Id);
        }
        public void InsertMembershipType(MembershipType MembershipType)
        {
            context.MembershipTypes.Add(MembershipType);
        }
        public void DeleteMembershipType(int Id)
        {
            MembershipType MembershipType = context.MembershipTypes.Find(Id);
            context.MembershipTypes.Remove(MembershipType);
        }
        public void UpdateMembershipType(MembershipType MembershipType)
        {
            context.Entry(MembershipType).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}