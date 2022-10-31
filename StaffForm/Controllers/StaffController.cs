using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffForm.Core.Model;
using StaffForm.Entity;
using StaffForm.Services;
using System.Net.Http.Json;

namespace StaffForm.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Create
       
        Staff_DetailsContext context = new Staff_DetailsContext();
        [HttpGet]
        //To get the datas for dropdown from the database and assigning it to view bag 
        public IActionResult Create()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7239/api/StaffAPI/Change");
                var listTask = client.GetAsync(client.BaseAddress);
                listTask.Wait();
                var result = listTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<LocationModel>>();
                    readTask.Wait();
                    ViewBag.List= readTask.Result;
                }
            }

            return View();
        }
        [HttpPost]
        public IActionResult Create(StaffModel staffModel)
        {
            Staff_DetailsContext staff = new Staff_DetailsContext();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7239/api/StaffAPI/Create");
                var createtask = client.PostAsJsonAsync<StaffModel>(client.BaseAddress, staffModel);
                createtask.Wait();
                var check = createtask.Result;
                if (check.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                
            }
            return RedirectToAction("List");
        }
        #endregion

        #region List
        [HttpGet]
        public IActionResult List()
        {        
           
            IList<StaffModel>? students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7239/api/StaffAPI/List");
                var listTask = client.GetAsync(client.BaseAddress);
                listTask.Wait();
                var result = listTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<StaffModel>>();
                    readTask.Wait();
                    students = readTask.Result;                   
                }
                List<StaffModel> SortedList = students.OrderBy(o => o.Name).ToList();
                return View(SortedList);
            }
        }
        #endregion

        #region Search
        [HttpGet]
        public IActionResult search(string Name)
        {
            IList<StaffModel>? students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7239/api/StaffAPI/search?Name=");

                var listTask = client.GetAsync(client.BaseAddress+Name);
                listTask.Wait();

                var result = listTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<StaffModel>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                return View("List",students);
            }
        }

        #endregion

        #region Partial view of detail
        public IActionResult _Detail(int id)
        {

            StaffModel? model = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7239/api/StaffAPI/Edit?id=");
                var editTask = client.GetAsync(client.BaseAddress + id.ToString());
                editTask.Wait();
                var check = editTask.Result;
                if (check.IsSuccessStatusCode)
                {
                    var readTask = check.Content.ReadFromJsonAsync<StaffModel>();
                    readTask.Wait();
                    model = readTask.Result;
                }
            }
            return PartialView(model);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Create();
            StaffModel? model = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7239/api/StaffAPI/Edit?id=");
                var editTask = client.GetAsync(client.BaseAddress + id.ToString());
                editTask.Wait();
                var check = editTask.Result;
                if (check.IsSuccessStatusCode)
                {
                    var readTask = check.Content.ReadFromJsonAsync<StaffModel>();
                    readTask.Wait();
                    model = readTask.Result;
                }
            }
            return View("Create",model);
        }        
        #endregion

        #region Delete
      
        public IActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7239/api/StaffAPI/Delete?id=");
                var deletetask = client.DeleteAsync(client.BaseAddress +id.ToString());
                deletetask.Wait();
                var check = deletetask.Result;

                if (check.IsSuccessStatusCode)
                {

                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
        
        #endregion
    
}
