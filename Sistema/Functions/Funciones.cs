// Written By Ismael Heredia in the year 2017

using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace sistema
{
    public class Funciones
    {

        public string mensaje(string titulo, string contenido, string tipo)
        {
            return "<script>" +
                    "swal({" +
                            "title: '" + titulo + "'," +
                            "text: '" + contenido + "'," +
                            "type:'" + tipo + "'," +
                            "html:true," +
                            "animation: false" +
                     "});" +
                    "</script>";
        }

        public string mensaje_con_redireccion(string titulo, string contenido, string tipo, string ruta)
        {
            return "<script>" +
                    "swal({" +
                            "title: '" + titulo + "'," +
                            "text: '" + contenido + "'," +
                            "type:'" + tipo + "'," +
                            "html:true," +
                            "animation: false" +
                     "},function() {" +
                        "window.location.href = '" + ruta + "';" +
                     "});" +
                    "</script>";
        }

        public string get_username_in_cookie(string cookie_content)
        {
            string[] datos = cookie_content.Split('-');
            string username_cookie = datos[0];
            string password_cookie = datos[1];
            return username_cookie;
        }

        public bool valid_cookie(string content)
        {
            UsuarioBL usuarioBL = new UsuarioBL();
            string[] data = content.Split('-');
            string username = data[0];
            string password = data[1];
            if (username != "" && password != "")
            {
                if (usuarioBL.check_login(username, password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool valid_cookie_admin(string content)
        {
            UsuarioBL usuarioBL = new UsuarioBL();
            string[] data = content.Split('-');
            string username = data[0];
            string password = data[1];
            if (username != "" && password != "")
            {
                if (usuarioBL.check_login(username, password))
                {
                    if (usuarioBL.get_user_type(username) == "Administrador")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string md5_encode(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }

        public bool valid_number(String numberString)
        {
            int number;
            return int.TryParse(numberString,out number);
        }

        public String fecha_del_dia()
        {
            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("yyyy-MM-dd");
            return fecha_actual;
        }
    }
}