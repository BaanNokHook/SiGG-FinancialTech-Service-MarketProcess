using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.MarketProcess;
using Microsoft.AspNetCore.Mvc;

namespace GM.Service.MarketProcess.Controllers
{
    [Route("[controller]")]    
    [ApiController]  
    public class ExchangeRateController : ControllerBase  
    {
        private readonly IUnitOfWork _uow;   
        
        public ExchangeRateController(IUnitOfWork uow)    
        {
            _uow = uow;   
        } 

        [HttpPost]  
        [Route("GetExchangeRateList")]   
        public ResultWithModel GetExchangeRateList(ExchangeRateModel model)  
        {
            return _uow.MarketProcess.ExchangeRate.Get(model);    
        }   

        [HttpPost]
        [Route("Create")]
        public ResultWithModel Create(ExchangeRateModel model)
        {
            return _uow.MarketProcess.ExchangeRate.Add(model);
        }

        [HttpPost]   
        [Route("GetEdit")]  
        public ResultWithModel GetEdit(ExchangeRateModel model)   
        {
            return _uow.MarketProcess.ExchangeRate.Find(model);  
        }

        [HttpPost]  
        [Route("Update")]  
        public ResultWithModel Update(ExchangeRateModel model)   
        {
            return _uow.MarketProcess.ExchangeRate.Update(model);   
        }   

        [HttpPost]   
        [Route("Delete")]  
        public ResultWithModel Delete(ExchangeRateModel model)   
        {
            return _uow.MarketProcess.ExchangeRate.Remove(model);  
        }  

        [HttpGet]  
        [Route("GetExchangeRateSource")]  
        public ResultWithModel GetDDLExchangeRateSource(string text)   
        {
            DropdownModel model = new DropdownModel();   
            model.ProcedureName = "GM_DDL_4list_Proc";   
            model.DdltTableList = "EXCHANGE_RATE_SOURCE";   
            model.SearchValue = text;   
            model.Paging = new PagingModel(){PageNumber = 1, RecordPerPage = 10};  
            return _uow.Dropdown.Get(model);   
        }  

        [HttpGet]  
        [Route("GetExchangeRateType")]  
        public ResultWithModel GetDDLExchangeRateType(string text)   
        {
            DropdownModel model = new DropdownModel();   
            model.ProcedureName = "GM_DDL_List_Proc";  
            model.SearchValue = text;  
            model.Paging = new pagingModel() { PageNumber = 1, RecordPerPage = 10 };       
            return _uow.Dropdown.Get(model);    
        }
    }
}