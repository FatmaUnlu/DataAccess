using KuzeyCodeFirst.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyCodeFirst.Models
{
    [Table("Siparisler")]
    public class Siparis :BaseEntity, IKey<int>
    {
        [Key]
        public int Id { get; set; }
        public DateTime SiparisTarihi { get; set; } = DateTime.Now;
        [Column (TypeName ="smalldatetime")]
        public DateTime? UlasmaTarihi { get; set; }
        public ICollection<SiparisDetay> SiparisDetaylari { get; set; } = new HashSet<SiparisDetay>();
    }
}
