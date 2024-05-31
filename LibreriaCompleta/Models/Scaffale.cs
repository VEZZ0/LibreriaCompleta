using LibreriaCompleta.Models.Dto;

namespace LibreriaCompleta.Models
{
    public static class Scaffale
    {
        public static List<LibroDTO> listaLibri = new List<LibroDTO>();

        static Scaffale()
        {
            listaLibri = new List<LibroDTO>
            {
                new LibroDTO { titolo = "Biografia di TortaSaker", autore = "Gio Lopez", genere = "Saggistica", isbn = "666666666666666" },
                new LibroDTO { titolo = "Java per impazienti", autore = "Fabio Panozzo", genere = "Tragedia", isbn = "1234567890123" },
                new LibroDTO { titolo = "Leopardi spiegato ai bambini", autore = "Alberto Airoldi", genere = "Commedia", isbn = "000000000000000" }
            };
        }
        public static List<LibroDTO> getListaLibri() => listaLibri;
    }
}
