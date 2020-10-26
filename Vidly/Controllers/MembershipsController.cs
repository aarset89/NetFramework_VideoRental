using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace Vidly.Controllers
{
    public class MembershipsController : Controller
    {
        private ApplicationDbContext _context;

        public MembershipsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Membeships
        public ActionResult Index()
        {
            
            var viewModel = new MembershipTypesViewModel
            {
                MembershipType = new MembershipType(),
                MembershipTypes = _context.membershipTypes.OrderBy(m => m.DiscountRate).ToList(),
                
            };

            return View("Index",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MembershipType membershipType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return HttpNotFound();
                }
                if (membershipType.Id == 0)
                {
                    
                    _context.membershipTypes.Add(membershipType);
                }
                else
                {
                    var membershipTypeInDb = _context.membershipTypes.Single(m => m.Id == membershipType.Id);

                    membershipTypeInDb.Name = membershipType.Name;
                    membershipTypeInDb.SignUpFee = membershipType.SignUpFee;
                    membershipTypeInDb.DurationInMonths = membershipType.DurationInMonths;
                    membershipTypeInDb.DiscountRate = membershipType.DiscountRate;
                }

                _context.SaveChanges();

                return RedirectToAction(nameof(Index), "Memberships");
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return RedirectToAction(nameof(Index), "Memberships");
            }
        }


        
        public ActionResult Delete(int id)
        {
            var membershipType = _context.membershipTypes.SingleOrDefault(m => m.Id == id);

            if (membershipType == null)
                return HttpNotFound();

            _context.membershipTypes.Remove(membershipType);

            try
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

        }

        public PartialViewResult New()
        {
            MembershipTypesViewModel a = new MembershipTypesViewModel();

            return PartialView("_CreateMembershipType", a);

        }

        [HttpPost]
        public PartialViewResult Edit(int id)
        {
            var membershipType = _context.membershipTypes.SingleOrDefault(m => m.Id == id);

            //if (membershipType == null)
            //    return HttpNotFound();

            MembershipTypesViewModel a = new MembershipTypesViewModel
            {
                MembershipType = membershipType
            };

            return PartialView("_CreateMembershipType", a);
        }

    }
}