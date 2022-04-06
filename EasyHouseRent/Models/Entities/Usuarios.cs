using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{

    /*public struct Usuarios
    {

    }*/
    public class Usuarios
    {
        BaseData db = new BaseData();
        private int _idusuario = 0;

        public int idusuario { set { _idusuario = value; } get { return _idusuario; }  }

        /*private int seconds = 0;

        public int Horas { 
            get
            {
                return seconds / 3600;
            }
            set
            {
                seconds = value * 3600;
            }
        }

        public int idusuario2 { 
            set 
            { 
                _idusuario = value;
            } 
            get 
            { 
                Horas = 50
                return _idusuario;
            } 
        }*/


        private string _nombre = "";

        public string nombre { set { _nombre = value; } get { return _nombre;} }

        private string _email = "";

        public string email { set { _email = value; } get { return _email;} }

        private string _contraseña = "";

        public string contraseña { set { _contraseña = value; } get { return _contraseña; } }

        public string apellidos { set; get; }
        public int edad { set; get; }
        public string telefono { set; get; }
        public string estado { set; get; }
        public int departamento { set; get; }
        public int municipio { set; get; }


        public string Getusuarios(string sql)
        {
            
            DataTable dt = db.getTable(sql);
/*            List<Usuarios> usersList = new List<Usuarios>();
            usersList = (from DataRow dr in dt.Rows
                         select new Usuarios()
                         {
                             idusuario = Convert.ToInt32(dr["idusuario"]),
                             nombre = dr["nombre"].ToString(),
                             apellidos = dr["apellidos"].ToString(),
                             edad = Convert.ToInt32(dr["edad"]),
                             telefono = dr["telefono"].ToString(),
                             email = dr["email"].ToString(),
                             contraseña = dr["contraseña"].ToString(),
                             estado = dr["estado"].ToString(),
                             departamento = Convert.ToInt32(dr["departamento"]),
                             municipio = Convert.ToInt32(dr["municipio"])

                         }).ToList();*/

            List<string> lista = new List<string>();
            string dato = "";
            foreach (DataRow dr in dt.Rows)
            {
                dato = dr["nombre"].ToString();   
            }

            return dato;

        }
    }
}