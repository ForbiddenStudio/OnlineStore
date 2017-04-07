using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreDomain
{
    public class ProductEntity 
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
       [Required(ErrorMessage = "Пожалуйста, введите название продукта")]
        public string Name { get; set; }
        [Display(Name = "Цена (руб)")]
       [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }
        [Display(Name = "Объем")]
        [Required(ErrorMessage = "Пожалуйста, введите объем продукта")]
        public double Volume { get; set; }
        [Display(Name = "Категория")]
       [Required(ErrorMessage = "Пожалуйста, укажите категорию для продукта")]
        public int TypeEntityId { get; set; }

        public virtual TypeEntity TypeEntity { get; set; }
    }
}
