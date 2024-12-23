﻿using AutoFixture;
using FluentAssertions;
using Telegram.Configurations;
using Telegram.Contracts;
using Telegram.DbContexts;
using Telegram.Repositories;
using Telegram.Services;

namespace TelegramTests
{
    public class UserServiceTest
    {
        private readonly UserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IFixture _fixture = new Fixture();

        public UserServiceTest()
        {
            DbNameConvention dbUserConvention = new DbNameConvention()
            {
                Schema = "TestActual"
            };
            _userRepository = new UserRepository(new UserContext(dbUserConvention));
            _userService = new UserService(_userRepository);
        }

        [Fact]
        public void AddUser_ShouldCreateUser_WhenAllParametersNull()
        {
            int id = 1;

            var result = _userService.RegisterUser(id, null, null, null);

            result.Should().BeTrue();
        }

        [Fact]
        public void AddUser_ShouldNotCreateUser_WhenHasSameUserId()
        {
            int id = 1;

            _userService.RegisterUser(id, null, null, null);
            var result = _userService.RegisterUser(id, null, null, null);

            result.Should().BeFalse();
        }
    }
}
