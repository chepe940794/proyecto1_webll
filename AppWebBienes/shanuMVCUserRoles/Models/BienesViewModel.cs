using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shanuMVCUserRoles.Models
{
    public class BienesViewModel
    {
        [Display(Name = "Teléfono: ")]
        public string Telefono { get; set; }
        [Display(Name = "Imagen: ")]
        public HttpPostedFileBase Imagen { get; set; }
        [Display(Name = "Nombre de la propiedad: ")]
        public string NombrePropiedad { get; set; }
        [Display(Name = "Descripción: ")]
        public string Descripcion { get; set; }
        [Display(Name = "Ubicación: ")]
        public string Ubicacion { get; set; }
        [Display(Name = "Precio: ")]
        public decimal Precio { get; set; }
    }
}