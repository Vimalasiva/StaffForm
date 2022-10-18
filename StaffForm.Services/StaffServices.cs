using StaffForm.Core.IRepository;
using StaffForm.Core.IService;
using StaffForm.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffForm.Services
{
    public class StaffServices : IStaffService
    {
        IStaffRepository _staffRepository;
        public StaffServices(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        #region Createform
        public void Createform(StaffModel employeeModel)
        {
            _staffRepository.Createform(employeeModel);
        }
        #endregion

        #region Listform
        public List<StaffModel> listform()
        {
            return _staffRepository.listform();
        }
        #endregion

        #region deleteid
        public void deleteid(int id)
        {
            _staffRepository.deleteid(id);
        }
        #endregion

        #region save logic for edit page
        public StaffModel Save(int id)
        {
            return _staffRepository.Save(id);
        }
        #endregion
    }
}
