using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PatientInfoService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private const string FhirUrl = "https://www.hl7.org/fhir/patient-example.canonical.json";

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, FhirUrl);
            request.Headers.Add("User-Agent", "Mozilla/5.0");

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(jsonString).RootElement;

            var patientInfo = new
            {
                Id = json.GetProperty("id").GetString(),
                FirstName = json.GetProperty("name")[0].GetProperty("given")[0].GetString(),
                LastName = json.GetProperty("name")[0].GetProperty("family").GetString(),
                Gender = json.GetProperty("gender").GetString(),
                BirthDate = json.GetProperty("birthDate").GetString()
            };

            return Ok(patientInfo);
        }
    }
}
