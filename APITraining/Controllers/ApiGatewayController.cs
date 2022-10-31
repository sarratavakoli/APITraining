using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITraining.Controllers
{
    public class ApiGatewayController : ControllerBase
    {
        [HttpGet]
        [Route("~/apigateway/Countries")]
        public IActionResult GetCountries()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.covid19api.com/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("countries").Result;

                if (response.IsSuccessStatusCode)
                {
                    return Ok(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    return BadRequest("Something went wrong in the request. Please check the request Uri.");
                }
            }
            catch(Exception ex) { return Ok(ex.Message); }
            finally { }
        }

        

    }
}
