namespace VitalographTest.Logic.Interfaces
{
    public interface ICharacterShiftService
    {
        string ShiftCharacters(string input, int shift, out bool succeeded);
        string AskForUserInput();
    }
}
