using EmployeeTracker.ArrivalService;
using EmployeeTracker.WebApplication.Models;
using EmployeeTraker.DataLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTracker.WebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private const string TOKEN = "X-Fourth-Token";

        private readonly IEmployeeArrivalServicecs m_EmployeeArrivalServicecs;
        private readonly IEmployeeArrivalRepository<EmployeeInformation> m_Repository;
        private static SubscriptionResponse m_RsponseInformation;
        private static bool m_IsSubscibed = false;

        public EmployeeController(
            IEmployeeArrivalServicecs employeeArrivalServicecs, 
            IEmployeeArrivalRepository<EmployeeInformation> repository)
        {
            m_EmployeeArrivalServicecs = employeeArrivalServicecs;
            m_Repository = repository;
        }

        public async Task<ActionResult> Index(string sortOrder, string searchString)
        {
            if (!m_IsSubscibed)
            {
                await Subscribe();
            }

            var employees = m_Repository.GetAll();
            var searchedId = 0;

            if (!string.IsNullOrEmpty(searchString) && int.TryParse(searchString, out searchedId))
            {
                employees = employees.Where(e => e.EmployeeId == searchedId);
            }

            if (string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "id" :
                        employees = employees.OrderBy(e => e.EmployeeId);
                        break;
                    case "date":
                        employees = employees.OrderBy(e => e.ArrivalDateTime);
                        break;
                    default:
                        break;
                }
            }

            var employeeViewModel = new EmployeeViewModel
            {
                EmployeesInformation = employees
            };

            return View(employeeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult SendEmployeeData(List<EmployeeInformationRequest> requestData)
        {
            if (requestData == null)
            {
                return Json(new { Success = false});
            }

            var token = Request.Headers[TOKEN];

            if (m_RsponseInformation == null)
            {
                return Json(new { Success = false });
            }

            if (!string.Equals(token, m_RsponseInformation.Token) && m_RsponseInformation.Expires < DateTime.Now)
            {
                return Json(new { Success = false});
            }

            m_Repository.AddRange(requestData.Select(e => new EmployeeInformation(0, e.EmployeeId, e.When)));

            return Json(new { Success = true });
        }

        private async Task Subscribe()
        {
            var url = Url.Action("SendEmployeeData", "Employee", null, Request.Url.Scheme);
            var dateTime = DateTime.Now;
            try
            {
                var response = await m_EmployeeArrivalServicecs.Subscribe(dateTime, url);

                if (!string.IsNullOrEmpty(response))
                {
                    m_RsponseInformation = JsonConvert.DeserializeObject<SubscriptionResponse>(response);
                }

                m_IsSubscibed = true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}