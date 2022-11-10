using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StaffForm.Core.IRepository;
using StaffForm.Core.Model;
using StaffForm.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffForm.Repository
{
    public class StaffRepository : IStaffRepository
    {
        #region Creating new employee Detail
        public void Createform(StaffModel staffModel)
        {
            if (staffModel != null)
            {
                using (Staff_DetailsContext entity = new Staff_DetailsContext())
                {
                    if (staffModel.ID == 0)
                    {                         
                        StaffDetailTable staffDetailTable = new StaffDetailTable();
                        staffDetailTable.Staff_Name = staffModel.Name;
                        staffDetailTable.User_Age = staffModel.Age;
                        staffDetailTable.User_Gender = staffModel.Gender;
                        staffDetailTable.User_Qualification = staffModel.Qualification;
                        staffDetailTable.Company_Name = staffModel.CompanyName;
                        staffDetailTable.Joining_Date = DateTime.Parse(staffModel.Datestr);//To convert the date which is in string to date(int) and assigning that value to the Joining_Date(database column name)
                        staffDetailTable.Position = staffModel.Role;
                        staffDetailTable.Year_Of_Experience = staffModel.Experience;
                        staffDetailTable.Staff_Location_ID= staffModel.StaffLocationID;
                        staffDetailTable.User_Address = staffModel.Address;
                        staffDetailTable.Mobile_No = staffModel.MobileNo;
                        staffDetailTable.Email_ID = staffModel.EmailID;
                        staffDetailTable.User_Password = staffModel.Password;
                        staffDetailTable.Conform_Password = staffModel.RePassword;
                        entity.Add(staffDetailTable);
                        entity.SaveChanges();
                        
                    }
                    else
                    {
                        var check = entity.StaffDetailTable.Where(m => m.Staff_ID == staffModel.ID).SingleOrDefault();
                        if (check != null)
                        {
                            check.Staff_Name = staffModel.Name;
                            check.User_Age = staffModel.Age;
                            check.User_Gender = staffModel.Gender;
                            check.User_Qualification = staffModel.Qualification;
                            check.Company_Name = staffModel.CompanyName;
                            check.Joining_Date = DateTime.Parse(staffModel.Datestr);
                            check.Position = staffModel.Role;
                            check.Year_Of_Experience = staffModel.Experience;
                            check.Staff_Location_ID= staffModel.StaffLocationID;
                            check.User_Address = staffModel.Address;
                            check.Mobile_No = staffModel.MobileNo;
                            check.Email_ID = staffModel.EmailID;
                            check.User_Password = staffModel.Password;
                            check.Conform_Password = staffModel.RePassword;
                            entity.SaveChanges();
                        }
                    }

                }
            }

        }
        #endregion

        #region Assigning values in Edit page for editing existing record(save logic for edit page)
        public StaffModel Save(int id)
        {
            using (Staff_DetailsContext entity = new Staff_DetailsContext())
            {
                StaffModel staffModel = new StaffModel();
                var save = entity.StaffDetailTable.Where(m => m.Staff_ID == id).SingleOrDefault();
                if (save != null)
                {
                    staffModel.ID = save.Staff_ID;
                    staffModel.Name = save.Staff_Name;
                    staffModel.Age = save.User_Age;
                    staffModel.Gender = save.User_Gender;
                    staffModel.Qualification = save.User_Qualification;
                    staffModel.CompanyName = save.Company_Name;
                    staffModel.Datestr = save.Joining_Date.ToString("yyyy/MM/dd");
                    staffModel.Role = save.Position;
                    staffModel.Experience = save.Year_Of_Experience;
                    var ID = save.Staff_Location_ID;
                    var place = entity.Staff_Location.Where(m => m.Staff_Location_ID == ID).SingleOrDefault();
                    staffModel.Location = place.Working_Location;
                    staffModel.StaffLocationID = place.Staff_Location_ID;
                    staffModel.Address = save.User_Address;
                    staffModel.MobileNo = save.Mobile_No;
                    staffModel.EmailID = save.Email_ID;
                    staffModel.Password = save.User_Password;
                    staffModel.RePassword = save.Conform_Password;
                }
                return staffModel;
            }
        }
        #endregion

        #region To get the ID and Location from the  new table in database
        public List<LocationModel> changedetail()

        {
            List<LocationModel> change= new List<LocationModel>();
            using (Staff_DetailsContext entity = new Staff_DetailsContext())
            {
                var List = entity.Staff_Location.Where(x => x.Is_Deleted == false).ToList();
                if (List != null)
                {
                    foreach (var i in List)
                    {
                        LocationModel locationModel = new LocationModel();
                        locationModel.StaffLocationID =i.Staff_Location_ID;
                        locationModel.Location = i.Working_Location;
                        change.Add(locationModel);
                    }
                }
            }
            return change;
        }
        #endregion

        #region Listing the Details of employee
        public List<StaffModel> listform()
        {
            List<StaffModel> employeeList = new List<StaffModel>();
            using (Staff_DetailsContext entity = new Staff_DetailsContext())
            {
                var List = entity.StaffDetailTable.Where(x => x.Is_Deleted == false).ToList();
                if (List != null)
                {
                    foreach (var item in List)
                    {
                        StaffModel staffModel = new StaffModel();
                        staffModel.ID = item.Staff_ID;
                        staffModel.Name = item.Staff_Name;
                        staffModel.Age = item.User_Age;
                        staffModel.Gender = item.User_Gender;
                        staffModel.Qualification = item.User_Qualification;
                        staffModel.CompanyName = item.Company_Name;
                        staffModel.Datestr = item.Joining_Date.ToString("yyyy/MM/dd");
                        staffModel.Role = item.Position;
                        staffModel.Experience = item.Year_Of_Experience;
                        var ID = item.Staff_Location_ID;
                        var place = entity.Staff_Location.Where(m => m.Staff_Location_ID == ID).SingleOrDefault();
                        staffModel.Location= place.Working_Location;
                        staffModel.Address = item.User_Address;
                        staffModel.MobileNo = item.Mobile_No;
                        staffModel.EmailID = item.Email_ID;
                        staffModel.Password = item.User_Password;
                        staffModel.RePassword = item.Conform_Password;
                        employeeList.Add(staffModel);
                    }
                }
                return employeeList;
            }
        }
        #endregion

        #region Displaying a particular data in list
        public List<StaffModel> searchdetail(string Name)
        {
            List<StaffModel> employeeList = new List<StaffModel>();
            using (Staff_DetailsContext entity = new Staff_DetailsContext())
            {
                var List = entity.StaffDetailTable.Where(x => x.Staff_Name.Contains(Name)).ToList();
                if (List != null)
                {
                    foreach (var item in List)
                    {
                        StaffModel staffModel = new StaffModel();
                        staffModel.ID = item.Staff_ID;
                        staffModel.Name = item.Staff_Name;
                        staffModel.Age = item.User_Age;
                        staffModel.Gender = item.User_Gender;
                        staffModel.Qualification = item.User_Qualification;
                        staffModel.CompanyName = item.Company_Name;
                        staffModel.Datestr = item.Joining_Date.ToString("yyyy/MM/dd");
                        staffModel.Role = item.Position;
                        staffModel.Experience = item.Year_Of_Experience;
                        var ID = item.Staff_Location_ID;
                        var place = entity.Staff_Location.Where(m => m.Staff_Location_ID == ID).SingleOrDefault();
                        staffModel.Location = place.Working_Location;
                        staffModel.Address = item.User_Address;
                        staffModel.MobileNo = item.Mobile_No;
                        staffModel.EmailID = item.Email_ID;
                        staffModel.Password = item.User_Password;
                        staffModel.RePassword = item.Conform_Password;
                        employeeList.Add(staffModel);
                    }
                }
                return employeeList;
            }
        }
        #endregion

        #region Deleting detail
        public void deleteid(int id)
        {
            using (Staff_DetailsContext entity = new Staff_DetailsContext())
            {
                var delete = entity.StaffDetailTable.Where(m => m.Staff_ID== id).SingleOrDefault();
                if (delete != null)
                {
                    delete.Is_Deleted = true;
                    entity.SaveChanges();
                }
            }
        }
        #endregion
    }
}
