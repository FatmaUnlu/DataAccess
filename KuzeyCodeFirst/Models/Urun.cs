using KuzeyCodeFirst.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KuzeyCodeFirst.Models
{
    [Table ("Urunler")] //tabloda uruns diye oluşturmasın diye
    public class Urun : BaseEntity,IKey<int>
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; } = 0;
        public int KategoriId { get; set; }

        [Range(0,10000)]
        public int StokMiktari { get; set;}
        public bool DevamEtmiyorMu { get; set; }

        public Guid? TedarikciId { get; set; }


        [ForeignKey(nameof(KategoriId))] //nameof nesneyyi yanlış yazmaya izin vermez. Bir nesnenin o anki ismini string yapar
        public Kategori Kategori { get; set; }

       public ICollection <SiparisDetay> SiparisDetaylari { get; set; } = new HashSet <SiparisDetay> ();
        [ForeignKey(nameof(TedarikciId))]
        public Tedarikci Tedarikci { get; set; }
    }
}
