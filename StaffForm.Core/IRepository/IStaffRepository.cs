using StaffForm.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffForm.Core.IRepository
{
    public  interface IStaffRepository
    {
        public void Createform(StaffModel staffModel);
        List<StaffModel> listform();
        public void deleteid(int id);
        public StaffModel Save(int id);
        List<StaffModel> searchdetail(string Name);
        List<LocationModel> changedetail();
    }
}
