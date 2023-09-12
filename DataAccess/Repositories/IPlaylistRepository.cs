using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Playlist GetByName(string name);
        int Count();
    }
}
