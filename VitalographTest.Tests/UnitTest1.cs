using Microsoft.Extensions.Logging;
using Moq;
using System;
using VitalographTest.Logic.Concretes;
using VitalographTest.Logic.Interfaces;
using Xunit;

namespace VitalographTest.Tests
{
    public class LogicTests
    {
        private readonly Mock<ILogger<CharacterShiftService>> _logger = new();

        [Fact]
        public void HANDLES_ALL_LETTERS_CORRECTLY()
        {
            ICharacterShiftService characterShiftService = new CharacterShiftService(_logger.Object);
            var result = characterShiftService.ShiftCharacters("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 5, out bool succeeded);
            var expected = "FGHIJKLMNOPQRSTUVWXYZABCDE";

            Assert.True(succeeded);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FAILS_IF_NOT_CAPITAL()
        {
            ICharacterShiftService characterShiftService = new CharacterShiftService(_logger.Object);
            characterShiftService.ShiftCharacters("abc", 5, out bool succeeded);

            Assert.False(succeeded);
        }

        [Fact]
        public void FAILS_IF_EMPTY_STRING()
        {
            ICharacterShiftService characterShiftService = new CharacterShiftService(_logger.Object);
            characterShiftService.ShiftCharacters("", 5, out bool succeeded);

            Assert.False(succeeded);
        }
    }
}
