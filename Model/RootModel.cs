using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RootModel
    {
        private int _id;
        private string _adminid;
        private string _adminpwd;

        public int Id { get => _id; set => _id = value; }
        public string Adminid { get => _adminid; set => _adminid = value; }
        public string Adminpwd { get => _adminpwd; set => _adminpwd = value; }
    }
}
