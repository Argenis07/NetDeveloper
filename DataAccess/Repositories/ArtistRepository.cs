using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ChinookContext context) : base(context)
        {
        }

        public IEnumerable<Artist> GetArtistsByStore()
        {
            return chinookcontext.Database.SqlQuery<Artist>("GetListaArtista");
        }

        public Artist GetByName(string name)
        {
            return chinookcontext.Artists.FirstOrDefault(artista => artista.Name == name);
        }

        public ChinookContext chinookcontext
        {
            get { return Context as ChinookContext; }
        }
    }
}
