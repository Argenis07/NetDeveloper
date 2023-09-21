using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        IEnumerable<Artist> GetArtistsByStore();
        Artist GetByName(string name);
        IEnumerable<Artist> GetArtistsPage(int pageindex, int pagesize);
        int Count();
    }
}
