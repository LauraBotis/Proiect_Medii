using System.ComponentModel;

namespace Proiect_Medii.Models
{
    public class Serviciu
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        [DisplayName("Preț")]
        public decimal Pret {  get; set; }
        [DisplayName("Durată")]
        public int Durata { get; set; }

        public int? AngajatID { get; set; }
        public Angajat? Angajat { get; set; }

        public ICollection<Programare>? Programari { get; set; }


    }
}
