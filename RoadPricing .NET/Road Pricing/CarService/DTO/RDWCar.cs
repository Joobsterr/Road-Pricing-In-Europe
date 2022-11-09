namespace CarService.DTO
{
    public class RDWCar
    {
        public string kenteken { get; set; }
        public string voertuigsoort { get; set; }
        public string merk { get; set; }
        public string eerste_kleur { get; set; }
        public string datum_tenaamstelling { get; set; }

        public RDWCar(string kenteken, string voertuigsoort, string merk, string eerste_kleur, string datum_tenaamstelling)
        {
            this.kenteken = kenteken;
            this.voertuigsoort = voertuigsoort;
            this.merk = merk;
            this.eerste_kleur = eerste_kleur;
            this.datum_tenaamstelling = datum_tenaamstelling;
        }
    }
}
