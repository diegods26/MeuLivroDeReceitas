﻿using CommonTestUtilities.Requests;
using FluentAssertions;
using MeuLivroDeReceitas.Application.UseCases.User.Register;
using MeuLivroDeReceitas.Exceptions;

namespace Validators.Test.User.Register
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validator = new RegisterUserValidator();

            var request = RequestUserJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Error_Name_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestUserJsonBuilder.Build();
            request.Name = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should()
                .ContainSingle()
                .And.Contain(x => x.ErrorMessage.Equals(ResourceMessagesExceptions.NAME_EMPTY));
        }

        [Fact]
        public void Error_Email_Empty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestUserJsonBuilder.Build();
            request.Email = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should()
                .ContainSingle()
                .And.Contain(x => x.ErrorMessage.Equals(ResourceMessagesExceptions.EMAIL_EMPTY));
        }

        [Fact]
        public void Error_Email_Invalid()
        {
            var validator = new RegisterUserValidator();

            var request = RequestUserJsonBuilder.Build();
            request.Email = "Email.com";

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should()
                .ContainSingle()
                .And.Contain(x => x.ErrorMessage.Equals(ResourceMessagesExceptions.INVALID_EMAIL));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Error_Password_Invalid(int passwordLength)
        {
            var validator = new RegisterUserValidator();

            var request = RequestUserJsonBuilder.Build(passwordLength);

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should()
                .ContainSingle()
                .And.Contain(x => x.ErrorMessage.Equals(ResourceMessagesExceptions.INVALID_PASSWORD));
        }
    }
}
