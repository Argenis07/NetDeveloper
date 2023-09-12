using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Linq;

namespace DataAccessTest
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        private readonly UnitOfWork _unit;

        public ArtistRepositoryTest()
        {
            _unit = new UnitOfWork(new ChinookContext());
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
            var count = _unit.Artists.Count();
            Assert.AreEqual(count > 0, true);
        }

        [TestMethod]
        public void TestEf_ListaArtista()
        {
            var listaartista = _unit.Artists.GetAll();
            Assert.AreEqual(listaartista.Count() > 0, true);
        }

        [TestMethod]
        public void TestEf_ListaArtistaSP()
        {
            var listaartista = _unit.Artists.GetArtistsByStore();
            Assert.AreEqual(listaartista.Count() > 0, true);
        }

        [TestMethod]
        public void TestEf_InsertaArtista()
        {
            var newartista = new Artist
            {
                Name = "Desde el Unit of work"
            };
            _unit.Artists.Add(newartista);
            int retorno = _unit.Complete();

            var artistanuevo = _unit.Artists.GetByName("Desde el Unit of work");
            Assert.AreEqual(artistanuevo.Artistid > 0, true);
            Assert.AreEqual(artistanuevo.Name, "Desde el Unit of work");
        }

        [TestMethod]
        public void TestEf_BuscarPorId()
        {
            var artista = _unit.Artists.GetById(1);
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
