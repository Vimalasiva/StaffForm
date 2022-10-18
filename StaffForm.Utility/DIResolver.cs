using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StaffForm.Core.IRepository;
using StaffForm.Core.IService;
using StaffForm.Repository;
using StaffForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffForm.Utility
{
    public class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Context accesor
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services
            services.AddScoped<IStaffService, StaffServices>();

            #endregion

            #region Repository
            services.AddScoped<IStaffRepository, StaffRepository>();
            #endregion
        }
    }
}
