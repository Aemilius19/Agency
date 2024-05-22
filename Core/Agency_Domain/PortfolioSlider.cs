using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency_Domain
{
    public class PortfolioSlider
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
        public string? ImgUrl { get; set; }
    }
}
