using BlazorWebAssembly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAll();
        Task<bool> Add(Department model);
        Task<bool> Delete(long id);
    }
}
