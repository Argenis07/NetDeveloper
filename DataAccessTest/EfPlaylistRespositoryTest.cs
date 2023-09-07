using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Linq;

namespace DataAccessTest
{
    [TestClass]
    public class EfPlaylistRespositoryTest
    {
        private readonly PlaylistRepository _entity;

        public EfPlaylistRespositoryTest()
        {
            _entity = new PlaylistRepository();
        }

        [TestMethod]
        public void TestEf_Conexion_Playlist_Cantidad()
        {
            var count = _entity.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void TestEf_ListaPlaylist()
        {
            var listaplaylist = _entity.GetListaPlaylist();
            Assert.AreEqual(listaplaylist.Count() > 0, true);
        }

        [TestMethod]
        public void TestEf_InsertPlaylist()
        {
            var playlistid = _entity.InsertPlaylist("nuevo playlist EF");
            Assert.AreEqual(playlistid > 0, true);
        }

        [TestMethod]
        public void TestEf_BuscarPorId()
        {
            var playlist = _entity.GetPlaylistPorId(1);
            var playlistencontrado = new Playlist
            {
                Playlistid = 1,
                Name = "Music"
            };
            Assert.AreEqual(playlistencontrado.Playlistid, playlist.Playlistid);
            Assert.AreEqual(playlistencontrado.Name, playlist.Name);
        }
    }
}
