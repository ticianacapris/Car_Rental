using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POO
{
    [XmlRoot("ClienteEmpresarial")]
    public class CEmpresarial : Cliente
    {
        private float CAPITALSOCIAL;



        public CEmpresarial() : base()
        {
        }

        public CEmpresarial(int _id, string _nome, string _morada, string _nif, string _contacto, string _tipo, float _capitalsocial)
            : base(_id, _nome, _morada, _nif, _contacto, _tipo)
        {
            CAPITALSOCIAL = _capitalsocial;
        }

        [XmlElement("CapitalSocial")]
        public float obtercapital
        {
            get { return CAPITALSOCIAL; }
            set { CAPITALSOCIAL = value; }
        }
        public override void gravarClienteTXT(StreamWriter ficheiro)
        {
            base.gravarClienteTXT(ficheiro);
            //ficheiro.Write(ID + "|" + NOME + "|" + MORADA + "|" + CONTACTO + "|" + NIF + "|" + TIPO + "|" + CAPITALSOCIAL);

           ficheiro.Write("|" + CAPITALSOCIAL);

        }
        //public virtual void gravarClienteTXT(StreamWriter ficheiro)
        //{
        //    ficheiro.Write(ID + "|" + NOME + "|" + MORADA + "|" + CONTACTO + "|" + NIF + "|" + TIPO);


        //}


        public string mostrardados()
        {
            string dados;
            dados = "ID do cliente: " + ID + " \n" +
                "Nome do Cliente: " + NOME + "\n" +
                "Morada: " + MORADA + "\n" +
                "NIF: " + NIF + "\n" +
                "Contacto: " + CONTACTO + "\n" +
                "Tipo:" + TIPO + "\n" +
                "Capital Social" + CAPITALSOCIAL;

            // utilizar barra ao contrario
            return dados;

        }
    }
}
