using EasyCashIndetityProject.Business.Abstract;
using EasyCashIndetityProject.DataAccess.Abstract;
using EasyCashIndetityProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIndetityProject.Business.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public CustomerAccountProcessManager(ICustomerAccountProcessService customerAccountProcessService)
        {
            _customerAccountProcessService = customerAccountProcessService;
        }

        public void TDelete(CustomerAccountProcess t)
        {
            _customerAccountProcessService.TDelete(t);  
        }

        public CustomerAccountProcess TGetById(int id)
        {
            return _customerAccountProcessService.TGetById(id);
        }

        public List<CustomerAccountProcess> TGetList()
        {
            return _customerAccountProcessService.TGetList();
        }

        public void TInsert(CustomerAccountProcess t)
        {
            _customerAccountProcessService.TUpdate(t);
        }

        public void TUpdate(CustomerAccountProcess t)
        {
            _customerAccountProcessService.TUpdate(t);
        }
    }
}
