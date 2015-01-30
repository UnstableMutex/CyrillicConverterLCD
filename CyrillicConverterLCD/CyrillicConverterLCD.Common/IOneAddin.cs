namespace CyrillicConverterLCD.Common
{
    public interface IOneAddin
    {
        string DisplayName { get; }
        string Convert(string target);
    }
}