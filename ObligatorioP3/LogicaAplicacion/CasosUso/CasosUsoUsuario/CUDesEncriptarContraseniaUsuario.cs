using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoUsuario
{
    public class CUDesEncriptarContraseniaUsuario : ICUDesEncriptarContraseniaUsuario
    {
        private readonly byte[] _key = Encoding.UTF8.GetBytes("A3S6D7F8G9H1J2K3"); // Debe ser de 16, 24 o 32 bytes para AES
        private readonly byte[] _iv = Encoding.UTF8.GetBytes("1A2B3C4D5E6F7G8H"); // Debe ser de 16 bytes para AES

        public string DesEncriptarContrasenia(string contraseniaEncriptada)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(contraseniaEncriptada)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}

