using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POO
{
    public class Veiculos
    {
        protected string MATRICULA;
        protected string TIPOVEICULO;
        protected string MARCAMODELO;
        protected int SEGUROANUAL;
        protected int CONSUMO;
        protected int PRECODIARIO;
        protected int KM;
        protected int NREQ;
        protected string ANO;
        protected bool ALUGADO;

        public Veiculos()
        {
        }

        public Veiculos(string _matricula, string _tipoveiculo, string _marcamodelo, int _seguroanual,
            int _consumo, int _precodiario, int _km, int _nreq, string _ano, bool _alugado)
        {
            MATRICULA = _matricula;
            TIPOVEICULO = _tipoveiculo;
            MARCAMODELO = _marcamodelo;
            SEGUROANUAL = _seguroanual;
            CONSUMO = _consumo;
            PRECODIARIO = _precodiario;
            KM = _km;
            NREQ = _nreq;
            ANO = _ano;
            ALUGADO = _alugado;
        }

        [XmlElement("Matricula")]
        public string obtermatricula
        {
            get { return MATRICULA; }
            set { MATRICULA = value; }
        }
        [XmlElement("TipoVeiculo")]
        public string obtertipoveiculo
        {
            get { return TIPOVEICULO; }
            set { TIPOVEICULO = value; }
        }
        [XmlElement("MarcaModelo")]
        public string obtermarcamodelo
        {
            get { return MARCAMODELO; }
            set { MARCAMODELO = value; }
        }
        [XmlElement("SeguroAnual")]
        public int obterseguroanual
        {
            get { return SEGUROANUAL; }
            set { SEGUROANUAL = value; }
        }
        [XmlElement("Consumo")]
        public int obterconsumo
        {
            get { return CONSUMO; }
            set { CONSUMO = value; }
        }
        [XmlElement("PrecoDiario")]
        public int obterprecodiario
        {
            get { return PRECODIARIO; }
            set { PRECODIARIO = value; }
        }
        [XmlElement("Kms")]
        public int obterkm
        {
            get { return KM; }
            set { KM = value; }
        }
        [XmlElement("NumRequisicoes")]
        public int obternreq
        {
            get { return NREQ; }
            set { NREQ = value; }
        }
        [XmlElement("Ano")]
        public string obterano
        {
            get { return ANO; }
            set { ANO = value; }
        }
        [XmlElement("Alugado")]
        public bool obteralugado
        {
            get { return ALUGADO; }
            set { ALUGADO = value; }
        }

        public string mostrardados_veiculos()
        {
            string dados_veiculos;
            dados_veiculos = "Matricula:" + MATRICULA + "/n" +
                "Tipo de veiculo:" + TIPOVEICULO + "/n" +
                "Marca e modelo:" + MARCAMODELO + "/n" +
                "Seguro anual:" + SEGUROANUAL + "/n" +
                "Consumo:" + CONSUMO + "/n" +
                "Preço diário:" + PRECODIARIO + "/n" +
                "Km:" + KM + "/n" +
                "Numero de requisições:" + NREQ + "/n" +
                "Ano:" + ANO + "/n" +
                "Alugado:" + (ALUGADO ? "Sim" : "Não");

            return dados_veiculos;
        }

        public virtual void gravarVeiculoTXT(StreamWriter ficheirov)
        {
            ficheirov.Write(MATRICULA + "|" + TIPOVEICULO + "|" + MARCAMODELO + "|" + SEGUROANUAL
                + "|" + CONSUMO + "|" + PRECODIARIO + "|" + KM + "|" + NREQ + "|" + ANO + "|" + ALUGADO);
        }
    }
}