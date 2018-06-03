using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Evaluaciones
    {
        public enum ConvocatoriaType
            {
                Ordinaria,
                Extraordinaria
            }
            public int Id { get; set; }
            public int CursoId { get; set; }
            public virtual Cursos Curso { get; set; }
            public string UserId { get; set; }
            public virtual ApplicationUser User { get; set; }
            public ConvocatoriaType Convocatoria { get; set; }
            public int Trabajo1 { get; set; }
            public int Trabajo2 { get; set; }
            public int Trabajo3 { get; set; }
            public int Test { get; set; }
            public int Practica { get; set; }

        
    }
}