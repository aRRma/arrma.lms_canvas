using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasEFCore.Entities
{
    public class LmsStudent : LmsBaseUser
    {
        public string Academic_group { get; set; }
    }
}
