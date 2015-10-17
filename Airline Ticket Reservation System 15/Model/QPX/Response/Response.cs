using Model.QPX.Interfaces;

namespace Model.QPX.Response
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
