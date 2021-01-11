using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POO
{
    [XmlRoot("VeiculoPesado")]
    public class VPesado : Veiculos
    {
        private string  AUTOMATICO;

        public VPesado() : base()
        {
        }

        public VPesado(string _matricula, string _tipoveiculo, string _marcamodelo, int _seguroanual,
            int _consumo, int _precodiario, int _km, int _nreq, string _ano, string _automatico, bool _alugado)
            : base(_matricula, _tipoveiculo, _marcamodelo, _seguroanual, _consumo, _precodiario, _km, _nreq, _ano, _alugado)
        {
            AUTOMATICO = _automatico;
        }

        [XmlElement("Transmissao")]
        public string obtertransmissao
        {
            get { return AUTOMATICO; }
            set { AUTOMATICO = value; }
        }

        public override void gravarVeiculoTXT(StreamWriter ficheirov)
        {
            base.gravarVeiculoTXT(ficheirov);

            ficheirov.WriteLine("|" + AUTOMATICO);

        }

    }
}
