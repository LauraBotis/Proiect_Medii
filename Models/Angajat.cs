namespace Proiect_Medii.Models
{
    public class Angajat
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Descriere { get; set; }
       public ICollection<Serviciu>? Servicii { get; set; }
    }
}
