using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESTUDIANTECRUD.Models.ViewModels
{
    public class EstudianteVM
    {
        public Estudiante oEstudiante { get; set; }

        public List<SelectListItem> oListaMateria { get; set; }

    }
}
