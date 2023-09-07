using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Linq;

namespace DataAccessTest
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        private readonly ArtistRepository _entity;

        public ArtistRepositoryTest()
        {
            _entity = new ArtistRepository();
        }

        [TestMethod]
        public void Ejecucion_Diferida()
        {
            using (var context = new ChinookContext())
            {
                var resultado = from artist in context.Artists
                                where artist.Name.StartsWith("A")
                                select artist;

                foreach ( var artista in context.Artists)
                {
                    Assert.AreEqual(artista.Artistid > 0, true);
                }
            }
        }

        [TestMethod]
        public void Ejecucion_Inmediata()
        {
            using (var context = new ChinookContext())
            {
                var resultado = (from artist in context.Artists
                                 where artist.Name.StartsWith("A")
                                 select artist).Count();

                Assert.AreEqual(resultado > 0, true);
            }
        }

        [TestMethod]
        public void TestEf_Conexion_Artist_Cantidad()
        {
            var count = _entity.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void TestEf_ListaArtista()
        {
            var listaartista = _entity.GetListaArtista();
            Assert.AreEqual(listaartista.Count() > 0, true);
        }

        [TestMethod]
        public void TestEf_ListaArtistaSP()
        {
            var listaartista = _entity.GetListaArtistaStore();
            Assert.AreEqual(listaartista.Count() > 0, true);
        }

        [TestMethod]
        public void TestEf_InsertaArtista()
        {
            var artistaid = _entity.InsertArtista("nuevo artista EF");
            Assert.AreEqual(artistaid > 0, true);
        }

        [TestMethod]
        public void TestEf_BuscarPorId()
        {
            var artista = _entity.GetArtistaPorId(1);
            var artistaencontrado = new Artist
            {
                Artistid = 1,
                Name = "AC/DC"
            };
            Assert.AreEqual(artistaencontrado.Artistid, artista.Artistid);
            Assert.AreEqual(artistaencontrado.Name, artista.Name);
        }
    }
}
