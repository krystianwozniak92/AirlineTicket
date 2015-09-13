using WebAPI.Models.QPX.Interfaces;

namespace WebAPI.Models.QPX.Response
{
    public class Response : IResponse
    {
        public string Kind { get; set; }
        
        public Trips Trips { get; set; }

        public Response()
        {
            Kind = "qpxExpress#tripsSearch";

            Trips = new Trips();
        }
    }
}
