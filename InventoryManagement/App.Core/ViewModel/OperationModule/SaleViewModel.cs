using App.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ViewModel.OperationModule
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string SalesNo { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Date { get; set; }
        public string TotalAmount { get; set; }
        public string Discount { get; set; }
        public string PayAble { get; set; }
        public string PayAmount { get; set; }
        public string Remark { get; set; }
    }
}
