using Agency_Application.Abstractions;
using Agency_Domain;
using Agency_Domain.ViewModels;
using Agency_Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency_Persistence.Concretes
{
    public class PortfolioServie : IPortfolioService
    {
        AppDbContext _context;

        public PortfolioServie(AppDbContext context)
        {
            _context = context;
        }

        public void Create(PortfolioVM slider)
        {
            PortfolioSlider portfolioSlider=new PortfolioSlider()
            {
                Title=slider.Title,
                SubTitle=slider.SubTitle,
                ImgUrl=slider.ImgFile.FileName,
            };
            _context.PortfolioSlider.Add(portfolioSlider);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
           var delete=_context.PortfolioSlider.FirstOrDefault(x=>x.ID== id);
            _context.PortfolioSlider.Remove(delete);
            _context.SaveChanges();
        }

        public PortfolioVM Get(int id)
        {
            var slider= _context.PortfolioSlider.FirstOrDefault(x => x.ID == id);
            PortfolioVM portfolio = new PortfolioVM()
            {
                Title=slider.Title,
                SubTitle=slider.SubTitle,
            };
            return portfolio;
        }

        public List<PortfolioSlider> GetAll()
        {
            return _context.PortfolioSlider.ToList();
        }

        public void Update(PortfolioVM slider)
        {
            var old=_context.PortfolioSlider.FirstOrDefault(x=>x.ID== slider.ID);
            old.Title=slider.Title;
            old.SubTitle=slider.SubTitle;
            old.ImgUrl=slider.ImgFile.FileName;
            _context.SaveChanges();
        }
    }
}
