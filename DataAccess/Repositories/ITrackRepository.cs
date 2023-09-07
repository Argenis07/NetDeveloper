using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface ITrackRepository : IRepository<Track>
    {
        Track GetByName(string name);
    }
}
