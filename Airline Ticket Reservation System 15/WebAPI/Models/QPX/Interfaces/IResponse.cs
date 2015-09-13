using WebAPI.Models.QPX.Response;

namespace WebAPI.Models.QPX.Interfaces
{
    public interface IResponse
    {
        string Kind { get; set; }

        Trips Trips { get; set; }
    }
}
