using FastEndpoints;

namespace CourseManagement.Endpoints.WeatherForecast
{
    public class WeatherForecastEndpoint: EndpointWithoutRequest<WeatherForecastResponse[]>
    {
        public override void Configure()
        {
            Get("");
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public override async Task HandleAsync(CancellationToken ct)
        {
            Response =  Enumerable.Range(1, 5).Select(index => new WeatherForecastResponse
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            await SendOkAsync(Response);
        }
    }
}
