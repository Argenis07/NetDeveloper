using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        IEnumerable<Album> GetAlbumsByStore();
        Album GetByTitle(string title);
        IEnumerable<Album> GetAlbumsPage(int pageindex, int pagesize);
        int Count();
    }
}
