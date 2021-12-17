using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReportModel
    {
        public ReportModel(int id,string roomnumber,string article,string submissiontime,string reportreason)
        {
            this.Id = id;
            this.Roomnumber = roomnumber;
            this.Article = article;
            this.Submissiontime = submissiontime;
            this.Reportreason = reportreason;  
        }
        private int _id;
        private string _roomnumber;
        private string _article;
        private string _submissiontime;
        private string _reportreason;

        public int Id { get => _id; set => _id = value; }
        public string Roomnumber { get => _roomnumber; set => _roomnumber = value; }
        public string Article { get => _article; set => _article = value; }
        public string Submissiontime { get => _submissiontime; set => _submissiontime = value; }
        public string Reportreason { get => _reportreason; set => _reportreason = value; }
    }
}
