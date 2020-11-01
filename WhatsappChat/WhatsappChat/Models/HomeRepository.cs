using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsappChat.ViewModel;
using WhatsappChat.Models;
namespace WhatsappChat.Models
{
    public class HomeRepository
    {
        DataDataContext db = new DataDataContext();
        public List<HomeViewModel> EmpDetails()
        {
            List<HomeViewModel> Emp = db.sp_GetEmployeesDetails(null).Select(x => new HomeViewModel {

                Id = x.ID,
                Mobile_NO = x.MobileNo
            }).ToList();

            return Emp;
        }
    }
}