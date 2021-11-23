using System;
using System.Collections.Generic;

#nullable disable

namespace UCPPAW.Models
{
    public partial class Pembayaran
    {
        public int IdPembayaran { get; set; }
        public DateTime? TanggalBayar { get; set; }
        public int? TotalBayar { get; set; }
        public int? IdTransaksi { get; set; }

        public virtual Transaksi TotalBayarNavigation { get; set; }
    }
}
