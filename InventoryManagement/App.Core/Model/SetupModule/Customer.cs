using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Model.SetupModule
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public bool IsActive { get; set; }
    }
}
