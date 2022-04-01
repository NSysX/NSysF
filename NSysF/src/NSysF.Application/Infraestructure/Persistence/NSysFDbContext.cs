using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using NSysF.Application.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSysF.Application.Infraestructure.Persistence
{
    public class NSysFDbContext : DbContext
    {
        //private readonly IPublisher _publicador;
        private readonly ILogger<NSysFDbContext> _logger;
        private IDbContextTransaction? _transaccionActual;

        public NSysFDbContext(DbContextOptions<NSysFDbContext> options,
                              ILogger<NSysFDbContext> logger) : base(options)
        {
            //this._publicador = publicador;
            this._logger = logger;

            this._logger.LogDebug("Se Creo el DbContext");
        }

        public DbSet<FaltantesDet> FaltantesDet => Set<FaltantesDet>();

        public async Task EmpiezaTransaccionAsync()
        {
            if (this._transaccionActual is not null)
            {
                this._logger.LogInformation($"Una Transaccion con el Id = { this._transaccionActual.TransactionId } ya esta creada");
                return;
            }

            this._transaccionActual = await Database.BeginTransactionAsync();
            this._logger.LogInformation($"Una nueva Transaccion fue creada con el ID = { this._transaccionActual.TransactionId }");
        }

        public async Task CommitTransaccionAsync()
        {
            // verifico que la transaccion no sea nula
            if (this._transaccionActual is null)
            {
                this._logger.LogError("La transaccion es NULA");
                return;
            }

            this._logger.LogInformation($"Comitiando la Transaccion con el ID = { this._transaccionActual.TransactionId }");

            await this._transaccionActual.CommitAsync();

            this._transaccionActual.Dispose();
            this._transaccionActual = null;
        }

        public async Task RollBackTransaccionAsync()
        {
            if (this._transaccionActual is null)
            {
                this._logger.LogInformation($"La transaccion es NULA");
                return;
            }

            this._logger.LogDebug($"Haciendo el RollBack a la transaccion con el ID = { this._transaccionActual.TransactionId }");

            await this._transaccionActual.RollbackAsync();

            this._transaccionActual.Dispose();
            this._transaccionActual = null;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NSysFDbContext).Assembly);
           
        }
    }
}
