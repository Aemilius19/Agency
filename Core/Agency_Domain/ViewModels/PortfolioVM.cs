using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency_Domain.ViewModels
{
    public class PortfolioVM
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string SubTitle { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
