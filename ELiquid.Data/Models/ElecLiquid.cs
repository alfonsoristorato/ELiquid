using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELiquid.Data.Models
{
    public class ElecLiquid
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Display(Name ="Flavour Category")]
        public Category Category { get; set; }
        [Display(Name = "Propylene Glycol (PG)")]
        [Required]
        //[RegularExpression("^[1 - 9][0 - 9] ?$| ^100$")]
        public int PG { get; set; }
        [Display(Name = "Vegetable Glycerine (VG)")]
        [Required]              
        public int VG { get; set; }
        
        
        private string ratioValue;
        [Display(Name = "PG / VG Ratio")]
        public string PGVGRatio
        {
            get { return ratioValue; }
            set { ratioValue = $"{PG} / {VG}"; }
        }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image Url")]        
        public string Image { get; set; }
        public string Description { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }

    }
}
