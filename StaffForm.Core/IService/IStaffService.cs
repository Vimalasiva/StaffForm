using StaffForm.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffForm.Core.IService
{
    public  interface IStaffService
    {
        public void Createform(StaffModel staffModel);
        List<StaffModel> listform();
        public void deleteid(int id);
        public StaffModel Save(int id);
    }
}
