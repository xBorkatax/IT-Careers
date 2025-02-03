using BarRating.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Service.Bar
{
    public interface IBarService
    {
        List<BarDto> GetAll();
        Task<BarDto> Create(BarDto barDto);
        BarDto GetBarById(string id);
        Task<BarDto> Edit(BarDto barDto);
        int DeleteById(string id);
    }
}
