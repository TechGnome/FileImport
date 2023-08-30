namespace TechGnome.FileImport.FileImportLibrary.ExtensionMethods;

public static class StringExtentions
{
    public static string InitCapital(this string source) 
    {
        if (string.IsNullOrEmpty(source))
        {
            return string.Empty;
        }
        return char.ToUpper(source[0]) + source.Substring(1);
    }
}