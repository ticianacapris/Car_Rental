using System.Collections.Generic;
using System.Xml.Serialization;

namespace POO
{
    [XmlRoot("RelatorioCliente")]
    public class RelatorioCliente
    {
        [XmlElement]
        public int ID { get; set; }
        [XmlElement]
        public string NOME { get; set; }
        [XmlElement]
        public string MORADA { get; set; }
        [XmlElement]
        public string NIF { get; set; }
        [XmlElement]
        public string CONTACTO { get; set; }
        [XmlElement]
        public string TIPO { get; set; }
        [XmlElement]
        public int IDADE { get; set; }
        [XmlElement]
        public float CAPITALSOCIAL { get; set; }

        [XmlArray("Historico")]
        public List<Aluguer> Historico { get; set; }

        public RelatorioCliente()
        {
            Historico = new List<Aluguer>();
        }
    }
}
