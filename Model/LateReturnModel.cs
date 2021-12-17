using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LateReturnModel
    {
        public LateReturnModel(int id,string studentid,string roomnumber,string returntime,string returnreason)
        {
            this.Id = id;
            this.Studentid = studentid;
            this.Roomnumber = roomnumber;
            this.Returntime = returntime;
            this.Returnreason = returnreason;
        }
        private int _id;
        private string _studentid;
        private string _roomnumber;
        private string _returntime;
        private string _returnreason;

        public int Id { get => _id; set => _id = value; }
        public string Studentid { get => _studentid; set => _studentid = value; }
        public string Roomnumber { get => _roomnumber; set => _roomnumber = value; }
        public string Returntime { get => _returntime; set => _returntime = value; }
        public string Returnreason { get => _returnreason; set => _returnreason = value; }
    }
}
