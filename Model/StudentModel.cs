using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class StudentModel
    {
        public StudentModel(int id, string sid, string spwd, string sname, string scolleges, string sroom, string slivedate, string sage, string ssex, string sadress, string sclass, string sphone )
        {
            this.Id= id;
            this.Sid= sid;
            this.Spwd= spwd;
            this.Sname= sname;
            this.Scolleges= scolleges;
            this.Sroom= sroom;
            this.Slivedate= slivedate;
            this.Sage= sage;
            this.Ssex= ssex;
            this.Sadress= sadress;
            this.Sclass= sclass;
            this.Sphone= sphone;

        }
        private int _id;
        private string _sid;
        private string _spwd;
        private string _sname;
        private string _scolleges;
        private string _sroom;
        private string _slivedate;
        private string _sage;
        private string _ssex;
        private string _sadress;
        private string _sclass;
        private string _sphone;

        public int Id { get => _id; set => _id = value; }
        public string Sid { get => _sid; set => _sid = value; }
        public string Spwd { get => _spwd; set => _spwd = value; }
        public string Sname { get => _sname; set => _sname = value; }
        public string Scolleges { get => _scolleges; set => _scolleges = value; }
        public string Sroom { get => _sroom; set => _sroom = value; }
        public string Slivedate { get => _slivedate; set => _slivedate = value; }
        public string Sage { get => _sage; set => _sage = value; }
        public string Ssex { get => _ssex; set => _ssex = value; }
        public string Sadress { get => _sadress; set => _sadress = value; }
        public string Sclass { get => _sclass; set => _sclass = value; }
        public string Sphone { get => _sphone; set => _sphone = value; }
    }
    
}
