using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Matriculas
    {
        public int MatriculasId { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int GrupoClaseId { get; set; }
        public virtual GrupoClase GrupoClase { get; set; }

        public int CursosId { get; set; }
        public virtual Cursos Curso { get; set; }
    }
}