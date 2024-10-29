using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Api.DTO;

public class TrabajosDto
{
    public string? Descripcion { get; set; }
    public double Monto { get; set; }
    public int PrioridadId { get; set; }
}