using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{
    public class Anuncios
    {
        public int idanuncio { set; get;}
        public int idusuario { set; get;}
        public string titulo { set; get;}
        public string descripcion { set; get;}
        public int puntuacion { set; get;}
        public string direccion { set; get;}
        public string estado { set; get;}
        public int tipoEstructura{ set; get;}
        public float valor {set; get; }
        public string fecha { set; get;}
        public string certificado { set; get; }

    }
}
