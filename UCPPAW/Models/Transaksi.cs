using System;
using System.Collections.Generic;

#nullable disable

namespace UCPPAW.Models
{
    public partial class Transaksi
    {
        public Transaksi()
        {
            Pembayarans = new HashSet<Pembayaran>();
        }

        public int IdTransaksi { get; set; }
        public int? IdBarang { get; set; }
        public int? IdCustomer { get; set; }
        public DateTime? Tanggal { get; set; }

        public virtual Barang IdBarangNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual ICollection<Pembayaran> Pembayarans { get; set; }
    }
}
