using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POO
{
    [XmlRoot("ClienteParticular")]
    public class CParticular : Cliente
    {
        private int IDADE;
        public CParticular()
             : base()
        {
        }

        public CParticular(int _id, string _nome, string _morada, string _nif, string _contacto, string _tipo, int _idade)
            :base( _id,  _nome,  _morada,  _nif,  _contacto, _tipo)
        {
            IDADE = _idade;

        }

        [XmlElement("Idade")]
        public int obteridade
        {
            get { return IDADE; }
            set { IDADE = value; }
        }
        public override void gravarClienteTXT(StreamWriter ficheiro)
        {
            base.gravarClienteTXT(ficheiro);

            ficheiro.WriteLine("|" + IDADE);
        }
    }
}
