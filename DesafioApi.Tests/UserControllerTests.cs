using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using DesafioApi.Controllers;
using DesafioApi.Data;
using DesafioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApi.Tests;

public class UserControllerTests
{
    private readonly AppDbContext _context;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new AppDbContext(options);
        _controller = new UserController(_context);
    }

    [Fact]
    public async Task PostUser_DeveCriarUsuario_ComSucesso()
    {
        // Arrange
        var novoUsuario = new User
        {
            Name = "Teste",
            Email = "teste@email.com",
            Password = "123456"
        };

        // Act
        var resultado = await _controller.Create(novoUsuario);

        // Assert
        var resposta = resultado.Result as CreatedAtActionResult;
        resposta.Should().NotBeNull();
        resposta!.StatusCode.Should().Be(201);

        var usuarioCriado = resposta.Value as User;
        usuarioCriado.Should().NotBeNull();
        usuarioCriado!.Email.Should().Be("teste@email.com");
    }
}