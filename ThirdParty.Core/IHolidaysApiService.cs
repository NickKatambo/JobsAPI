using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThirdParty.Core
{
    public interface IHolidaysApiService
    {
        Task<List<HolidayModel>> GetHoliday(string countryCode, int year);
    }
}
