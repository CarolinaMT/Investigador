using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Investigador
{
	[Key]
	public Guid InvestigadorID { get; set; }
	public string Nombre { get; set; }
	public string Apellido { get; set; }
	public string Afiliacion { get; set; }
	public string Rol { get; set; }
}
