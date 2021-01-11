using System;
using System.IO;
using System.Xml.Serialization;

namespace POO
{
    [XmlRoot("Aluguer")]
    public class Aluguer
    {
        [XmlElement]
        public string IdCliente { get; set; }
        [XmlElement]
        public string Matricula { get; set; }
        [XmlElement]
        public DateTime DataDesde { get; set; }
        [XmlElement]
        public DateTime DataAte { get; set; }
        [XmlElement]
        public double CustoAluguer { get; set; }
        [XmlElement]
        public bool Devolvido { get; set; }
        [XmlElement]
        public double Kms { get; set; }

        public Aluguer()
        {
        }

        public Aluguer(string idCliente, string matricula, DateTime dataDesde, DateTime dataAte, double custoAluguer)
        {
            IdCliente = idCliente;
            Matricula = matricula;
            DataDesde = dataDesde;
            DataAte = dataAte;
            CustoAluguer = custoAluguer;
            Devolvido = false;
            Kms = 0;
        }

        public void gravarAluguerTXT(StreamWriter ficheiro)
        {
            ficheiro.WriteLine(IdCliente + "|" + Matricula + "|" + DataDesde + "|" + DataAte + "|" + CustoAluguer + "|" + Devolvido + "|" + Kms);
        }
    }
}
