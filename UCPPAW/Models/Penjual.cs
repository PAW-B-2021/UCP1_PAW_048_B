using System;
using System.Collections.Generic;

#nullable disable

namespace UCPPAW.Models
{
    public partial class Penjual
    {
        public Penjual()
        {
            Barangs = new HashSet<Barang>();
        }

        public int IdPenjual { get; set; }
        public byte[] NamaPenjual { get; set; }
        public string NoHp { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Barang> Barangs { get; set; }
    }
}
