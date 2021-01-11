using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace POO
{
    public class Gestao
    {
        //List<Cliente> LC = new List<Cliente>();
        List<CEmpresarial> LCE = new List<CEmpresarial>();
        List<CParticular> LCP = new List<CParticular>();
        List<Veiculos> LV = new List<Veiculos>();
        List<VLigeiro> LVL = new List<VLigeiro>();
        List<VPesado> LVP = new List<VPesado>();
        List<Aluguer> LA = new List<Aluguer>();

        //     para funcionar sem txt //
        //List<Aluguer> LA = new List<Aluguer>()
        //{
        //    new Aluguer()
        //    {
        //        IdCliente = "3",
        //        Matricula = "11-EE-33",
        //        DataDesde = DateTime.Now,
        //        DataAte = DateTime.Now.AddDays(1),
        //        CustoAluguer = 50,
        //        Devolvido = false,
        //        Kms = 50
        //    },
        //    new Aluguer()
        //    {
        //        IdCliente = "3",
        //        Matricula = "33",
        //        DataDesde = DateTime.Now,
        //        DataAte = DateTime.Now.AddDays(2),
        //        CustoAluguer = 100,
        //        Devolvido = false,
        //        Kms = 150
        //    }
        //};



        public Gestao()
        {
            //LC = new List<Cliente>();
            //LCE = new List<CEmpresarial>();
            //LCP = new List<CParticular>();
            //LV = new List<Veiculos>();
            //LVL = new List<VLigeiro>();
            //LVP = new List<VPesado>();
        }

        //********************************************************** CLIENTES **************************************************************\\

        public void AddClienteEmpresa(int id, string nome, string morada, string contacto, string nif, string tipo, float capital)
        {
            CEmpresarial aux_empresa = new CEmpresarial();

            aux_empresa.obterid = id;
            aux_empresa.obternome = nome;
            aux_empresa.obtermorada = morada;
            aux_empresa.obtercontact = contacto;
            aux_empresa.obternif = nif;
            aux_empresa.obtertipo = tipo;
            aux_empresa.obtercapital = capital;

            if (aux_empresa.obtertipo.Equals("Empresa"))
            {
                LCE.Add(aux_empresa);
            }

            //gravarClienteEmpresaTXT();


            //o id passa a ser incrementado a partir do id mais alto
            /*int id = 0;
            foreach (Cliente c in LC)
            {
                if (Convert.ToInt32(c.obterid) > id)
                {
                    id = Convert.ToInt32(c.obterid);
                }
            }
           */
        }

        public void AddClienteParticular(int id, string nome, string morada, string contacto, string nif, string tipo, int idade)
        {
            CParticular aux_p = new CParticular();

            aux_p.obterid = id;
            aux_p.obternome = nome;
            aux_p.obtermorada = morada;
            aux_p.obtercontact = contacto;
            aux_p.obternif = nif;
            aux_p.obtertipo = tipo;
            aux_p.obteridade = idade;

            if (aux_p.obtertipo.Equals("Particular"))
            {
                LCP.Add(aux_p);
            }

            //gravarClienteParticularTXT();
        }

        //public int GetNCliente()
        //{
        //    return LC.Count;
        //}
        public int GetNClienteP()
        {
            return LCP.Count;
        }
        public int GetNClienteEm()
        {
            return LCE.Count;
        }
        //public List<Cliente> RetornarListaCliente()
        //{
        //    return LC;
        //}
        public List<CParticular> RetornarLCP()
        {
            return LCP;
        }

        public List<CEmpresarial> RetornarLCE()
        {
            return LCE;
        }
        public void gravarClienteEmpresaTXT()
        {
            StreamWriter ficheiro = new StreamWriter("../../ClientesEmpresa.txt");

            foreach (CEmpresarial c in LCE)
            {
                c.gravarClienteTXT(ficheiro);
            }

            ficheiro.Close();

            //REF      ficheiro.Write(ID + "|" + NOME + "|" + MORADA + "|" + CONTACTO + "|" + NIF + "|" + TIPO);

            //StreamWriter ficheiro = new StreamWriter("../../ClientesEmpresa.txt");

            // foreach (CEmpresarial c in LCE)
            // {
            // ficheiro.WriteLine(c.obterid + "|" + c.obternome + "|" + c.obtermorada + "|" + c.obtercontact + "|" + c.obternif + 
            //"|" + c.obtertipo + "|" + c.obtercapital);
            // }
        }

        public void gravarClienteParticularTXT()
        {
            StreamWriter ficheiro = new StreamWriter("../../Clientes.txt");

            foreach (CParticular gravar in LCP)
            {
                gravar.gravarClienteTXT(ficheiro);
                //ficheiro.WriteLine(gravar.obterid + "|" + gravar.obternome + "|" + gravar.obtermorada + "|" + gravar.obtercontact +
                //"|" + gravar.obternif + "|" + gravar.obtertipo + "|" + gravar.obteridade);
            }
            ficheiro.Close();

            /*
                else if (c.obtertipo.Equals("Particular"))
                {
                    CParticular cliente = (CParticular)c;
                    ficheiro.WriteLine(cliente.obterid.ToString() + "|" + cliente.obternome.ToString() + "|" + cliente.obtermorada.ToString() + "|" + cliente.obtercontact.ToString() + "|" + cliente.obternif.ToString() + "|" + cliente.obtertipo.ToString());
                }*/
        }

        public void gravarClientesTXT()
        {
            StreamWriter ficheiro = new StreamWriter("../../Clientes.txt");

            foreach (CParticular cliente in LCP)
            {
                cliente.gravarClienteTXT(ficheiro);
            }

            foreach (CEmpresarial cliente in LCE)
            {
                cliente.gravarClienteTXT(ficheiro);
            }

            ficheiro.Close();
        }

        public CParticular Pesquisa_ClienteParticular(string nif)
        {
            if (LCP.Count == 0) return null;
            Console.WriteLine("Pesq[" + nif + "]");
            foreach (CParticular c in LCP)
            {
                Console.WriteLine("----->[" + c.obternif + "]");
                if (c.obternif.CompareTo(nif) == 0)
                    return c;
            }
            return null;
        }
        public CEmpresarial Pesquisa_ClienteEmpresarial(string nif)
        {
            if (LCE.Count == 0) return null;
            Console.WriteLine("Pesq[" + nif + "]");
            foreach (CEmpresarial ce in LCE)
            {
                Console.WriteLine("----->[" + ce.obterid + "]");
                if (ce.obternif.CompareTo(nif) == 0)
                    return ce;
            }
            return null;

        }


        public void apagarClienteParticular(int id)
        {
            for (int i = LCP.Count - 1; i >= 0; i--)
            {
                if (LCP[i].obterid == id)
                {
                    LCP.Remove(LCP[i]);
                    break;
                    //LCP.RemoveAt(i);
                }
            }
            /*  LC.RemoveAt(id);
            //gravarClienteTXT();
            loadParticularClientesTXT(); */
        }
        public void apagarClienteEmpresa(int id)
        {
            for (int i = LCE.Count - 1; i >= 0; i--)
            {
                if (LCE[i].obterid == id)
                {
                    LCE.Remove(LCE[i]);
                    break;
                }
            }
        }

        public void loadParticularClientesTXT()
        {
            if (!File.Exists("../../Clientes.txt"))
            {
                StreamWriter cp = new StreamWriter("../../Clientes.txt");
                cp.Close();
            }
            StreamReader ficheiroP = new StreamReader("../../Clientes.txt");

            string linhaElemento;
            string[] elementosDivididos;

            while ((linhaElemento = ficheiroP.ReadLine()) != null)
            {
                CParticular ClienteNovo = new CParticular();

                elementosDivididos = linhaElemento.Split('|');

                ClienteNovo.obterid = Convert.ToInt32(elementosDivididos[0]);
                ClienteNovo.obternome = elementosDivididos[1];
                ClienteNovo.obtermorada = elementosDivididos[2];
                ClienteNovo.obtercontact = elementosDivididos[3];
                ClienteNovo.obternif = elementosDivididos[4];
                ClienteNovo.obtertipo = elementosDivididos[5];
                ClienteNovo.obteridade = Convert.ToInt32(elementosDivididos[6]);


                if (ClienteNovo.obtertipo.Equals("Particular"))
                {
                    LCP.Add(new CParticular(ClienteNovo.obterid, ClienteNovo.obternome, ClienteNovo.obtermorada, ClienteNovo.obtercontact,
                      ClienteNovo.obternif, ClienteNovo.obtertipo, ClienteNovo.obteridade));
                }

            }

            ficheiroP.Close();

        }
        public void LerEmpresaTXT()
        {
            if (!File.Exists("../../ClientesEmpresa.txt"))
            {
                StreamWriter cemp = new StreamWriter("../../ClientesEmpresa.txt");
                cemp.Close();
            }
            StreamReader fempresa = new StreamReader("../../ClientesEmpresa.txt");

            string linhaElemento;
            string[] elementosDivididos;

            while ((linhaElemento = fempresa.ReadLine()) != null)
            {

                CEmpresarial ClienteEmpresarial = new CEmpresarial();

                elementosDivididos = linhaElemento.Split('|');

                ClienteEmpresarial.obterid = Convert.ToInt32(elementosDivididos[0]);
                ClienteEmpresarial.obternome = elementosDivididos[1];
                ClienteEmpresarial.obtermorada = elementosDivididos[2];
                ClienteEmpresarial.obtercontact = elementosDivididos[3];
                ClienteEmpresarial.obternif = elementosDivididos[4];
                ClienteEmpresarial.obtertipo = elementosDivididos[5];
                ClienteEmpresarial.obtercapital = Convert.ToSingle(elementosDivididos[6]);


                if (ClienteEmpresarial.obtertipo.Equals("Empresa"))
                //(ClienteEmpresarial.obtercapital.ToString() != string.Empty)

                {
                    LCE.Add(new CEmpresarial(ClienteEmpresarial.obterid, ClienteEmpresarial.obternome, ClienteEmpresarial.obtermorada, ClienteEmpresarial.obtercontact,
                     ClienteEmpresarial.obternif, ClienteEmpresarial.obtertipo, ClienteEmpresarial.obtercapital));

                    //LCE.Add(new CEmpresarial(elementosDivididos[0], elementosDivididos[1], elementosDivididos[2], elementosDivididos[3], 
                    //elementosDivididos[4],
                    //elementosDivididos[5], Convert.ToSingle(elementosDivididos[6])));

                }

            }
            fempresa.Close();

        }

        public void loadClientesTXT()
        {
            if (!File.Exists("../../Clientes.txt"))
            {
                StreamWriter cp = new StreamWriter("../../Clientes.txt");
                cp.Close();
            }

            StreamReader ficheiroP = new StreamReader("../../Clientes.txt");

            string linhaElemento;
            string[] elementosDivididos;

            while ((linhaElemento = ficheiroP.ReadLine()) != null)
            {
                elementosDivididos = linhaElemento.Split('|');

                if (elementosDivididos[5] == "Particular")
                {
                    CParticular ClienteNovo = new CParticular();

                    ClienteNovo.obterid = Convert.ToInt32(elementosDivididos[0]);
                    ClienteNovo.obternome = elementosDivididos[1];
                    ClienteNovo.obtermorada = elementosDivididos[2];
                    ClienteNovo.obtercontact = elementosDivididos[3];
                    ClienteNovo.obternif = elementosDivididos[4];
                    ClienteNovo.obtertipo = elementosDivididos[5];
                    ClienteNovo.obteridade = Convert.ToInt32(elementosDivididos[6]);

                    LCP.Add(new CParticular(ClienteNovo.obterid, ClienteNovo.obternome, ClienteNovo.obtermorada, ClienteNovo.obtercontact,
                      ClienteNovo.obternif, ClienteNovo.obtertipo, ClienteNovo.obteridade));
                }
                else
                {
                    CEmpresarial ClienteEmpresarial = new CEmpresarial();

                    ClienteEmpresarial.obterid = Convert.ToInt32(elementosDivididos[0]);
                    ClienteEmpresarial.obternome = elementosDivididos[1];
                    ClienteEmpresarial.obtermorada = elementosDivididos[2];
                    ClienteEmpresarial.obtercontact = elementosDivididos[3];
                    ClienteEmpresarial.obternif = elementosDivididos[4];
                    ClienteEmpresarial.obtertipo = elementosDivididos[5];
                    ClienteEmpresarial.obtercapital = Convert.ToSingle(elementosDivididos[6]);

                    LCE.Add(new CEmpresarial(ClienteEmpresarial.obterid, ClienteEmpresarial.obternome, ClienteEmpresarial.obtermorada, ClienteEmpresarial.obtercontact,
                     ClienteEmpresarial.obternif, ClienteEmpresarial.obtertipo, ClienteEmpresarial.obtercapital));
                }
            }

            ficheiroP.Close();
        }

        //********************************************************** VEICULOS **************************************************************\\

        public void AddVeiculoLigeiro(string _matricula, string _tipoveiculo, string _marcamodelo, int _seguroanual,
            int _consumo, int _precodiario, int _km, int _nreq, string _ano, string _combustivel)
        {
            VLigeiro aux_ligeiro = new VLigeiro();

            aux_ligeiro.obtermatricula = _matricula;
            aux_ligeiro.obtertipoveiculo = _tipoveiculo;
            aux_ligeiro.obtermarcamodelo = _marcamodelo;
            aux_ligeiro.obterseguroanual = _seguroanual;
            aux_ligeiro.obterconsumo = _consumo;
            aux_ligeiro.obterprecodiario = _precodiario;
            aux_ligeiro.obterkm = _km;
            aux_ligeiro.obternreq = _nreq;
            aux_ligeiro.obterano = _ano;
            aux_ligeiro.obtercombustivel = _combustivel;

            LVL.Add(aux_ligeiro);

            //gravarVeiculoLigeiroTXT();
        }

        public void AddVeiculoPesado(string _matricula, string _tipoveiculo, string _marcamodelo, int _seguroanual,
            int _consumo, int _precodiario, int _km, int _nreq, string _ano, string _automatico)
        {
            VPesado aux_pesado = new VPesado();

            aux_pesado.obtermatricula = _matricula;
            aux_pesado.obtertipoveiculo = _tipoveiculo;
            aux_pesado.obtermarcamodelo = _marcamodelo;
            aux_pesado.obterseguroanual = _seguroanual;
            aux_pesado.obterconsumo = _consumo;
            aux_pesado.obterprecodiario = _precodiario;
            aux_pesado.obterkm = _km;
            aux_pesado.obternreq = _nreq;
            aux_pesado.obterano = _ano;
            aux_pesado.obtertransmissao = _automatico;


            LVP.Add(aux_pesado);
        }

        public int GetNVeiculo()
        {
            return LV.Count;
        }

        public List<Veiculos> RetornarListaVeiculo()
        {
            return LV;
        }

        public List<VLigeiro> RetornarLVL()
        {
            return LVL;
        }

        public List<VPesado> RetornarLVP()
        {
            return LVP;
        }

        public List<Aluguer> RetornarLA()
        {
            return LA;
        }

        public void gravarVeiculoLigeiroTXT()
        {
            StreamWriter ficheirov = new StreamWriter("../../VeiculosLigeiros.txt");

            foreach (VLigeiro vl in LVL)
            {
                vl.gravarVeiculoTXT(ficheirov);
            }

            ficheirov.Close();
        }

        public void gravarVeiculoPesadoTXT()
        {
            StreamWriter ficheirov = new StreamWriter("../../VeiculosPesados.txt");

            foreach (VPesado v in LVP)
            {
                v.gravarVeiculoTXT(ficheirov);
            }

            ficheirov.Close();
        }

        public void gravarVeiculosTXT()
        {
            StreamWriter ficheirov = new StreamWriter("../../Veiculos.txt");

            foreach (VLigeiro v in LVL)
            {
                v.gravarVeiculoTXT(ficheirov);
            }

            foreach (VPesado v in LVP)
            {
                v.gravarVeiculoTXT(ficheirov);
            }

            ficheirov.Close();
        }

        public void loadLigeiroVeiculosTXT()
        {
            if (!File.Exists("../../VeiculosLigeiros.txt"))
            {
                StreamWriter vl = new StreamWriter("../../VeiculosLigeiros.txt");
                vl.Close();
            }
            StreamReader ficheiroL = new StreamReader("../../VeiculosLigeiros.txt", true);

            string linhaElemento;
            string[] elementosDivididos;

            while ((linhaElemento = ficheiroL.ReadLine()) != null)
            {
                VLigeiro LigeiroNovo = new VLigeiro();

                elementosDivididos = linhaElemento.Split('|');

                LigeiroNovo.obtermatricula = elementosDivididos[0];
                LigeiroNovo.obtertipoveiculo = elementosDivididos[1];
                LigeiroNovo.obtermarcamodelo = elementosDivididos[2];
                LigeiroNovo.obterseguroanual = Convert.ToInt32(elementosDivididos[3]);
                LigeiroNovo.obterconsumo = Convert.ToInt32(elementosDivididos[4]);
                LigeiroNovo.obterprecodiario = Convert.ToInt32(elementosDivididos[5]);
                LigeiroNovo.obterkm = Convert.ToInt32(elementosDivididos[6]);
                LigeiroNovo.obternreq = Convert.ToInt32(elementosDivididos[7]);
                LigeiroNovo.obterano = elementosDivididos[8];
                LigeiroNovo.obteralugado = Boolean.Parse(elementosDivididos[9]);
                LigeiroNovo.obtercombustivel = elementosDivididos[10];

                if (LigeiroNovo.obtertipoveiculo.Equals("Ligeiro"))
                {
                    LVL.Add(new VLigeiro(LigeiroNovo.obtermatricula, LigeiroNovo.obtertipoveiculo, LigeiroNovo.obtermarcamodelo, LigeiroNovo.obterseguroanual,
                      LigeiroNovo.obterconsumo, LigeiroNovo.obterprecodiario, LigeiroNovo.obterkm, LigeiroNovo.obternreq, LigeiroNovo.obterano,
                      LigeiroNovo.obtercombustivel, LigeiroNovo.obteralugado));
                }

            }

            ficheiroL.Close();
        }

        public void loadPesadoVeiculosTXT()
        {
            if (!File.Exists("../../VeiculosPesados.txt"))
            {
                StreamWriter vp = new StreamWriter("../../VeiculosPesados.txt");
                vp.Close();
            }

            StreamReader ficheiroP = new StreamReader("../../VeiculosPesados.txt", true);

            string linhaElemento;
            string[] elementosDivididos;

            while ((linhaElemento = ficheiroP.ReadLine()) != null)
            {
                VPesado PesadoNovo = new VPesado();

                elementosDivididos = linhaElemento.Split('|');

                PesadoNovo.obtermatricula = elementosDivididos[0];
                PesadoNovo.obtertipoveiculo = elementosDivididos[1];
                PesadoNovo.obtermarcamodelo = elementosDivididos[2];
                PesadoNovo.obterseguroanual = Convert.ToInt32(elementosDivididos[3]);
                PesadoNovo.obterconsumo = Convert.ToInt32(elementosDivididos[4]);
                PesadoNovo.obterprecodiario = Convert.ToInt32(elementosDivididos[5]);
                PesadoNovo.obterkm = Convert.ToInt32(elementosDivididos[6]);
                PesadoNovo.obternreq = Convert.ToInt32(elementosDivididos[7]);
                PesadoNovo.obterano = elementosDivididos[8];
                PesadoNovo.obteralugado = Boolean.Parse(elementosDivididos[9]);
                PesadoNovo.obtertransmissao = elementosDivididos[10];

                if (PesadoNovo.obtertipoveiculo.Equals("Pesado"))
                {
                    LVP.Add(new VPesado(PesadoNovo.obtermatricula, PesadoNovo.obtertipoveiculo, PesadoNovo.obtermarcamodelo, PesadoNovo.obterseguroanual,
                      PesadoNovo.obterconsumo, PesadoNovo.obterprecodiario, PesadoNovo.obterkm, PesadoNovo.obternreq, PesadoNovo.obterano,
                      PesadoNovo.obtertransmissao, PesadoNovo.obteralugado));
                }
            }

            ficheiroP.Close();
        }

        public void loadVeiculosTXT()
        {
            if (!File.Exists("../../Veiculos.txt"))
            {
                StreamWriter vl = new StreamWriter("../../Veiculos.txt");
                vl.Close();
            }

            StreamReader ficheiro = new StreamReader("../../Veiculos.txt", true);

            string linhaElemento;
            string[] elementosDivididos;

            while ((linhaElemento = ficheiro.ReadLine()) != null)
            {
                elementosDivididos = linhaElemento.Split('|');

                if (elementosDivididos[1] == "Ligeiro")
                {
                    VLigeiro LigeiroNovo = new VLigeiro();

                    LigeiroNovo.obtermatricula = elementosDivididos[0];
                    LigeiroNovo.obtertipoveiculo = elementosDivididos[1];
                    LigeiroNovo.obtermarcamodelo = elementosDivididos[2];
                    LigeiroNovo.obterseguroanual = Convert.ToInt32(elementosDivididos[3]);
                    LigeiroNovo.obterconsumo = Convert.ToInt32(elementosDivididos[4]);
                    LigeiroNovo.obterprecodiario = Convert.ToInt32(elementosDivididos[5]);
                    LigeiroNovo.obterkm = Convert.ToInt32(elementosDivididos[6]);
                    LigeiroNovo.obternreq = Convert.ToInt32(elementosDivididos[7]);
                    LigeiroNovo.obterano = elementosDivididos[8];
                    LigeiroNovo.obteralugado = Boolean.Parse(elementosDivididos[9]);
                    LigeiroNovo.obtercombustivel = elementosDivididos[10];

                    LVL.Add(new VLigeiro(LigeiroNovo.obtermatricula, LigeiroNovo.obtertipoveiculo, LigeiroNovo.obtermarcamodelo, LigeiroNovo.obterseguroanual,
                      LigeiroNovo.obterconsumo, LigeiroNovo.obterprecodiario, LigeiroNovo.obterkm, LigeiroNovo.obternreq, LigeiroNovo.obterano,
                      LigeiroNovo.obtercombustivel, LigeiroNovo.obteralugado));
                }
                else
                {
                    VPesado PesadoNovo = new VPesado();

                    PesadoNovo.obtermatricula = elementosDivididos[0];
                    PesadoNovo.obtertipoveiculo = elementosDivididos[1];
                    PesadoNovo.obtermarcamodelo = elementosDivididos[2];
                    PesadoNovo.obterseguroanual = Convert.ToInt32(elementosDivididos[3]);
                    PesadoNovo.obterconsumo = Convert.ToInt32(elementosDivididos[4]);
                    PesadoNovo.obterprecodiario = Convert.ToInt32(elementosDivididos[5]);
                    PesadoNovo.obterkm = Convert.ToInt32(elementosDivididos[6]);
                    PesadoNovo.obternreq = Convert.ToInt32(elementosDivididos[7]);
                    PesadoNovo.obterano = elementosDivididos[8];
                    PesadoNovo.obteralugado = Boolean.Parse(elementosDivididos[9]);
                    PesadoNovo.obtertransmissao = elementosDivididos[10];

                    LVP.Add(new VPesado(PesadoNovo.obtermatricula, PesadoNovo.obtertipoveiculo, PesadoNovo.obtermarcamodelo, PesadoNovo.obterseguroanual,
                      PesadoNovo.obterconsumo, PesadoNovo.obterprecodiario, PesadoNovo.obterkm, PesadoNovo.obternreq, PesadoNovo.obterano,
                      PesadoNovo.obtertransmissao, PesadoNovo.obteralugado));
                }
            }

            ficheiro.Close();
        }

        public void AddAluguer(string idCliente, string matricula, DateTime dataDesde, DateTime dataAte, double custoAluguer, int num_req)
        {
            Aluguer aluguer = new Aluguer(idCliente, matricula, dataDesde, dataAte, custoAluguer);

            LA.Add(aluguer);

            // ligeiro
            foreach (var veiculo in LVL)
            {
                if (veiculo.obtermatricula == matricula)
                {
                    veiculo.obternreq = num_req;
                    veiculo.obteralugado = true;
                }
            }

            // pesado
            foreach (var veiculo in LVP)
            {
                if (veiculo.obtermatricula == matricula)
                {
                    veiculo.obternreq = num_req;
                    veiculo.obteralugado = true;
                }
            }
        }

        public List<Aluguer> pesquisaAluguer(string idCliente)
        {
            List<Aluguer> lista = new List<Aluguer>();

            foreach (Aluguer alug in LA)
            {
                if (alug.IdCliente == idCliente && !alug.Devolvido)
                {
                    lista.Add(alug);
                }
            }

            return lista;
        }

        public void devolverVeiculo(string idCliente, string matricula, double kms, double kmsTotais)
        {
            foreach (Aluguer alug in LA)
            {
                if (alug.IdCliente == idCliente && alug.Matricula == matricula)
                {
                    alug.Devolvido = true;
                    alug.Kms = kms;
                    break;
                }
            }

            // ligeiro
            foreach (var veiculo in LVL)
            {
                if (veiculo.obtermatricula == matricula)
                {
                    veiculo.obterkm = int.Parse(kmsTotais.ToString());
                    veiculo.obteralugado = false;
                }
            }

            // pesado
            foreach (var veiculo in LVP)
            {
                if (veiculo.obtermatricula == matricula)
                {
                    veiculo.obterkm = int.Parse(kmsTotais.ToString());
                    veiculo.obteralugado = false;
                }
            }
        }

        public List<Aluguer> historicoAluguer(string idCliente)
        {
            List<Aluguer> lista = new List<Aluguer>();

            foreach (Aluguer alug in LA)
            {
                if (alug.IdCliente == idCliente && alug.Devolvido)
                {
                    lista.Add(alug);
                }
            }
            return lista;
        }

        public double getKmsByClienteMatricula(string idCliente, string matricula)
        {
            double kms = 0;

            foreach (Aluguer alug in LA)
            {
                if (alug.IdCliente == idCliente && alug.Matricula == matricula)
                {
                    kms += alug.Kms;
                }
            }

            return kms;
        }
        //VEICULO FATURADO
        public Dictionary<string, double> getLucrosByVeiculo()
        {
            Dictionary<string, double> lucroPorveiculo = new Dictionary<string, double>();

            foreach (var alug in LA)
            {
                if (lucroPorveiculo.ContainsKey(alug.Matricula))
                {
                    lucroPorveiculo[alug.Matricula] += alug.CustoAluguer;
                }
                else
                {
                    lucroPorveiculo.Add(alug.Matricula, alug.CustoAluguer);
                }
            }

            return lucroPorveiculo;
        }

        //CLIENTE gastou
        public Dictionary<string, double> getLucrosByCliente()
        {
            Dictionary<string, double> lucroPorCliente = new Dictionary<string, double>();

            foreach (var alug in LA)
            {
                if (lucroPorCliente.ContainsKey(alug.IdCliente))
                {
                    lucroPorCliente[alug.IdCliente] += alug.CustoAluguer;
                }
                else
                {
                    lucroPorCliente.Add(alug.IdCliente, alug.CustoAluguer);
                }
            }

            return lucroPorCliente;
        }

        public void gravarAlugueresTXT()
        {
            StreamWriter ficheiro = new StreamWriter("../../Alugueres.txt");

            foreach (Aluguer a in LA)
            {
                a.gravarAluguerTXT(ficheiro);
            }

            ficheiro.Close();
        }

        public void loadAlugueresTXT()
        {
            if (!File.Exists("../../Alugueres.txt"))
            {
                StreamWriter vl = new StreamWriter("../../Alugueres.txt");
                vl.Close();
            }

            StreamReader ficheiroA = new StreamReader("../../Alugueres.txt", true);

            string linhaElemento;
            string[] elementosDivididos;

            while ((linhaElemento = ficheiroA.ReadLine()) != null)
            {
                Aluguer aluguer = new Aluguer();

                elementosDivididos = linhaElemento.Split('|');

                aluguer.IdCliente = elementosDivididos[0];
                aluguer.Matricula = elementosDivididos[1];
                aluguer.DataDesde = DateTime.Parse(elementosDivididos[2]);
                aluguer.DataAte = DateTime.Parse(elementosDivididos[3]);
                aluguer.CustoAluguer = double.Parse(elementosDivididos[4]);
                aluguer.Devolvido = bool.Parse(elementosDivididos[5]);
                aluguer.Kms = double.Parse(elementosDivididos[6]);

                LA.Add(aluguer);
            }

            ficheiroA.Close();
        }

        private void SaveToXML<T>(string filename, object data)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            TextWriter txtWriter = new StreamWriter(filename);
            xs.Serialize(txtWriter, data);

            txtWriter.Close();
        }

        public void SaveAlugueresToXML()
        {
            SaveToXML<List<Aluguer>>("../../Alugueres.xml", LA);
        }

        public void SaveVeiculosLigeirosToXML()
        {
            SaveToXML<List<VLigeiro>>("../../VeiculosLigeiros.xml", LVL);
        }

        public void SaveVeiculosPesadosToXML()
        {
            SaveToXML<List<VPesado>>("../../VeiculosPesados.xml", LVP);
        }

        public void SaveClientesParticularesToXML()
        {
            SaveToXML<List<CParticular>>("../../Clientes.xml", LCP);
        }

        public void SaveClientesEmpresariaisToXML()
        {
            SaveToXML<List<CEmpresarial>>("../../ClientesEmpresa.xml", LCE);
        }

        public void SaveRelatorioClienteToXML(RelatorioCliente relatorio)
        {
            SaveToXML<RelatorioCliente>("../../RelatorioCliente.xml", relatorio);
        }

        public void EditCliente(string id, string nome, string morada, string contacto, string nif, string tipo, string capitalSocial, string idade)
        {
            if (tipo == "Particular")
            {
                // particular
                foreach (var cliente in LCP)
                {
                    if (cliente.obterid.ToString() == id)
                    {
                        cliente.obternome = nome;
                        cliente.obtermorada = morada;
                        cliente.obtercontact = contacto;
                        cliente.obternif = nif;
                        cliente.obtertipo = tipo;

                        cliente.obteridade = int.Parse(idade);
                    }
                }
            }
            else
            {
                // empresa
                foreach (var cliente in LCE)
                {
                    if (cliente.obterid.ToString() == id)
                    {
                        cliente.obternome = nome;
                        cliente.obtermorada = morada;
                        cliente.obtercontact = contacto;
                        cliente.obternif = nif;
                        cliente.obtertipo = tipo;

                        cliente.obtercapital = float.Parse(capitalSocial);
                    }
                }
            }
        }

        public void DeleteCliente(string id, string tipo)
        {
            if (tipo == "Particular")
            {
                // particular
                CParticular c = new CParticular();

                foreach (var cliente in LCP)
                {
                    if (cliente.obterid.ToString() == id)
                    {
                        c = cliente;
                    }
                }

                LCP.Remove(c);
            }
            else
            {
                // empresa
                CEmpresarial c = new CEmpresarial();

                foreach (var cliente in LCE)
                {
                    if (cliente.obterid.ToString() == id)
                    {
                        c = cliente;
                    }
                }

                LCE.Remove(c);
            }
        }


        public void EditVeiculo(string matricula, string tipo, string marcamodelo, string seguro, string consumo, string preco, string kms, string ano, string combustivel, string transmissao, string alugado)
        {
            if (tipo == "Ligeiro")
            {
                // ligeiro
                foreach (var veiculo in LVL)
                {
                    if (veiculo.obtermatricula == matricula)
                    {
                        veiculo.obtermarcamodelo = marcamodelo;
                        veiculo.obterseguroanual = int.Parse(seguro);
                        veiculo.obterconsumo = int.Parse(consumo);
                        veiculo.obterprecodiario = int.Parse(preco);
                        veiculo.obterkm = int.Parse(kms);
                        veiculo.obterano = ano;
                        veiculo.obteralugado = alugado == "Sim";

                        veiculo.obtercombustivel = combustivel;
                    }
                }
            }
            else
            {
                // pesado
                foreach (var veiculo in LVP)
                {
                    if (veiculo.obtermatricula == matricula)
                    {
                        veiculo.obtermarcamodelo = marcamodelo;
                        veiculo.obterseguroanual = int.Parse(seguro);
                        veiculo.obterconsumo = int.Parse(consumo);
                        veiculo.obterprecodiario = int.Parse(preco);
                        veiculo.obterkm = int.Parse(kms);
                        veiculo.obterano = ano;
                        veiculo.obteralugado = alugado == "Sim";

                        veiculo.obtertransmissao = transmissao;
                    }
                }
            }
        }

        public void DeleteVeiculo(string matricula, string tipo)
        {
            if (tipo == "Ligeiro")
            {
                // ligeiro
                VLigeiro v = new VLigeiro();

                foreach (var veiculo in LVL)
                {
                    if (veiculo.obtermatricula == matricula)
                    {
                        v = veiculo;
                    }
                }

                LVL.Remove(v);
            }
            else
            {
                // pesado
                VPesado v = new VPesado();

                foreach (var veiculo in LVP)
                {
                    if (veiculo.obtermatricula == matricula)
                    {
                        v = veiculo;
                    }
                }

                LVP.Remove(v);
            }
        }


        public bool podeAlugar(Aluguer alug, DateTime inicio, DateTime fim)
        {
            if ((inicio <= alug.DataDesde && fim >= alug.DataAte) ||
                   (inicio >= alug.DataDesde && fim <= alug.DataAte) ||
                   (inicio <= alug.DataDesde && fim >= alug.DataDesde) ||
                   (inicio <= alug.DataAte && fim >= alug.DataAte))
            {
                return false;
            }

            return false;
        }

        public bool podeAlugar(DateTime inicio, DateTime fim)
        {
            foreach (var alug in LA)
            {
                if ((inicio <= alug.DataDesde && fim >= alug.DataAte) ||
                    (inicio >= alug.DataDesde && fim <= alug.DataAte) ||
                    (inicio <= alug.DataDesde && fim >= alug.DataDesde) ||
                    (inicio <= alug.DataAte && fim >= alug.DataAte))
                {
                    return false;
                }
            }

            return true;
        }

        public bool veiculoTemAluguer(string matricula, DateTime inicio, DateTime fim)
        {
            foreach (var alug in LA)
            {
                if (alug.Matricula == matricula && (
                    (inicio <= alug.DataDesde && fim >= alug.DataAte) ||
                    (inicio >= alug.DataDesde && fim <= alug.DataAte) ||
                    (inicio <= alug.DataDesde && fim >= alug.DataDesde) ||
                    (inicio <= alug.DataAte && fim >= alug.DataAte)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}


