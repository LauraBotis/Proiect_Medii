using System.ComponentModel;

namespace Proiect_Medii.Models
{
    public class Programare
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string Ora { get; set; }
        public string Comentariu { get; set; }

        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu { get; set; }

        public int? ClientID { get; set; }
        public Client? Client { get; set; }

    }
}
