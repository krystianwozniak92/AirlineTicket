using System.ComponentModel.DataAnnotations;

namespace Model.FlightScanner.Interfaces
{
    public interface IDbEntity
    {
        [Key]
        int Id { get; set; }
        bool IsDeleted { get; set; } 
    }
}
