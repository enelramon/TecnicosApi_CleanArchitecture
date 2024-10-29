using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tecnicos.Abstractions;
using Tecnicos.Data.Context;
using Tecnicos.Data.Models;
using Tecnicos.Domain.DTO;

namespace Tecnicos.Services;

public class PrioridadesService(IDbContextFactory<TecnicosContext> DbFactory) : IPrioridadesService
{
    private async Task<bool> Existe(int prioridadId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prioridades.AnyAsync(e => e.PrioridadId == prioridadId);
    }

    private async Task<bool> Insertar(PrioridadesDto prioridadDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var prioridad = new Prioridades()
        {
            Fecha = DateTime.Now,
            Descripcion = prioridadDto.Descripcion,
            Tiempo = prioridadDto.Tiempo
        };
        contexto.Prioridades.Add(prioridad);
        var guardo= await contexto.SaveChangesAsync() > 0;
        prioridadDto.PrioridadId = prioridad.PrioridadId;
        return guardo;
    }

    private async Task<bool> Modificar(PrioridadesDto prioridadDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var prioridad = new Prioridades()
        {
            PrioridadId = prioridadDto.PrioridadId,
            Fecha = DateTime.Now,
            Descripcion = prioridadDto.Descripcion,
            Tiempo = prioridadDto.Tiempo
        };
        contexto.Update(prioridad);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    public async Task<bool> Guardar(PrioridadesDto prioridad)
    {
        if (!await Existe(prioridad.PrioridadId))
        {
            return await Insertar(prioridad);
        }
        else
        {
            return await Modificar(prioridad);
        }
    }

    public async Task<bool> Eliminar(int prioridadId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prioridades
            .Where(e => e.PrioridadId == prioridadId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<PrioridadesDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var prioridad = await contexto.Prioridades
            .Where(e => e.PrioridadId == id)
            .Select(p => new PrioridadesDto()
            {
                PrioridadId = p.PrioridadId,
                Descripcion = p.Descripcion,
                Tiempo = p.Tiempo
            }).FirstOrDefaultAsync();

        return prioridad ?? new PrioridadesDto();
    }

    public async Task<List<PrioridadesDto>> Listar(Expression<Func<PrioridadesDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prioridades
            .Select(p => new PrioridadesDto()
            {
                PrioridadId = p.PrioridadId,
                Descripcion = p.Descripcion,
                Tiempo = p.Tiempo
            })
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> ExistePrioridad(int id, int tiempo, string descripcion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prioridades
            .AnyAsync(e => e.PrioridadId != id
            && e.Tiempo == tiempo
            || e.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }
}

