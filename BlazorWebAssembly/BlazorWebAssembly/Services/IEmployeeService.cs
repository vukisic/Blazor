using BlazorWebAssembly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<bool> Add(EmployeeModel model);
        Task<bool> Delete(long id);
        Task<bool> Edit(EmployeeModel model);
    }
}
