using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Model.SetupModule
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public string ItemsName { get; set; }
        public string PurchasePrice { get; set; }
        public string SalePrice { get; set; }
        public string ReoderLevel { get; set; }
        public string Remark { get; set; }
        public bool IsActive { get; set; }
    }
}
