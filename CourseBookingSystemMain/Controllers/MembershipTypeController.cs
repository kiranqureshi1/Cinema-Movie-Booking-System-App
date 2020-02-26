using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories.CustomersRepositories;
using WebApplication2.Repositories.MembershipTypeRepository;
using WebApplication2.Repositories.MovieRepository;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class MembershipTypeController : Controller
    {
        IMembershipTypeRepository iMembershipTypeRepository = new MembershipTypeRepository(new CustomerContext());
        ICustomerRepository customerRepository = new CustomerRepository(new CustomerContext());
        CustomerContext customerContext = new CustomerContext();

        public ActionResult MembershipType()
        {
            var membershipTypes = customerContext.MembershipTypes.Include(m => m.Customers);
            var MembershipTypes = membershipTypes.ToList();
            return View(MembershipTypes);
        }

        //public ActionResult 

        [HttpPost]
        public ActionResult Delete(int id)
        {
            MembershipType membershipType = new MembershipType();
            membershipType = iMembershipTypeRepository.GetMembershipTypeByID(id);
            iMembershipTypeRepository.DeleteMembershipType(membershipType.Id);
            iMembershipTypeRepository.Save();
            return RedirectToAction("MembershipType");
        }

        public ActionResult MembershipForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MembershipForm(int Id, short SignupFee, byte DurationInMonths, byte DiscountRate)
        {
            MembershipType membershipType = new MembershipType();
            membershipType.Id = Id;
            membershipType.SignupFee = SignupFee;
            membershipType.DurationInMonths = DurationInMonths;
            membershipType.DiscountRate = DiscountRate;
            iMembershipTypeRepository.InsertMembershipType(membershipType);
            iMembershipTypeRepository.Save();
            return RedirectToAction("MembershipType");
        }

        public ActionResult Edit(int id)
        {
            MembershipType membershipType = new MembershipType();
            membershipType = iMembershipTypeRepository.GetMembershipTypeByID(id);
            return View(membershipType);
        }

        [HttpPost]
        public ActionResult Edit(int Id, short SignupFee, byte DurationInMonths, byte DiscountRate)
        {
            MembershipType membershipType = new MembershipType();
            membershipType.Id = Id;
            membershipType.SignupFee = SignupFee;
            membershipType.DurationInMonths = DurationInMonths;
            membershipType.DiscountRate = DiscountRate;
            iMembershipTypeRepository.UpdateMembershipType(membershipType);
            iMembershipTypeRepository.Save();
            return RedirectToAction("MembershipType");
        }
    }
}