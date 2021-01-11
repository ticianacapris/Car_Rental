using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POO
{
    [XmlRoot("VeiculoLigeiro")]
    public class VLigeiro : Veiculos 
    {
        private string COMBUSTIVEL;

        public VLigeiro() : base()
        {
        }

        public VLigeiro(string _matricula, string _tipoveiculo, string _marcamodelo, int _seguroanual, 
            int _consumo, int _precodiario, int _km, int _nreq, string _ano, string _combustivel, bool _alugado)
            : base(_matricula, _tipoveiculo, _marcamodelo, _seguroanual, _consumo, _precodiario, _km, _nreq, _ano, _alugado)
   
        {
            COMBUSTIVEL = _combustivel;
        }

        [XmlElement("Combustivel")]
        public string obtercombustivel
        {
            get { return COMBUSTIVEL;}
            set { COMBUSTIVEL = value; }
        }

        public override void gravarVeiculoTXT(StreamWriter ficheirov)
        {
            base.gravarVeiculoTXT(ficheirov);

            ficheirov.WriteLine("|" + COMBUSTIVEL);

        }

      
    }
}
