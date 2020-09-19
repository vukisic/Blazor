using BlazorWebAssembly.Models;
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
    public class EmployeeService : IEmployeeService
    {
        private HttpClient _http;
        public EmployeeService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> Add(EmployeeModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(ServiceEndPoints.EmployeeUrl + "/add", data);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<bool> Delete(long id)
        {
            var response = await _http.DeleteAsync(ServiceEndPoints.EmployeeUrl + $"/delete/{id}");
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<bool> Edit(EmployeeModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync(ServiceEndPoints.EmployeeUrl + "/update", data);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task<List<Employee>> GetAll()
        {
            var response = await _http.GetAsync(ServiceEndPoints.EmployeeUrl + "/all");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Employee>>();
            return null;
        }
    }
}
