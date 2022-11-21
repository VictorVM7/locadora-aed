using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace locadora_aed
{
    public partial class F_Login : Form
    {
        Form1 form1; // Cria um novo formulário 1 (Tela Form1)
        DataTable datatable = new DataTable();

        public F_Login(Form1 f)
        {
            InitializeComponent();
            form1 = f; // Passa a própria tela para a tela de login para que se possa usar os dados. Manipula o filho através do pai
        }

        // Verificações de login ao clicar no botão entrar
        private void btn_logar_Click(object sender, EventArgs e)
        {
            // Variáveis que recebem o que o usuário digitar nos TextBox
            string username = tb_username.Text;
            string senha = tb_senha.Text;

            // Verifica se o username ou senha está vazio
            if (username == "" && senha == "") 
            {
                MessageBox.Show("Usuário e Senha não foram preenchidos!"); // Se estiver vazio, retorna essa mensagem
                tb_username.Focus();  // Foca o cursor em username para o usuário preencher
                return;  // Fecha a chamada do click "Entrar"
            }

            // Verifica se apenas o usuário está vazio    
            else if(username == "")
            {
                MessageBox.Show("Usuário não foi preenchido!"); // Se estiver vazio, retorna essa mensagem
                tb_username.Focus();  // Foca o cursor em username para o usuário preencher
                return;  // Fecha a chamada do click "Entrar"
            }

            // Verifica se apenas a senha está vazio  
            else if (senha == "")
            {
                MessageBox.Show("Senha não foi preenchida!"); // Se estiver vazio, retorna essa mensagem
                tb_senha.Focus();  // Foca o cursor em senha para o usuário preencher
                return;  // Fecha a chamada do click "Entrar"
            }

            // Consulta se o usuário e senha existem no banco de dados. Se ele não retornar, não existe ou algo está errado. Se retonar, o usuário existe.
            string sql = $"SELECT * FROM tb_usuarios WHERE T_USERNAME = '{username}' AND T_SENHAUSUARIO = '{senha}'";
            datatable = banco.consultaBanco(sql); // Variável que irá receber os dados da consulta acima vinda da classe Banco

            // Se na tabela do VS que foi retornada, possuir pelo menos uma linha. Mude os valores da tela principal
            if (datatable.Rows.Count == 1) 
            {
                form1.lb_acesso.Text = datatable.Rows[0].ItemArray[3].ToString();  // Pega da linha 1 o item na coluna 4 convertendo em string Label - Acesso
                form1.lb_usuario.Text = datatable.Rows[0].ItemArray[1].ToString(); ; // Pega da linha 1 o item na coluna 1 já sendo string Label - Username
                globais.nivel = int.Parse(datatable.Rows[0].ItemArray[3].ToString()); // Muda na classe globais a variável nível de acordo o usuário logado
                globais.logado = true; // Muda o status para logado em globais
                this.Close(); // Fecha a janela de login caso logado
            }

            // Se não encontrar, passe uma mensagem de não encontrado
            else
            {
                MessageBox.Show("Usuário não encontrado");
            }
            
        }

        // Cancela o login
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Fecha caso clicar no "Cancelar"
        }

        private void F_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
