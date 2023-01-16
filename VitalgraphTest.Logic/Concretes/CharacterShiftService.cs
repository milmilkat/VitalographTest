using Microsoft.Extensions.Logging;
using System;
using System.Text;
using VitalographTest.Extensions.Exception;
using VitalographTest.Logic.Interfaces;

namespace VitalographTest.Logic.Concretes
{
    public class CharacterShiftService : ICharacterShiftService
    {
        private readonly ILogger<CharacterShiftService> _logger;

        public CharacterShiftService(ILogger<CharacterShiftService> logger)
        {
            _logger = logger;
        }

        public string ShiftCharacters(string input, int shift, out bool succeeded)
        {
            succeeded = true;
            var output = new StringBuilder();

            if (string.IsNullOrEmpty(input))
            {
                _logger.LogWarning(ExceptionCategories.NULL_VALUE);
                succeeded = false;
                return string.Empty;
            }

            foreach (var input_c in input)
            {
                if (!char.IsUpper(input_c))
                {
                    _logger.LogWarning(ExceptionCategories.NOT_SUPPORTED);
                    succeeded = false;
                    return string.Empty;
                }

                int shifted = input_c + shift;

                if (shifted > 90)
                    shifted -= 26;

                output.Append((char)shifted);
            }

            return output.ToString();
        }

        public string AskForUserInput()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();

            while (string.IsNullOrEmpty(input))
            {
                _logger.LogWarning(ExceptionCategories.NULL_VALUE);
                input = AskForUserInput();
            }

            return input;
        }
    }
}
