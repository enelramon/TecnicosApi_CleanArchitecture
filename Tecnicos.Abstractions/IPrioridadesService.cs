using System.Linq.Expressions;
using Tecnicos.Domain.DTO;

namespace Tecnicos.Abstractions;

public interface IPrioridadesService
{
    Task<bool> Guardar(PrioridadesDto prioridad);
    Task<bool> Eliminar(int prioridadId);
    Task<PrioridadesDto> Buscar(int id);
    Task<List<PrioridadesDto>> Listar(Expression<Func<PrioridadesDto, bool>> criterio);
    Task<bool> ExistePrioridad(int id, int tiempo, string descripcion);
}