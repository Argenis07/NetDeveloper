using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(DbContext context) : base(context)
        {
        }

        public Track GetByName(string name)
        {
            return chinookcontext.Track.FirstOrDefault(track => track.Name == name);
        }

        public ChinookContext chinookcontext
        {
            get { return Context as ChinookContext; }
        }
    }
}
