using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PatientInfoService.Tests
{
    public class PatientApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PatientApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetPatient_ReturnsValidData()
        {
            // Kada pozovemo API
            var response = await _client.GetAsync("/api/patient");

            // Provjera statusa
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Parsiraj JSON
            var patient = await response.Content.ReadFromJsonAsync<PatientDto>();

            // Provjera podataka
            Assert.Equal("example", patient.Id);
            Assert.Equal("Peter", patient.FirstName);
            Assert.Equal("Chalmers", patient.LastName);
        }

        // Mini-klasa koja predstavlja strukturu pacijenta
        public class PatientDto
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string BirthDate { get; set; }
        }
    }
}
