    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POO
{

    public class Cliente
    {
        protected int ID;
        protected string NOME;
        protected string MORADA;
        protected string NIF;
        protected string CONTACTO;
        protected string TIPO;

        public Cliente()
        {



        }


        public Cliente(int _id, string _nome, string _morada, string _nif, string _contacto, string _tipo)
        {
            ID = _id;
            NOME = _nome;
            MORADA = _morada;
            NIF = _nif;
            CONTACTO = _contacto;
            TIPO = _tipo;


        }
        [XmlElement("ID")]
        public int obterid
        {
            get { return ID; }
            set { ID = value; }
        }
        [XmlElement("Nome")]
        public string obternome
        {
            get { return NOME; }
            set { NOME = value; }
        }
        [XmlElement("Morada")]
        public string obtermorada
        {
            get { return MORADA; }
            set { MORADA = value; }
        }
        [XmlElement("NIF")]
        public string obternif
        {
            get { return NIF; }
            set { NIF = value; }
        }
        [XmlElement("Contacto")]
        public string obtercontact
        {
            get { return CONTACTO; }
            set { CONTACTO = value; }
        }
        [XmlElement("Tipo")]
        public string obtertipo
        {
            get { return TIPO; }
            set { TIPO = value; }
        }


        public string mostrardados()
        {
            string dados;
            dados = "ID do cliente: " + ID + " /n" +
                "Nome do Cliente: " + NOME + "/n" +
                "Morada: " + MORADA + "/n" +
                "NIF: " + NIF + "/n" +
                "Contacto: " + CONTACTO + "/n" +
                "Tipo:" + TIPO;

            // utilizar barra ao contrario
            return dados;

        }
        public virtual void gravarClienteTXT(StreamWriter ficheiro)
        {
            ficheiro.Write(ID + "|" + NOME + "|" + MORADA + "|" + CONTACTO + "|" + NIF + "|" + TIPO);

        }
    }
}

    


