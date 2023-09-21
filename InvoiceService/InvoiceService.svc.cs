using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class InvoiceService : IInvoiceService
    {
        public async Task<IEnumerable<CustomerInvoice>> AsyncGetInvoice(int invoicecode, string email)
        {
            return await Task<IEnumerable<CustomerInvoice>>.Factory.StartNew(() =>
            {
                using (var unitOfWork = new UnitOfWork(new ChinookContext()))
                {
                    return unitOfWork.Customers.Customerinvoice(invoicecode, email).ToList();
                }
            });
        }

        public IEnumerable<CustomerInvoice> GetInvoice(int invoicecode, string email)
        {
            using (var unitOfWork = new UnitOfWork(new ChinookContext()))
            {
                return unitOfWork.Customers.Customerinvoice(invoicecode, email).ToList();
            }
        }
    }
}
