using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.FlightsDb;

namespace WebAPI.Repository.Interfaces
{
    public interface ITaxRepository
    {
        Tax GetById(int id);
    }
}
