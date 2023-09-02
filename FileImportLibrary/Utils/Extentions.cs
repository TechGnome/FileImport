namespace TechGnome.FileImport.FileImportLibrary.Extensions;

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

    public static string Last(this string source, int length)
    {
        if (source.Length <= length) return source;
        return source.Substring(source.Length - length);
    }
}