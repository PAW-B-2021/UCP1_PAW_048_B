using System;
using System.Collections.Generic;

#nullable disable

namespace UCPPAW.Models
{
    public partial class Barang
    {
        public Barang()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public int? Harga { get; set; }
        public int? StokBarang { get; set; }
        public int? IdPenjual { get; set; }

        public virtual Penjual IdPenjualNavigation { get; set; }
        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
