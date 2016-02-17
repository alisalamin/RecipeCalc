using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using DataAccess;
using DataAccess.Models;

namespace BusinessLogic
{
    public abstract class BaseManager
    {
        public AppSettingsBO AppSettings
        {
            get
            {
                var appConfig = new Repository<ApplicationConfig, Guid>().List().FirstOrDefault();

                var rateAdjustments = new Repository<RateAdjustment, int>()
                .List(ra => ra.AppId == appConfig.Id).FirstOrDefault();

                return new AppSettingsBO()
                {
                    AppId = appConfig.Id,
                    AppName = appConfig.AppName,
                    SalesTax = rateAdjustments.SalesTax,
                    WellnessDiscountRate =
                    rateAdjustments.WellnessDiscountRate
                };
            }
        }

    }
}
