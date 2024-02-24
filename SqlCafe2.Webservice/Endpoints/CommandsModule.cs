using Carter;

namespace SqlCafe2.Webservice.Endpoints
{
    public class CommandsModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/commands", () => "Hello World!");    
        }
    }
}