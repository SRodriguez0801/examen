using System;

namespace Electrodomestico.Models
{
    [Serializable]
    public class Usuarios
    {
        public string correo;
        public string password;

        public bool autenticador(string email, string pass)
        {
            if (correo == email && password == pass)
            {
                return true;
            }
            return false;
        }

    }
}
