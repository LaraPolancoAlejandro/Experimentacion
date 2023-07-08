using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimentacion.Objects
{
    public class UsuarioDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroDocumentoIdentidad { get; set; }
        public string TipoDeDocumento { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
    }

}
