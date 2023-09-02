using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public class Proyecto
{
	[Key]
	public Guid proyectoID { get; set; }
	public string nombre { get; set; }
	public DateTime fechaInicio { get; set; }
	public DateTime fechaFin { get; set; }
	public string lider { get; set; }
	public string area { get; set; }
	public string descripción { get; set; }
}
