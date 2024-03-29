using AutoMapper;
using DojoCat.Members.Api.Configurations;
using DojoCat.Members.Application.CommandHandlers;
using DojoCat.Members.Application.Commands;
using DojoCat.Members.Common.DataContracts.Responses;
using DojoCat.Members.Common.Result;
using DojoCat.Members.Domain.Interfaces;
using DojoCat.Members.Domain.Models;
using DojoCat.Members.Domain.Utilities;
using DojoCat.Members.Infrastructure.Interfaces;

namespace DojoCat.Members.Tests.MembersApplicationTests;

[TestFixture]
public class NewMemberTests
{
    private NewMemberCommand _command;
    private NewMemberHandler _handler;
    private readonly IDateTimeProvider _dateTime = new DateTimeProvider();
    private Mock<INewMemberExecutor> _mockExecutor = new Mock<INewMemberExecutor>();
    private Mapper _mapper;
    private ILogger<NewMemberHandler> _logger = new NullLogger<NewMemberHandler>();

    [SetUp]
    public void Init()
    {
        _command = new NewMemberCommand(new Member());

        var mapConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperConfig()));
        _mapper = new Mapper(mapConfig);
    }

    [Test]
    public async Task Successfully_Add__New_Member_Test()
    {
        // Arrange
        _mockExecutor.Setup(ex => ex.Execute(It.IsAny<Member>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);

        _handler = new NewMemberHandler(_dateTime, _mapper, _mockExecutor.Object, _logger);

        // Act
        var result = _handler.Handle(_command, new CancellationToken());

        // Assert
        result.Result.IsSuccess.Should().BeTrue();
        result.Result.Error.ErrorType.Should().Be(Common.Errors.ErrorType.None);
        result.Result.Should().BeOfType<Result<MemberResponse>>();
    }

    [Test]
    public async Task Fail_To_Add_New_Member_Test()
    {
        // Arrange
        _mockExecutor.Setup(ex => ex.Execute(It.IsAny<Member>(), It.IsAny<CancellationToken>())).ReturnsAsync(0);

        _handler = new NewMemberHandler(_dateTime, _mapper, _mockExecutor.Object, _logger);

        // Act
        var result = _handler.Handle(_command, new CancellationToken());

        // Assert
        result.Result.IsSuccess.Should().BeFalse();
        result.Result.Error.ErrorType.Should().Be(Common.Errors.ErrorType.Failure);
        result.Result.Error.Description.Should().BeEquivalentTo("The system encountered a problem, please try again");
        result.Result.Should().BeOfType<Result<MemberResponse>>();
    }

    [Test]
    public async Task Add_New_Member_Throws_Exception_Test()
    {
        // Arrange
        _mockExecutor.Setup(ex => ex.Execute(It.IsAny<Member>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Throwing a wobbly, deal with it"));

        _handler = new NewMemberHandler(_dateTime, _mapper, _mockExecutor.Object, _logger);

        // Act
        var result = _handler.Handle(_command, new CancellationToken());

        // Assert
        result.Result.IsSuccess.Should().BeFalse();
        result.Result.Error.ErrorType.Should().Be(Common.Errors.ErrorType.Failure);
        result.Result.Error.Description.Should().BeEquivalentTo("The system encountered a problem, please try again");
        result.Result.Should().BeOfType<Result<MemberResponse>>();
    }
}
