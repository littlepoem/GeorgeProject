using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LeaveModel
    {
        public LeaveModel(int id,string studentid,string roomnumber,string leavetime,string leavereason,string backtime)
        {
            this.Id = id;
            this.Studentid = studentid;
            this.Leavetime = leavetime;
            this.Leavereason = leavereason;
            this.Backtime = backtime;
        }
        private int _id;
        private string _studentid;
        private string _roomnumber;
        private string _leavetime;
        private string _leavereason;
        private string _backtime;

        public int Id { get => _id; set => _id = value; }
        public string Studentid { get => _studentid; set => _studentid = value; }
        public string Roomnumber { get => _roomnumber; set => _roomnumber = value; }
        public string Leavetime { get => _leavetime; set => _leavetime = value; }
        public string Leavereason { get => _leavereason; set => _leavereason = value; }
        public string Backtime { get => _backtime; set => _backtime = value; }
    }
}
