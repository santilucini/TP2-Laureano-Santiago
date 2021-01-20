using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Util
{
    public class Validaciones
    {
        private static string patron = @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$\s";

        public static bool VerificoLongitudCampo(string cadena)
        {
            return cadena.Length < 50;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool EstaVacioCampo(string cadena)
        {
            return !String.IsNullOrEmpty(cadena);
        }

        public static bool EsCampoValido(string cadena)
        {
            return !Regex.IsMatch(cadena, patron);
        }

        public static bool VerificoLongitudYVacio(string cadena)
        {
            return cadena.Length < 50 && !String.IsNullOrEmpty(cadena);
        }

        public static bool EsCadenaValida(string cadena)
        {
            if (VerificoLongitudYVacio(cadena))
            {
                return !Regex.IsMatch(cadena, patron);
            }
            else
            {
                return false;
            }
        }

        public static ErrorProvider EsTxtValido(TextBox txt, ErrorProvider errorProvider)
        {
            if (EstaVacioCampo(txt.Text))
            {
                if (VerificoLongitudCampo(txt.Text))
                {
                    if (Validaciones.EsCampoValido(txt.Text))
                    {
                        errorProvider.SetError(txt, "El campo ingresado no es valido");
                        return errorProvider;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    errorProvider.SetError(txt, "El campo debe contener menos de 50 caracteres");
                    return errorProvider;
                }
            }
            else
            {
                errorProvider.SetError(txt, "El campo ingresado no puede ser vacio");
                return errorProvider;
            }
        }

        public static bool EsNumerico(string cadena)
        {
            return Int32.TryParse(cadena, out int resultado);
        }

        public static bool ValidarLongitudClave(string clave, string claveRep)
        {
            if (String.Equals(clave, claveRep))
            {
                if (!String.IsNullOrEmpty(clave))
                {
                    return clave.Length >= 8;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static bool ClavesIguales(string cadena1, string cadena2)
        {
            return String.Equals(cadena1, cadena2);
        }

    }
}
