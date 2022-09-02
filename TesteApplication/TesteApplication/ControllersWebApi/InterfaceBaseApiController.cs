using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Web;
using TesteApplication.Model;

namespace TesteApplication.ControllersWebApi
{

    public interface IBaseApiController : IDisposable
    {
        Task<IEnumerable<Object>> GetRecords();
        Task<object> GetRecordById(long? id);
        Task Save(Object model);

    }
}