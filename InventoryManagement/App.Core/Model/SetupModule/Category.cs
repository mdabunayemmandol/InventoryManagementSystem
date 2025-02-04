﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Model.SetupModule
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
