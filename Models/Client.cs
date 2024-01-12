using System.Net.Mail;

namespace Proiect_Medii.Models
{
    public class Client
    { 
        public int Id { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Username { get; set; }
        public string Email { get; set; }

        public ICollection<Programare>? Programari { get; set; }

        
    }
}
