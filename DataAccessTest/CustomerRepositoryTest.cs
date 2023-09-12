using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private readonly UnitOfWork _unit;

        public CustomerRepositoryTest()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        [TestMethod]
        public void Get_Lista_Customer_Invoice()
        {
            var resultado = _unit.Customers.Customerinvoice(208, "bjorn.hansen@yahoo.no").ToList();
            Assert.AreEqual(resultado[0].Email, "bjorn.hansen@yahoo.no");
        }
    }
}
