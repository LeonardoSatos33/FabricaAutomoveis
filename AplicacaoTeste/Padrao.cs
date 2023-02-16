using DeskUtilDLL;


using DTIForms.Util;
using ExemploDDD.DAO;
using NTIComponentes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtilDLL;


namespace AplicacaoTeste
{
    public partial class Padrao : NTIForm
    {

        #region INICIALIZACAO
        public Padrao()
        {
            InitializeComponent();
            configuraForm();
        }
        private void DTIFormPadrao_Load(object sender, EventArgs e)
        {
            Consultar();
        }
        #endregion

        #region METODOS
        private void Consultar()
        {
            var filtros = new NTIFiltro();

            if (!String.IsNullOrEmpty(tbModeloAutomovel.Text))
                filtros.adiciona("MODELO_AUTOMOVEL",
                    tbModeloAutomovel.Text, typeof(string), NTIFiltro._permuta);

            if (!String.IsNullOrEmpty(tbAnoAutomovel.Text))
                filtros.adiciona("ANO_AUTOMOVEL",
                    tbAnoAutomovel.Text, typeof(string), NTIFiltro._permuta);

            /*if (!String.IsNullOrEmpty(tbNome.Text))
                filtros.adiciona("nom_animal",
                                 tbNome.Text,
                                 typeof(string),
                                 NTIFiltro._permuta);

            if (!String.IsNullOrEmpty(deInicio.Text))
                filtros.adiciona("dat_nascimento",
                                 deInicio.DateTime,
                                 typeof(DateTime),
                                 NTIFiltro._maior);*/

            dgvPrincipal.DataSource = new AutomovelDAO().Listar(filtros);
            dgvPrincipal.Refresh();
        }

        private void Incluir()
        {
            var Manutencao = new Manutencao(null, "i");
            Manutencao.ShowDialog();
            Consultar();
        }

        private void Editar()
        {
            
            var lista = dgvPrincipal.DataSource as List<ExemploDDD.Domain.AutomoveisDTO>;

            int indiceSelecionado = gridViewPrincipal.GetDataSourceRowIndex(gridViewPrincipal.FocusedRowHandle);

            var automovelSelecionado = lista[indiceSelecionado];

            var automovel = new AutomovelDAO().Get(automovelSelecionado.id_automovel);

            var form = new Manutencao(automovel, "a");
            form.ShowDialog();

            Consultar();
            

        }

        private void Excluir()
        {
            
            if (!DeskUtil.getResposta("Deseja realmente excluir?"))
                return;

            var lista = dgvPrincipal.DataSource as List<ExemploDDD.Domain.AutomoveisDTO>;

            int indiceSelecionado = gridViewPrincipal.GetDataSourceRowIndex(gridViewPrincipal.FocusedRowHandle);

            var automovelselecionado = lista[indiceSelecionado];

            var automovel = new AutomovelDAO().Get(automovelselecionado.id_automovel);

            if (DTIFormsUtil.TratarRetornoPersistencia(new AutomovelDAO().delete(automovel)))
                Consultar();
                

        }

        private void SobreOPrograma()
        {
            DeskUtil.mostrarMensagemInformativa("Este programa tem por objetivo o cadastro de Automoveis", "Informação");
        }

        private void MenuClick(object sender, EventArgs e)
        {
            if (sender == miEditar)
                Editar();
            else if (sender == miNovo)
                Incluir();
            else if (sender == miExcluir)
                Excluir();
            else if (sender == miSobreOPrograma)
                SobreOPrograma();
            else if (sender == miSair)
                Close();
        }

        #endregion

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void repositoryEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void repositoryExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            Incluir();
        }

        private void dgvPrincipal_Click(object sender, EventArgs e)
        {

        }

        private void tbModeloAutomovel_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblModeloAutomovel_Click(object sender, EventArgs e)
        {

        }
    }
}
