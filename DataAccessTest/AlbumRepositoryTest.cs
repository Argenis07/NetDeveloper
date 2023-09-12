using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTest
{
    [TestClass]
    public class AlbumRepositoryTest
    {
        private readonly UnitOfWork _unit;

        public AlbumRepositoryTest()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        [TestMethod]
        public void Ejecucion_Diferida()
        {
            using (var context = new ChinookContext())
            {
                var resultado = from album in context.Album
                                where album.Title.StartsWith("A")
                                select album;

                foreach (var album in context.Album)
                {
                    Assert.AreEqual(album.Albumid > 0, true);
                }
            }
        }

        [TestMethod]
        public void Ejecucion_Inmediata()
        {
            using (var context = new ChinookContext())
            {
                var resultado = (from album in context.Album
                                 where album.Title.StartsWith("A")
                                 select album).Count();

                Assert.AreEqual(resultado > 0, true);
            }
        }

        [TestMethod]
        public void TestEf_Conexion_Album_Cantidad()
        {
            var count = _unit.Albums.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void TestEf_ListaAlbum()
        {
            var listaalbum = _unit.Albums.GetAll();
            Assert.AreEqual(listaalbum.Count() > 0, true);
        }

        [TestMethod]
        public void TestEf_BuscarPorId()
        {
            var album = _unit.Albums.GetById(1);
            var albumencontrado = new Album
            {
                Albumid = 1,
                Title = "For Those About To Rock We Salute You"
            };
            Assert.AreEqual(albumencontrado.Albumid, album.Artistid);
            Assert.AreEqual(albumencontrado.Title, album.Title);
        }
    }
}
