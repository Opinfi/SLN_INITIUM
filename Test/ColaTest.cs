using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Test
{
    public  class ColaTest
    {
        private IColaRepository _colaRepository;

        [Test]
        public void AddTestOk()
        {
            int result = 0;

            var options = new DbContextOptionsBuilder<InitiumDbContext>()
            .UseInMemoryDatabase(databaseName: "InitiumDbContextDatabase")
            .Options;

            using (var context = new InitiumDbContext(options))
            {
                _colaRepository = new ColaRepository(context);

                 
                result = _colaRepository.AddAsync(new Cola { Codigo= "0001", TiempoAtencion=2, Estado=true, FechaRegistro= DateTime.Now, UsuarioRegistro="Admin"  }).Result;
                result = _colaRepository.AddAsync(new Cola { Codigo = "0002", TiempoAtencion = 3, Estado = true, FechaRegistro = DateTime.Now, UsuarioRegistro = "Admin" }).Result;
            }

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void AddTestNotOk()
        {
            int result2 = 0;

            var options = new DbContextOptionsBuilder<InitiumDbContext>()
            .UseInMemoryDatabase(databaseName: "InitiumDbContextDatabase")
            .Options;

            using (var context = new InitiumDbContext(options))
            {
                _colaRepository = new ColaRepository(context);


                result2 = _colaRepository.AddAsync(new Cola { Codigo = "0002", TiempoAtencion =3,  UsuarioRegistro = "Admin" }).Result;
            }

            Assert.That(result2, Is.EqualTo(1));

        }
    }
}
