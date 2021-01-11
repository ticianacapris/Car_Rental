using POO.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace POO
{
    public partial class Form1 : Form
    {
        Gestao gestao;
        TextBox textBoxAutoCompleteNif;
        TextBox textBoxAutoCompleteContacto;
        private ListViewColumnSorter lvwColumnSorter;


        public Form1()
        {
            gestao = new Gestao();
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView_veiculos.ListViewItemSorter = lvwColumnSorter;
        }

        private void btn_inserir_cliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_nome.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco.", "Nome");
                if (textBox_morada.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em brancocê deve preencher todos os espaços em branco.", "Morada");
                if (textBox_contacto.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Contact");
                if (textBox_id.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco.", "Id");
                if (textBox_nif.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Nif");
                if (comboBox_tipo.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Tipo");
                if (comboBox_tipo.Text == "Empresa")
                    if (textBox_Capital_social.Text == string.Empty)
                        throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Capital Social");
                if (comboBox_tipo.Text == "Particular")
                    if (textBox_idade.Text == string.Empty)
                        throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Idade");

                string contacto, nif, nome, morada, tipo;
                int id, idade;
                float capital;

                //buscar os valores para variaveis
                //trim bloqueia espaço no inicio e fim

                tipo = comboBox_tipo.Text.Trim().ToString();
                nome = textBox_nome.Text.Trim().ToString();
                id = Convert.ToInt32(textBox_id.Text.Trim());
                morada = textBox_morada.Text.Trim().ToString();
                contacto = textBox_contacto.Text.Trim().ToString();
                nif = textBox_nif.Text.Trim().ToString();
                //capital = float.Parse(textBox_Capital_social.Text.Trim());


                //if (comboBox_tipo.Text == "Empresa")
                //{
                //    capital = float.Parse(textBox_Capital_social.Text.Trim());
                //    gestao.AddClienteEmpresa(id, nome, morada, contacto, nif, tipo, capital);
                //}
                //else
                //{
                //    capital = 0;
                //    gestao.AddClienteEmpresa(id, nome, morada, contacto, nif, tipo, capital);
                //}

                //if (comboBox_tipo.Text == "Particular")
                //{
                //    idade = Convert.ToInt32(textBox_idade.Text.Trim());
                //    gestao.AddClienteParticular(id, nome, morada, contacto, nif, tipo, idade);
                //}
                //// if (capital == 0)
                //else
                //{
                //    idade = 0;
                //    gestao.AddClienteParticular(id, nome, morada, contacto, nif, tipo, idade);
                //}


                if (comboBox_tipo.SelectedIndex == 0)
                {
                    idade = Convert.ToInt32(textBox_idade.Text.Trim());

                    string dadosamostrarparticular;
                    dadosamostrarparticular = "Dados do Cliente " + tipo + "\n" +
                        "ID do cliente: " + id + "\n" +
                        "Nome do Cliente: " + nome + "\n" +
                        "Morada: " + morada + "\n" +
                        "Contacto: " + contacto + "\n" +
                        "NIF: " + nif + "\n" +
                        "Idade " + idade + "\n" +
                        "\n" +
                    "Deseja confirmar??? ";

                    var confirmResult = MessageBox.Show(dadosamostrarparticular,
                                    "Confirmar",
                                    MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        gestao.AddClienteParticular(id, nome, morada, contacto, nif, tipo, idade);

                    }
                }
                else
                {
                    capital = float.Parse(textBox_Capital_social.Text.Trim());

                   
                    MessageBox.Show(tipo + " " + nome + " " + morada + " " + contacto + " " + nif + " " + capital);

                    string dadosamostrarempresarial;
                    dadosamostrarempresarial = "Dados do Cliente " + tipo + "\n" +
                        "ID do cliente: " + id + "\n" +
                        "Nome do Cliente: " + nome + "\n" +
                        "Morada: " + morada + "\n" +
                        "Contacto: " + contacto + "\n" +
                        "NIF: " + nif + "\n" +
                        "Capital Social " + capital + "\n" +
                        "\n" +
                    "Deseja confirmar??? ";

                    var confirmResult = MessageBox.Show(dadosamostrarempresarial,
                                    "Confirmar",
                                    MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        gestao.AddClienteEmpresa(id, nome, morada, contacto, nif, tipo, capital);
                    }
                }

                //listView_cliente.SelectedItems[6].Text = "";




                //passar os dados para lista que esta no gestor   




                // Use as informações fornecidas nas caixas de texto e adicione-as aos itens / subitens
                reloadListView();


                // Adicione os itens à exibição em lista.


                // Se não houver erro, sucesso.
                //  MessageBox.Show(tipo + " " + nome + " " + morada + " " + contacto + " " + nif + " " + capital);
                MessageBox.Show("Cliente adicionado com sucesso.", "Sucesso");


                //limpar campos

                limparcamposlistaclientes();

            }
            catch (Exception ex)
            {
                //If error show the error
                MessageBox.Show(ex.Message, "Error");
            }

            //Salvar os itens para txt
        }

        public void limparcamposlistaclientes()
        {
            comboBox_tipo.SelectedIndex = 0;
            textBox_nome.Clear();
            textBox_id.Clear();
            textBox_morada.Clear();
            textBox_contacto.Clear();
            textBox_nif.Clear();
            textBox_Capital_social.Clear();
            textBox_idade.Clear();
        }

        public void limparcamposVeiculos()
        {

            textBox_matricula.Clear();
            comboBox_tipo_veiculos.SelectedIndex = 0;
            textBox_marcamodelo.Clear();
            textBox_seguro_anual.Clear();
            textBox_consumo.Clear();
            textBox_precod.Clear();
            textBox_kilometros.Clear();
            textBox_ano.Clear();
            textBox_combustivel.Clear();
            textBox_trasmissao.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gestao.loadClientesTXT();
            reloadListView();
            gestao.loadVeiculosTXT();
            reloadListViewVeiculos();
            gestao.loadAlugueresTXT();
            Bloqueio();
        }

        private void TextBoxAutoCompleteContacto_KeyDown(object sender, KeyEventArgs e)
        {
            eventoPesquisaClienteKeyDown(sender, e, 3);
        }

        private void TextBoxAutoCompleteNif_KeyDown(object sender, KeyEventArgs e)
        {
            eventoPesquisaClienteKeyDown(sender, e, 4);
        }

        private void eventoPesquisaClienteKeyDown(object sender, KeyEventArgs e, int position)
        {
            if (e.KeyData == Keys.Enter)
            {
                string info = ((TextBox)sender).Text;

                for (int i = 0; i < listView_cliente.Items.Count; i++)
                {
                    if (listView_cliente.Items[i].SubItems[position].Text == info)
                    {
                        loadDadosClienteAluguer(i);
                        break;
                    }
                }
            }
        }

        private void loadDadosClienteAluguer(int position)
        {
            if (tab_master.SelectedIndex == 3)
            {
                txtAlugIDCliente.Text = listView_cliente.Items[position].SubItems[0].Text;
                txtAlugNomeCliente.Text = listView_cliente.Items[position].SubItems[1].Text;
                txtAlugMoradaCliente.Text = listView_cliente.Items[position].SubItems[2].Text;
                txtAlugContactoCliente.Text = listView_cliente.Items[position].SubItems[3].Text;
                txtAlugNifCliente.Text = listView_cliente.Items[position].SubItems[4].Text;
                txtAlugTipoCliente.Text = listView_cliente.Items[position].SubItems[5].Text;
            }
            else if (tab_master.SelectedIndex == 4)
            {
                txtDevolveIDCliente.Text = listView_cliente.Items[position].SubItems[0].Text;
                txtDevolveNomeCliente.Text = listView_cliente.Items[position].SubItems[1].Text;
                txtDevolveMoradaCliente.Text = listView_cliente.Items[position].SubItems[2].Text;
                txtDevolveContactoCliente.Text = listView_cliente.Items[position].SubItems[3].Text;
                txtDevolveNIFCliente.Text = listView_cliente.Items[position].SubItems[4].Text;
                txtDevolveTipoCliente.Text = listView_cliente.Items[position].SubItems[5].Text;

                List<Aluguer> lista = gestao.pesquisaAluguer(txtDevolveIDCliente.Text);
                dataGridView_devolucao.Rows.Clear();

                foreach (var alug in lista)
                {
                    dataGridView_devolucao.Rows.Add(
                       alug.Matricula,
                       alug.DataDesde,
                       alug.DataAte,
                       alug.CustoAluguer);
                }
            }
        }


        public void reloadListView()
        {
            listView_cliente.Items.Clear();

            //MessageBox.Show("TXT carregado");

            foreach (CParticular c in gestao.RetornarLCP())
            {
                ListViewItem lVC = new ListViewItem();
                string[] row = { c.obterid.ToString(), c.obternome, c.obtermorada, c.obtercontact, c.obternif, "Particular", null, c.obteridade.ToString() };


                //  textBox_id.Text, comboBox_tipo.Text, textBox_nome.Text, textBox_morada.Text, textBox_contacto.Text, textBox_nif.Text, textBox_Capital_social.Text };
                ListViewItem lvccliente = new ListViewItem(row);

                //adicionar à listview
                listView_cliente.Items.Add(lvccliente);
            }
            foreach (CEmpresarial c in gestao.RetornarLCE())
            {
                ListViewItem lVC = new ListViewItem();
                string[] row = { c.obterid.ToString(), c.obternome, c.obtermorada, c.obtercontact, c.obternif, "Empresarial", c.obtercapital.ToString() };

                //textBox_id.Text, comboBox_tipo.Text, textBox_nome.Text, textBox_morada.Text, textBox_contacto.Text, textBox_nif.Text, textBox_Capital_social.Text };
                ListViewItem lvccliente = new ListViewItem(row);

                //adicionar à listview
                listView_cliente.Items.Add(lvccliente);
            }
            //add isso na atualização
            //gestao.gravarClienteEmpresaTXT();
            //gestao.gravarClienteParticularTXT();
        }

        public void reloadListViewVeiculos()
        {
            listView_veiculos.Items.Clear();

            //MessageBox.Show("TXT carregado");

            foreach (VLigeiro vl in gestao.RetornarLVL())
            {
                ListViewItem lvl = new ListViewItem();
                string[] row = { vl.obtermatricula, "Ligeiro", vl.obtermarcamodelo, vl.obterseguroanual.ToString(), vl.obterconsumo.ToString(),
                    vl.obterprecodiario.ToString(), vl.obterkm.ToString(), vl.obternreq.ToString(), vl.obterano, vl.obtercombustivel, null, (vl.obteralugado ? "Sim" : "Não") };


                ListViewItem lvlveiculo = new ListViewItem(row);

                //adicionar à listview
                listView_veiculos.Items.Add(lvlveiculo);
            }
            foreach (VPesado vp in gestao.RetornarLVP())
            {
                ListViewItem lvl = new ListViewItem();
                string[] row = { vp.obtermatricula, "Pesado", vp.obtermarcamodelo, vp.obterseguroanual.ToString(),
                    vp.obterconsumo.ToString(), vp.obterprecodiario.ToString(), vp.obterkm.ToString(), vp.obternreq.ToString()
                    , vp.obterano.ToString(), null, vp.obtertransmissao, (vp.obteralugado ? "Sim" : "Não") };

                ListViewItem lvlveiculo = new ListViewItem(row);

                //adicionar à listview
                listView_veiculos.Items.Add(lvlveiculo);
            }

            //gestao.gravarVeiculoLigeiroTXT();
            //gestao.gravarVeiculoPesadoTXT();
        }

        private void btn_remover_cliente_Click(object sender, EventArgs e)
        {
            /* METODO ALTERNATIVO FUNCIONAL  
             List<CParticular> clientep = gestao.RetornarLCP();
             List<CEmpresarial> clientemp = gestao.RetornarLCE();
             foreach (ListViewItem cliente in listView_cliente.SelectedItems)
             {
                 foreach (CParticular cp in clientep.ToList())
                 {
                     if (listView_cliente.SelectedItems[0].SubItems[0].Text == Convert.ToString(cp.obterid))
                     {
                         clientep.Remove(cp);

                         gestao.gravarClienteParticularTXT();
                     }

                 }
                 foreach (CEmpresarial ce in clientemp.ToList())
                 {
                     if (listView_cliente.SelectedItems[0].SubItems[0].Text == Convert.ToString(ce.obterid))
                     {
                         clientemp.Remove(ce);
                         gestao.gravarClienteEmpresaTXT();
                     }
                 }
                 listView_cliente.Items.Remove(cliente);
             } */



            if (MessageBox.Show("Tem a certeza que pretende apagar cliente?", "APAGAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                gestao.apagarClienteParticular(Convert.ToInt32(listView_cliente.SelectedItems[0].SubItems[0].Text));
                limparcamposlistaclientes();

            }

            btn_inserir_cliente.Enabled = true;

            reloadListView();
        }

        private void listView_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* if (listView_cliente.SelectedItems.Count > 0)
             {
                 ListViewItem item = .SelectedItems[listView_cliente.SelectedItems.Count - 1];
                 if (item != null)
                     foreach (ListViewItem lv in listView_cliente.SelectedItems)
                     {
                       comboBox_tipo.Text = lv.SubItems[0].Text;
                         textBox_nome.Text = lv.SubItems[1].Text;
                         textBox_morada.Text = lv.SubItems[2].Text;
                         textBox_contacto.Text = lv.SubItems[3].Text;

                         //MessageBox.Show("TPassei AQUI!");
                         //Console.WriteLine("Passei o rato aqui"); 
             }*/
        }

        private void btn_editar_cliente_Click(object sender, EventArgs e)
        {
            listView_cliente.SelectedItems[0].SubItems[1].Text = textBox_nome.Text;
            listView_cliente.SelectedItems[0].SubItems[2].Text = textBox_morada.Text;
            listView_cliente.SelectedItems[0].SubItems[3].Text = textBox_contacto.Text;
            listView_cliente.SelectedItems[0].SubItems[4].Text = textBox_nif.Text;
            listView_cliente.SelectedItems[0].SubItems[5].Text = comboBox_tipo.Text;
            listView_cliente.SelectedItems[0].SubItems[6].Text = textBox_Capital_social.Text;
            listView_cliente.SelectedItems[0].SubItems[7].Text = textBox_idade.Text;

            gestao.EditCliente(textBox_id.Text, textBox_nome.Text, textBox_morada.Text, textBox_contacto.Text, textBox_nif.Text, comboBox_tipo.Text, textBox_Capital_social.Text, textBox_idade.Text);

            limparcamposlistaclientes();
            btn_inserir_cliente.Enabled = true;
        }

        private void listView_cliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_historico_clientes.Visible = false;
            btn_editar_cliente.Enabled = true;
            button_cancelar_edicao_cliente.Visible = true;
            btn_inserir_cliente.Enabled = false;
            textBox_id.Enabled = false;

            if (listView_cliente.SelectedItems[0].SubItems[5].Text == "Particular")
            {
                textBox_id.Text = listView_cliente.SelectedItems[0].SubItems[0].Text;
                textBox_nome.Text = listView_cliente.SelectedItems[0].SubItems[1].Text;
                textBox_morada.Text = listView_cliente.SelectedItems[0].SubItems[2].Text;
                textBox_contacto.Text = listView_cliente.SelectedItems[0].SubItems[3].Text;
                textBox_nif.Text = listView_cliente.SelectedItems[0].SubItems[4].Text;
                comboBox_tipo.Text = listView_cliente.SelectedItems[0].SubItems[5].Text;
                textBox_idade.Text = listView_cliente.SelectedItems[0].SubItems[7].Text;
                textBox_Capital_social.Text = null;
            }
            else
            {
                textBox_id.Text = listView_cliente.SelectedItems[0].SubItems[0].Text;
                textBox_nome.Text = listView_cliente.SelectedItems[0].SubItems[1].Text;
                textBox_morada.Text = listView_cliente.SelectedItems[0].SubItems[2].Text;
                textBox_contacto.Text = listView_cliente.SelectedItems[0].SubItems[3].Text;
                textBox_nif.Text = listView_cliente.SelectedItems[0].SubItems[4].Text;
                comboBox_tipo.Text = listView_cliente.SelectedItems[0].SubItems[5].Text;
                textBox_idade.Text = null;
                textBox_Capital_social.Text = listView_cliente.SelectedItems[0].SubItems[6].Text;
            }
        }

        private void btn_remover_cliente_Click_1(object sender, EventArgs e)
        {
            /*   METODO FUNCIONAL ALTERNATIVO
             List<CParticular> clientep = gestao.RetornarLCP();
             List<CEmpresarial> clientemp = gestao.RetornarLCE();
             foreach (ListViewItem cliente in listView_cliente.SelectedItems)
             {
                 foreach (CParticular cp in clientep.ToList())
                 {
                     if (listView_cliente.SelectedItems[0].SubItems[0].Text == Convert.ToString(cp.obterid))
                     {
                         clientep.Remove(cp);

                         gestao.gravarClienteParticularTXT();
                     }

                 }
                 foreach (CEmpresarial ce in clientemp.ToList())
                 {
                     if (listView_cliente.SelectedItems[0].SubItems[0].Text == Convert.ToString(ce.obterid))
                     {
                         clientemp.Remove(ce);
                         gestao.gravarClienteEmpresaTXT();
                     }
                 }
                 listView_cliente.Items.Remove(cliente);
             } */
            //int indice = listView_cliente.SelectedIndices[0];

            if (MessageBox.Show("Tem a certeza que pretende apagar cliente?", "APAGAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //if (listView_cliente.SelectedItems[0].SubItems[5].Text.CompareTo("Particular") == 0)
                //    gestao.apagarClienteParticular(Convert.ToInt32(listView_cliente.SelectedItems[0].SubItems[0].Text));
                //else
                //    gestao.apagarClienteEmpresa(Convert.ToInt32(listView_cliente.SelectedItems[0].SubItems[0].Text));

                gestao.DeleteCliente(listView_cliente.SelectedItems[0].SubItems[0].Text, listView_cliente.SelectedItems[0].SubItems[5].Text);
                listView_cliente.SelectedItems[0].Remove();

                limparcamposlistaclientes();
                //reloadListView();
            }

            btn_inserir_cliente.Enabled = true;
        }
        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            int NP = gestao.GetNClienteP();
            MessageBox.Show("Num. Cliente = " + NP);
            int NE = gestao.GetNClienteP();
            MessageBox.Show("Num. Cliente = " + NE);
            gestao.Pesquisa_ClienteParticular(textBox_pesquisar_cliente.Text);
            gestao.Pesquisa_ClienteEmpresarial(textBox_pesquisar_cliente.Text);

            bool encontrei = false;

            foreach (CParticular X in gestao.RetornarLCP())
            {
                if (textBox_pesquisar_cliente.Text == X.obternif)
                {
                    MessageBox.Show("Encontrei o NIF Particular : " + textBox_pesquisar_cliente.Text);
                    encontrei = true;
                }
            }
            foreach (CEmpresarial Y in gestao.RetornarLCE())
            {
                if (textBox_pesquisar_cliente.Text == Y.obternif)
                {
                    MessageBox.Show("Encontrei o NIF Empresarial: " + textBox_pesquisar_cliente.Text);
                    encontrei = true;
                }
            }
            if (encontrei == false)
                MessageBox.Show("Não encontrei nenhum nif.", "Erro");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label_tipo_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_tipo.SelectedIndex == 1)
            //    textBox_Capital_social.Enabled = true;
            //else
            //    textBox_Capital_social.Enabled = false;
            //if (comboBox_tipo.SelectedIndex == 0)
            //    textBox_idade.Enabled = true;
            //else
            //    textBox_idade.Enabled = false;


            //MESMA COISA QUE AS CONDIÇÕES ANTERIORES MAS MAIS SIMPLIFICADAS
            if (comboBox_tipo.SelectedIndex == 0)
            {
                textBox_idade.Enabled = true;
                textBox_Capital_social.Enabled = false;
                textBox_Capital_social.Text = string.Empty;
            }
            else
            {
                textBox_idade.Enabled = false;
                textBox_Capital_social.Enabled = true;
                textBox_idade.Text = string.Empty;
            }
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_Capital_social_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_inserir_veiculos_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_matricula.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco.", "Matricula");
                if (comboBox_tipo_veiculos.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em brancocê deve preencher todos os espaços em branco.", "Tipo");
                if (textBox_marcamodelo.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Marca Modelo");
                if (textBox_seguro_anual.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco.", "Seguro Anual");
                if (textBox_consumo.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Consumo");
                if (textBox_precod.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Preco Diário");
                if (textBox_kilometros.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Kilometros");
                if (textBox_ano.Text == string.Empty)
                    throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Ano");
                if (comboBox_tipo_veiculos.Text == "Ligeiro")
                    if (textBox_combustivel.Text == string.Empty)
                        throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Combustivel");
                if (comboBox_tipo_veiculos.Text == "Pesado")
                    if (textBox_trasmissao.Text == string.Empty)
                        throw new System.ArgumentException("Você deve preencher todos os espaços em branco", "Trasnmissão");

                string matricula, tipoveiculo, marcamodelo, ano, combustivel, transmissao;
                int seguroanual, consumo, precodiario, km, nreq;



                //buscar os valores para variaveis
                //trim bloqueia espaço no inicio e fim

                matricula = textBox_matricula.Text.Trim().ToString();
                tipoveiculo = comboBox_tipo_veiculos.Text.Trim().ToString();
                marcamodelo = textBox_marcamodelo.Text.Trim().ToString();
                seguroanual = int.Parse(textBox_seguro_anual.Text.Trim());
                consumo = int.Parse(textBox_consumo.Text.Trim());
                //consumo = Convert.ToInt32(textBox_consumo.Text);
                precodiario = int.Parse(textBox_precod.Text.Trim());
                //precodiario = Convert.ToInt32(textBox_precod.Text);
                //km = Convert.ToInt32(textBox_kilometros.Text);
                km = int.Parse(textBox_kilometros.Text.Trim());
                nreq = 0;
                ano = textBox_ano.Text.Trim().ToString();
                //parametro1 = float.Parse(textBox_parametro_1.Text);
                //parametro2 = float.Parse(textBox_parametro_2.Text);

                //Console.WriteLine(comboBox_tipo_veiculos.Text + comboBox_tipo_veiculos.SelectedIndex);

                if (comboBox_tipo_veiculos.Text == "Ligeiro")
                {
                    combustivel = textBox_combustivel.Text.Trim();
                    transmissao = "";
                    gestao.AddVeiculoLigeiro(matricula, tipoveiculo, marcamodelo, seguroanual, consumo, precodiario, km, nreq, ano, combustivel);
                    //Console.WriteLine("Verdadeiro 2");
                    //Console.WriteLine("Adicionado Ligueiro");
                    //GRAVAR
                    //MessageBox.Show(matricula + " " + tipoveiculo + " " + marcamodelo + " " + seguroanual + " " + consumo + " " + precodiario + " " + km + " " + nreq + " " + ano + "  " + parametro1 + " ");
                    //gestao.gravarVeiculoLigeiroTXT();
                }
                else
                {
                    transmissao = textBox_trasmissao.Text.Trim();
                    gestao.AddVeiculoPesado(matricula, comboBox_tipo_veiculos.Text, marcamodelo, seguroanual, consumo, precodiario, km, nreq, ano, transmissao);
                    //Console.WriteLine("Adicionado Pesado");
                    //GRAVAR
                    //MessageBox.Show(matricula + " " + tipoveiculo + " " + marcamodelo + " " + seguroanual + " " + consumo + " " + precodiario + " " + km + " " + nreq + " " + ano + "  " + parametro2 + " ");
                    //gestao.gravarVeiculoPesadoTXT();
                }




                // Use as informações fornecidas nas caixas de texto e adicione-as aos itens / subitens
                reloadListViewVeiculos();


                // Adicione os itens à exibição em lista.


                // Se não houver erro, sucesso.
                //  MessageBox.Show(tipo + " " + nome + " " + morada + " " + contacto + " " + nif + " " + capital);
                MessageBox.Show("Veiculo adicionado com sucesso.", "Sucesso");


                //limpar campos

                limparcamposVeiculos();

            }
            catch (Exception ex)
            {
                //If error show the error
                MessageBox.Show(ex.Message, "Error");
            }

            //Salvar os itens para txt
        }

        private void btn_exportar_veiculo_Click(object sender, EventArgs e)
        {
            gestao.gravarVeiculoLigeiroTXT();
            gestao.gravarVeiculoPesadoTXT();

        }


        private void btn_exportar_cliente_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox_contacto_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_idade_TextChanged(object sender, EventArgs e)
        {

        }



        private void textBox_matricula_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_tipo_veiculos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Bloqueio();
            textBox_combustivel.Clear();
            textBox_trasmissao.Clear();

            if (comboBox_tipo_veiculos.SelectedIndex == 0)
            {
                textBox_combustivel.Enabled = true;
                textBox_trasmissao.Enabled = false;
                textBox_combustivel.Text = "Gasolina";
            }
            else
            {
                textBox_trasmissao.Enabled = true;
                textBox_combustivel.Enabled = false;
                textBox_trasmissao.Text = "Automatico";
            }
        }
        private void Bloqueio()
        {
            textBox_combustivel.Enabled = false;
            textBox_trasmissao.Enabled = false;
        }
        private void Btn_remover_veiculo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que pretende apagar veiculo?", "APAGAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                gestao.DeleteVeiculo(listView_veiculos.SelectedItems[0].SubItems[0].Text, listView_veiculos.SelectedItems[0].SubItems[1].Text);
                listView_veiculos.SelectedItems[0].Remove();
                limparcamposVeiculos();
            }

            btn_inserir_veiculos.Enabled = true;
        }

        private void listView_veiculos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_veiculos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_editar_veiculo.Enabled = true;
            button_cancelar_veiculo.Visible = true;
            btn_inserir_veiculos.Enabled = false;
            textBox_matricula.Enabled = false;

            textBox_matricula.Text = listView_veiculos.SelectedItems[0].SubItems[0].Text;
            comboBox_tipo_veiculos.Text = listView_veiculos.SelectedItems[0].SubItems[1].Text;
            textBox_marcamodelo.Text = listView_veiculos.SelectedItems[0].SubItems[2].Text;
            textBox_seguro_anual.Text = listView_veiculos.SelectedItems[0].SubItems[3].Text;
            textBox_consumo.Text = listView_veiculos.SelectedItems[0].SubItems[4].Text;
            textBox_precod.Text = listView_veiculos.SelectedItems[0].SubItems[5].Text;
            textBox_kilometros.Text = listView_veiculos.SelectedItems[0].SubItems[6].Text;
            textBox_ano.Text = listView_veiculos.SelectedItems[0].SubItems[8].Text;
        }

        private void btn_editar_veiculo_Click(object sender, EventArgs e)
        {
            listView_veiculos.SelectedItems[0].SubItems[1].Text = comboBox_tipo_veiculos.Text;
            listView_veiculos.SelectedItems[0].SubItems[2].Text = textBox_marcamodelo.Text;
            listView_veiculos.SelectedItems[0].SubItems[3].Text = textBox_seguro_anual.Text;
            listView_veiculos.SelectedItems[0].SubItems[4].Text = textBox_consumo.Text;
            listView_veiculos.SelectedItems[0].SubItems[5].Text = textBox_precod.Text;
            listView_veiculos.SelectedItems[0].SubItems[6].Text = textBox_kilometros.Text;
            listView_veiculos.SelectedItems[0].SubItems[8].Text = textBox_ano.Text;
            listView_veiculos.SelectedItems[0].SubItems[9].Text = textBox_combustivel.Text;
            listView_veiculos.SelectedItems[0].SubItems[10].Text = textBox_trasmissao.Text;

            gestao.EditVeiculo(textBox_matricula.Text, comboBox_tipo_veiculos.Text, textBox_marcamodelo.Text, textBox_seguro_anual.Text,
                               textBox_consumo.Text, textBox_precod.Text, textBox_kilometros.Text, textBox_ano.Text,
                               textBox_combustivel.Text, textBox_trasmissao.Text, listView_veiculos.SelectedItems[0].SubItems[11].Text);

            limparcamposVeiculos();
            btn_inserir_veiculos.Enabled = true;
        }

        private void textBox_combustivel_TextChanged(object sender, EventArgs e)
        {

        }

        private void tab_veiculos_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_tipo_veiculos_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button_clientes_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(1);
        }

        private void button_veiculos_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(2);
        }

        private void button_alugueres_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(3);
        }

        private void button_devolucao_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(4);
        }

        private void button_histórico_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(5);
        }

        private void button_filtros_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(6);
        }

        private void button_cliente_do_mes_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(7);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(0);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(0);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tab_master.SelectTab(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(0);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(0);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(0);
        }

        private void button_historico_Click(object sender, EventArgs e)
        {
            tab_master.SelectTab(5);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_cancelar_cliente_Click(object sender, EventArgs e)
        {
            limparcamposlistaclientes();
            btn_inserir_cliente.Enabled = true;
            textBox_id.Enabled = true;
        }

        private void tab_clientes_Click(object sender, EventArgs e)
        {

        }

        //quando se faz só um click na listview clientes

        private void umclique(object sender, MouseEventArgs e)
        {
            btn_historico_clientes.Visible = true;
            btn_relatorio_cliente.Visible = true;
        }


        private void loadVeiculosParaAlugar()
        {
            dataGridView_alugueres.Rows.Clear();

            for (int i = 0; i < listView_veiculos.Items.Count; i++)
            {
                if (!gestao.veiculoTemAluguer(listView_veiculos.Items[i].SubItems[0].Text, dtpDataDesde.Value, dtpDataAte.Value))
                {
                    dataGridView_alugueres.Rows.Add(
                        listView_veiculos.Items[i].SubItems[0].Text,
                        listView_veiculos.Items[i].SubItems[1].Text,
                        listView_veiculos.Items[i].SubItems[2].Text,
                        listView_veiculos.Items[i].SubItems[3].Text,
                        listView_veiculos.Items[i].SubItems[4].Text,
                        listView_veiculos.Items[i].SubItems[5].Text,
                        listView_veiculos.Items[i].SubItems[6].Text,
                        listView_veiculos.Items[i].SubItems[7].Text,
                        listView_veiculos.Items[i].SubItems[8].Text,
                        listView_veiculos.Items[i].SubItems[9].Text,
                        listView_veiculos.Items[i].SubItems[10].Text
                        );
                }
            }
        }

        private void limpacamposaluguer()
        {
            #region Datas

            dtpDataDesde.Value = DateTime.Now;
            dtpDataAte.Value = DateTime.Now.AddDays(1);

            #endregion

            #region Veiculos

            loadVeiculosParaAlugar();

            #endregion


            #region Cliente

            textBoxAutoCompleteNif.Text = string.Empty;
            textBoxAutoCompleteContacto.Text = string.Empty;

            txtAlugIDCliente.Text = string.Empty;
            txtAlugNomeCliente.Text = string.Empty;
            txtAlugMoradaCliente.Text = string.Empty;
            txtAlugContactoCliente.Text = string.Empty;
            txtAlugNifCliente.Text = string.Empty;
            txtAlugTipoCliente.Text = string.Empty;

            #endregion
        }

        private void limpacamposdevolucao()
        {
            textBoxAutoCompleteNif.Text = string.Empty;
            textBoxAutoCompleteContacto.Text = string.Empty;

            txtDevolveIDCliente.Text = string.Empty;
            txtDevolveNomeCliente.Text = string.Empty;
            txtDevolveMoradaCliente.Text = string.Empty;
            txtDevolveContactoCliente.Text = string.Empty;
            txtDevolveNIFCliente.Text = string.Empty;
            txtDevolveTipoCliente.Text = string.Empty;

            dataGridView_devolucao.Rows.Clear();
        }

        private void criar_pesquisa_clientes(string tab_name)
        {
            #region Pesquisa por NIF

            if (tab_master.TabPages[tab_name].Controls.Find(tab_name + "_textBoxAutoCompleteNif", true).Length == 0)
            {
                List<string> nifList = new List<string>();

                for (int i = 0; i < listView_cliente.Items.Count; i++)
                {
                    nifList.Add(listView_cliente.Items[i].SubItems[4].Text);
                }

                var source = new AutoCompleteStringCollection();
                source.AddRange(nifList.ToArray());

                textBoxAutoCompleteNif = new TextBox
                {
                    AutoCompleteCustomSource = source,
                    AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                    AutoCompleteSource = AutoCompleteSource.CustomSource,
                    Location = new Point(149, 40),
                    Width = ClientRectangle.Width - 40,
                    Visible = true,
                    Size = new Size(200, 29),
                    Name = tab_name + "_textBoxAutoCompleteNif"
                };

                textBoxAutoCompleteNif.KeyDown += TextBoxAutoCompleteNif_KeyDown;

                tab_master.TabPages[tab_name].Controls.Add(textBoxAutoCompleteNif);
            }

            #endregion

            #region Pesquisa por Contacto

            if (tab_master.TabPages[tab_name].Controls.Find(tab_name + "_textBoxAutoCompleteContacto", true).Length == 0)
            {
                List<string> contactoList = new List<string>();

                for (int i = 0; i < listView_cliente.Items.Count; i++)
                {
                    contactoList.Add(listView_cliente.Items[i].SubItems[3].Text);
                }

                var sourceContacto = new AutoCompleteStringCollection();
                sourceContacto.AddRange(contactoList.ToArray());

                textBoxAutoCompleteContacto = new TextBox
                {
                    AutoCompleteCustomSource = sourceContacto,
                    AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                    AutoCompleteSource = AutoCompleteSource.CustomSource,
                    Location = new Point(360, 40),
                    Width = ClientRectangle.Width - 40,
                    Visible = true,
                    Size = new Size(200, 29),
                    Name = tab_name + "_textBoxAutoCompleteContacto"
                };

                textBoxAutoCompleteContacto.KeyDown += TextBoxAutoCompleteContacto_KeyDown;

                tab_master.TabPages[tab_name].Controls.Add(textBoxAutoCompleteContacto);
            }

            #endregion
        }

        private void tab_master_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 3:
                    criar_pesquisa_clientes("tab_alugueres");
                    limpacamposaluguer();
                    break;
                case 4:
                    criar_pesquisa_clientes("tab_devolucao");
                    limpacamposdevolucao();
                    break;
            }
        }

        private void button_alugar_Click(object sender, EventArgs e)
        {
            if (txtAlugIDCliente.Text == string.Empty)
            {
                MessageBox.Show("Deve escolher um cliente!");

                return;
            }

            if (dtpDataDesde.Value > dtpDataAte.Value)
            {
                MessageBox.Show("A data de inicio de aluguer não pode ser superior à data de fim de aluguer!");

                return;
            }

            if (!gestao.podeAlugar(dtpDataDesde.Value, dtpDataAte.Value))
            {
                MessageBox.Show("Já existem alugueres para estas datas!");

                return;
            }

            string matricula = dataGridView_alugueres.SelectedRows[0].Cells[0].Value.ToString();
            double num_dias = Math.Ceiling(dtpDataAte.Value.Subtract(dtpDataDesde.Value).TotalDays);
            double preco_diario = Double.Parse(dataGridView_alugueres.SelectedRows[0].Cells[5].Value.ToString());
            double preco_total = num_dias * preco_diario;

            // Aumentar requisições de veiculo
            int num_req = int.Parse(dataGridView_alugueres.SelectedRows[0].Cells[7].Value.ToString());
            dataGridView_alugueres.SelectedRows[0].Cells[7].Value = num_req + 1;

            for (int i = 0; i < listView_veiculos.Items.Count; i++)
            {
                if (listView_veiculos.Items[i].SubItems[0].Text == matricula)
                {
                    listView_veiculos.Items[i].SubItems[7].Text = (num_req + 1).ToString();

                    // Marcar veiculo como alugado
                    listView_veiculos.Items[i].SubItems[11].Text = "Sim";

                    break;
                }
            }


            //mostrar dados de aluguer | ADICIONAR DADOS DE ALUGUER 

            string dadosaluguer;
            dadosaluguer = "Dados do seu aluguer" + "\n" +
                "ID do cliente: " + txtAlugIDCliente.Text + "\n" +
                "Nome do Cliente: " + txtAlugNomeCliente.Text + "\n" +
                "Matricula: " + matricula + "\n" +
                "N. Dias: " + num_dias + " dias" + "\n" +
                "Preço total:" + preco_total + "€" + "\n" +
                "\n" +
            "Deseja confirmar??? ";


            var confirmResult = MessageBox.Show(dadosaluguer,
                                      "Confirmar aluguer",
                                      MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                gestao.AddAluguer(txtAlugIDCliente.Text, matricula, dtpDataDesde.Value, dtpDataAte.Value, preco_total, num_req + 1);
                limpacamposaluguer();
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void _os_seus_pedidos_Click(object sender, EventArgs e)
        {

        }

        private void button_devolver_Click(object sender, EventArgs e)
        {
            string kmsStr = string.Empty;
            UtilControls.InputBox("Kms", "Insira os Kms", ref kmsStr);

            string matricula = dataGridView_devolucao.SelectedRows[0].Cells[0].Value.ToString();
            double kms = double.Parse(kmsStr);
            double kmsTotais = 0;

            for (int i = 0; i < listView_veiculos.Items.Count; i++)
            {
                if (listView_veiculos.Items[i].SubItems[0].Text == matricula)
                {
                    listView_veiculos.Items[i].SubItems[11].Text = "Não";

                    double kmsAtuais = double.Parse(listView_veiculos.Items[i].SubItems[6].Text);
                    kmsTotais = kmsAtuais + kms;
                    listView_veiculos.Items[i].SubItems[6].Text = kmsTotais.ToString();

                    break;
                }
            }

            gestao.devolverVeiculo(txtDevolveIDCliente.Text, matricula, kms, kmsTotais);

            MessageBox.Show("Veiculo devolvido com sucesso!");
            limpacamposdevolucao();
        }

        private void btn_historico_clientes_Click(object sender, EventArgs e)
        {
            string idCliente = listView_cliente.SelectedItems[0].SubItems[0].Text;
            string nomeCliente = listView_cliente.SelectedItems[0].SubItems[1].Text;

            txtHistIDCliente.Text = idCliente;
            txtHistNome.Text = nomeCliente;

            tab_master.SelectedIndex = 5;

            List<Aluguer> lista = gestao.historicoAluguer(idCliente);
            dataGridView_historico.Rows.Clear();

            foreach (var alug in lista)
            {
                dataGridView_historico.Rows.Add(
                   alug.Matricula,
                   alug.DataDesde,
                   alug.DataAte,
                   alug.CustoAluguer,
                   alug.Kms);
            }
        }

        private void dataGridView_historico_SelectionChanged(object sender, EventArgs e)
        {
            string idCliente = listView_cliente.SelectedItems[0].SubItems[0].Text;
            string matricula = dataGridView_historico.SelectedRows[0].Cells[0].Value.ToString();

            double kms = gestao.getKmsByClienteMatricula(idCliente, matricula);

            txtTotalKms.Text = kms.ToString();
        }

        private void button_alugados_Click(object sender, EventArgs e)
        {
            dataGridView_filtros.Columns["ValorFaturado"].Visible = false;
            dataGridView_filtros.Rows.Clear();

            for (int i = 0; i < listView_veiculos.Items.Count; i++)
            {
                if (listView_veiculos.Items[i].SubItems[11].Text == "Sim")
                {
                    dataGridView_filtros.Rows.Add(
                        listView_veiculos.Items[i].SubItems[0].Text,
                        listView_veiculos.Items[i].SubItems[1].Text,
                        listView_veiculos.Items[i].SubItems[2].Text,
                        listView_veiculos.Items[i].SubItems[3].Text,
                        listView_veiculos.Items[i].SubItems[4].Text,
                        listView_veiculos.Items[i].SubItems[5].Text,
                        listView_veiculos.Items[i].SubItems[6].Text,
                        listView_veiculos.Items[i].SubItems[7].Text,
                        listView_veiculos.Items[i].SubItems[8].Text,
                        listView_veiculos.Items[i].SubItems[9].Text,
                        listView_veiculos.Items[i].SubItems[10].Text
                        );
                }
            }
        }

        private void button_nunca_alugados_Click(object sender, EventArgs e)
        {
            dataGridView_filtros.Columns["ValorFaturado"].Visible = false;
            dataGridView_filtros.Rows.Clear();

            for (int i = 0; i < listView_veiculos.Items.Count; i++)
            {
                if (listView_veiculos.Items[i].SubItems[7].Text == "0")
                {
                    dataGridView_filtros.Rows.Add(
                        listView_veiculos.Items[i].SubItems[0].Text,
                        listView_veiculos.Items[i].SubItems[1].Text,
                        listView_veiculos.Items[i].SubItems[2].Text,
                        listView_veiculos.Items[i].SubItems[3].Text,
                        listView_veiculos.Items[i].SubItems[4].Text,
                        listView_veiculos.Items[i].SubItems[5].Text,
                        listView_veiculos.Items[i].SubItems[6].Text,
                        listView_veiculos.Items[i].SubItems[7].Text,
                        listView_veiculos.Items[i].SubItems[8].Text,
                        listView_veiculos.Items[i].SubItems[9].Text,
                        listView_veiculos.Items[i].SubItems[10].Text
                        );
                }
            }
        }

        private void button_mais_requisitados_Click(object sender, EventArgs e)
        {
            dataGridView_filtros.Columns["ValorFaturado"].Visible = false;
            dataGridView_filtros.Rows.Clear();
            object[] dadosVeiculo = { };
            int maxReq = 0;

            for (int i = 0; i < listView_veiculos.Items.Count; i++)
            {
                int nreq = int.Parse(listView_veiculos.Items[i].SubItems[7].Text);

                if (nreq > maxReq)
                {
                    maxReq = nreq;
                }
            }

            for (int i = 0; i < listView_veiculos.Items.Count; i++)
            {
                int nreq = int.Parse(listView_veiculos.Items[i].SubItems[7].Text);

                if (nreq == maxReq)
                {
                    dadosVeiculo = new object[] {
                        listView_veiculos.Items[i].SubItems[0].Text,
                        listView_veiculos.Items[i].SubItems[1].Text,
                        listView_veiculos.Items[i].SubItems[2].Text,
                        listView_veiculos.Items[i].SubItems[3].Text,
                        listView_veiculos.Items[i].SubItems[4].Text,
                        listView_veiculos.Items[i].SubItems[5].Text,
                        listView_veiculos.Items[i].SubItems[6].Text,
                        listView_veiculos.Items[i].SubItems[7].Text,
                        listView_veiculos.Items[i].SubItems[8].Text,
                        listView_veiculos.Items[i].SubItems[9].Text,
                        listView_veiculos.Items[i].SubItems[10].Text
                    };

                    dataGridView_filtros.Rows.Add(dadosVeiculo);
                }
            }
        }

        private void button_faturou_mais_Click(object sender, EventArgs e)
        {
            dataGridView_filtros.Columns["ValorFaturado"].Visible = true;
            dataGridView_filtros.Rows.Clear();

            Dictionary<string, double> lucroPorveiculo = gestao.getLucrosByVeiculo();
            double maxLucro = lucroPorveiculo.Values.Max();

            for (int i = 0; i < listView_veiculos.Items.Count; i++)
            {
                string matricula = listView_veiculos.Items[i].SubItems[0].Text;

                if (lucroPorveiculo.ContainsKey(matricula) && lucroPorveiculo[matricula] == maxLucro)
                {
                    dataGridView_filtros.Rows.Add(
                        listView_veiculos.Items[i].SubItems[0].Text,
                        listView_veiculos.Items[i].SubItems[1].Text,
                        listView_veiculos.Items[i].SubItems[2].Text,
                        listView_veiculos.Items[i].SubItems[3].Text,
                        listView_veiculos.Items[i].SubItems[4].Text,
                        listView_veiculos.Items[i].SubItems[5].Text,
                        listView_veiculos.Items[i].SubItems[6].Text,
                        listView_veiculos.Items[i].SubItems[7].Text,
                        listView_veiculos.Items[i].SubItems[8].Text,
                        listView_veiculos.Items[i].SubItems[9].Text,
                        listView_veiculos.Items[i].SubItems[10].Text,
                        maxLucro
                        );
                }
            }
        }
        // REFRESH DE CLIENTE QUE MAIS GASTOU
        private void button_calcular_Click(object sender, EventArgs e)
        {
            listView_cliente_do_mes.Items.Clear();

            Dictionary<string, double> lucroPorCliente = gestao.getLucrosByCliente();
            double maxGasto = lucroPorCliente.Values.Max();

            for (int i = 0; i < listView_cliente.Items.Count; i++)
            {
                string idCliente = listView_cliente.Items[i].SubItems[0].Text;

                if (lucroPorCliente.ContainsKey(idCliente) && lucroPorCliente[idCliente] == maxGasto)
                {
                    string[] row = {
                        listView_cliente.Items[i].SubItems[0].Text,
                        listView_cliente.Items[i].SubItems[1].Text,
                        listView_cliente.Items[i].SubItems[2].Text,
                        listView_cliente.Items[i].SubItems[3].Text,
                        listView_cliente.Items[i].SubItems[4].Text,
                        listView_cliente.Items[i].SubItems[5].Text,
                        listView_cliente.Items[i].SubItems[6].Text,
                        listView_cliente.Items[i].SubItems[7].Text,
                        maxGasto.ToString()
                    };

                    ListViewItem lviCliente = new ListViewItem(row);

                    listView_cliente_do_mes.Items.Add(lviCliente);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gestao.gravarClientesTXT();
            gestao.gravarVeiculosTXT();
            gestao.gravarAlugueresTXT();

            gestao.SaveClientesParticularesToXML();
            gestao.SaveClientesEmpresariaisToXML();
            gestao.SaveVeiculosLigeirosToXML();
            gestao.SaveVeiculosPesadosToXML();
            gestao.SaveAlugueresToXML();
        }

        private void btn_relatorio_cliente_Click(object sender, EventArgs e)
        {
            if (listView_cliente.SelectedItems.Count > 0)
            {
                RelatorioCliente relCliente = new RelatorioCliente();

                relCliente.ID = int.Parse(listView_cliente.SelectedItems[0].SubItems[0].Text);
                relCliente.NOME = listView_cliente.SelectedItems[0].SubItems[1].Text;
                relCliente.MORADA = listView_cliente.SelectedItems[0].SubItems[2].Text;
                relCliente.CONTACTO = listView_cliente.SelectedItems[0].SubItems[3].Text;
                relCliente.NIF = listView_cliente.SelectedItems[0].SubItems[4].Text;
                relCliente.TIPO = listView_cliente.SelectedItems[0].SubItems[5].Text;
                relCliente.CAPITALSOCIAL = listView_cliente.SelectedItems[0].SubItems[6].Text == string.Empty ? 0 : float.Parse(listView_cliente.SelectedItems[0].SubItems[6].Text);
                relCliente.IDADE = listView_cliente.SelectedItems[0].SubItems[7].Text == string.Empty ? 0 : int.Parse(listView_cliente.SelectedItems[0].SubItems[7].Text);

                relCliente.Historico = gestao.historicoAluguer(relCliente.ID.ToString());

                gestao.SaveRelatorioClienteToXML(relCliente);

                MessageBox.Show("Relatório do Cliente exportado com sucesso!");
            }
        }

        private void ListaDeClientes_Click(object sender, EventArgs e)
        {

        }

        private void button_cancelar_veiculo_Click(object sender, EventArgs e)
        {
            limparcamposVeiculos();
            btn_inserir_veiculos.Enabled = true;
            textBox_matricula.Enabled = true;
        }

        private void listView_veiculos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView_veiculos.Sort();
        }

        private void dtpDataDesde_ValueChanged(object sender, EventArgs e)
        {
            loadVeiculosParaAlugar();
        }

        private void dtpDataAte_ValueChanged(object sender, EventArgs e)
        {
            loadVeiculosParaAlugar();
        }
    }
}


