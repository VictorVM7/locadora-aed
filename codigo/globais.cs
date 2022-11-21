using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_aed
{
    internal class globais
    {
        // Variáveis que todo o sistema possui acesso para modificar (Public - Todos tem acesso // Static - Estática  // Tipo )
        public static string version = "1.0";
        public static Boolean logado = false;
        public static int nivel = 0;

        // Nível = 3 (Grupo)
        // Nível = 2 (Vendedores)
        // Nível = 1 (Clientes)
        // Nível = 0 (Deslogado)
    }
}
