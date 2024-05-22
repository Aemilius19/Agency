using Agency_Domain;
using Agency_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency_Application.Abstractions
{
    public interface IPortfolioService
    {
        List<PortfolioSlider> GetAll();
        void Create(PortfolioVM slider);
        void Delete(int id);
        void Update(PortfolioVM slider);
        PortfolioVM Get(int id);
    }
}
