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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent(); // Inicializa o programa com todos os componentes
            F_Login f_login = new F_Login(this); // Cria e inicializa uma tela de login (This significa o próprio formulário)
            f_login.ShowDialog(); // Mostra na tela do usuário a tela de login
        }

        // Função que exibe caixa de alerta para o usuário confirmar a ação. Ela retorna a resposta "Yes" ou "No". Podendo ser convertida em string para comparação
        static DialogResult perguntaUsuario(DialogResult opcaoUsuario)
        {
            opcaoUsuario = MessageBox.Show("Deseja executar essa ação?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return opcaoUsuario;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Botao do menu login - Entrar
        private void entrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Se o botão de login for chamado e ele não estiver logado, abre a tela de login
            if(lb_acesso.Text.Equals("0") && lb_usuario.Text.Equals("Deslogado"))
            {
                F_Login f_Login = new F_Login(this);
                f_Login.ShowDialog();
            }

            // Se o botão de login for chamado e ela estiver logado, peça para que deslogue primeiro
            else
            {
                MessageBox.Show($"Deslogue do usuário {lb_usuario.Text} primeiro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Botao do menu login - Sair
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Chama a função de aparecer alerta e pergunta se o usuário deseja deslogar
            DialogResult opcaoUsuario = new DialogResult();
            string resultado = perguntaUsuario(opcaoUsuario).ToString(); // Retorna o valor da escolha do usuário convertendo em string "Yes" ou "No"

            // Se ele quiser sair, execute essa ação. Deslogue o usuário do sistema.
            if (resultado == "Yes")
            {
                lb_acesso.Text = "0";  // Pega da linha 1 o item na coluna 4 convertendo em string Label - Acesso
                lb_usuario.Text = "Deslogado"; ; // Pega da linha 1 o item na coluna 1 já sendo string Label - Username
                globais.nivel = 0; // Muda na classe globais a variável nível de acordo o usuário logado
                globais.logado = false; // Muda o status para logado em globais
            }
        }
    }
}
