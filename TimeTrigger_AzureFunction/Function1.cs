using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using TimeTrigger_AzureFunction.Models;

namespace TimeTrigger_AzureFunction
{
    public class Function1
    {
        #region Property
        private readonly AppDbContext _appDbContext;
        #endregion

        #region Constructor
        public Function1(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion
        [FunctionName("JobExecution")]
        public void InsertData([TimerTrigger("%EveryMin%")] TimerInfo myTimer, ILogger log)
        {
            var employee = new Employee { Name = "Jay", IsActive = true,AddMinutes = DateTime.Now};
            _appDbContext.Employees.AddAsync(employee);
            _appDbContext.SaveChangesAsync();
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
        [FunctionName("FetchResults")]
        public void FetchData([TimerTrigger("%EveryFiveMinutes%")] TimerInfo myTimer, ILogger log)
        {
            var data = _appDbContext.Employees.ToList();
            log.LogInformation($"Total Records Count : {data.Count}");
        }
    }
}
