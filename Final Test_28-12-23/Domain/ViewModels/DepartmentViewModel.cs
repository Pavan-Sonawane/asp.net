﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

    public class DepartmentInsertModel
    {
        public string Name { get; set; }

    }
    public class DepartmentUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
