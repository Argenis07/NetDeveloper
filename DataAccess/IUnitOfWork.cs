using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository Artists { get; }
        IAlbumRepository Albums { get; }
        IPlaylistRepository Playlists { get; }
        ICustomerRepository Customers { get; }
        int Complete();
    }

}
