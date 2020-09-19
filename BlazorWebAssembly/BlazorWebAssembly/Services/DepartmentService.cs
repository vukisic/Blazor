using BlazorWebAssembly.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Services
{
    public class DepartmentService : IDepartmentService
    {
        private HttpClient _http;
        private IConfiguration _config;
        public DepartmentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> Add(Department model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(ServiceEndPoints.DepartmentUrl+"/add", data);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<bool> Delete(long id)
        {
            var response = await _http.DeleteAsync(ServiceEndPoints.DepartmentUrl + $"/delete/{id}");
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<List<Department>> GetAll()
        {
            var response = await _http.GetAsync(ServiceEndPoints.DepartmentUrl + "/all");
            if(response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Department>>();
            return null;
        }
    }
}
