using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOSystem.Models.Concretes
{
    public class Fatura
    {
        public int UserId { get; set; }
        public int FaturaId { get; set; }
        public double Tutar { get; set; }
        public ulong TcNo { get; set; }
        public string Adress { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
