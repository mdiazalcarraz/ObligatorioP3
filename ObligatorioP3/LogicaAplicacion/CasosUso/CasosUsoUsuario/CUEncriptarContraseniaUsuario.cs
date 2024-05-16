using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoUsuario
{
    public class CUEncriptarContraseniaUsuario : ICUEncriptarContraseniaUsuario
    {
        private readonly byte[] _key = Encoding.UTF8.GetBytes("A3S6D7F8G9H1J2K3"); // Debe ser de 16, 24 o 32 bytes para AES
        private readonly byte[] _iv = Encoding.UTF8.GetBytes("1A2B3C4D5E6F7G8H"); // Debe ser de 16 bytes para AES
        public string EncriptarContrasenia(string contrasenia)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(contrasenia);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
    }
}
