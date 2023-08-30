namespace TechGnome.FileImport.FileImportLibrary;

public class ImportConfig
{
    public string Name { get; set; } = "Default";
    public string[]? Delimiters { get; set; } = new String[] { "," };
    public string[]? CommentTokens { get; set; } = new string[] { "" };
    public bool HasHeader { get; set; } = true;
    public bool QuotedData { get; set; } = false;
    public int[]? FieldWidths { get; set; } = null;
    public bool TrimWhiteSpace { get; set; } = false;
    public int? SkipRows { get; set; } = 0;
    public FieldType FieldType { get; set; } = FieldType.Delimited;
    public bool UseHeaderAsFields { get; set; } = true;
    public List<string> Fields  { get; set; } = null;

    private static Dictionary<string, ImportConfig> instance = new Dictionary<string, ImportConfig>();

    public static readonly ImportConfig DEFAULT = new ImportConfig();
    public static readonly ImportConfig CSV = new ImportConfig() { Name = "CSV", QuotedData = true };
    public static readonly ImportConfig TAB = new ImportConfig() { Name = "TAB", Delimiters= new String[] { "\t",} };
    public static readonly ImportConfig PIPE = new ImportConfig() { Name = "PIPE", Delimiters= new String[] { "|",} };
    public static readonly ImportConfig SEMICOLON = new ImportConfig() { Name = "SEMICOLON", Delimiters= new String[] { ";",} };
    public static readonly ImportConfig USERDEFINED = new ImportConfig() { Name = "USER", Delimiters= new String[] { "",} };

    public ImportConfig()
    {
        Name = "Default";
        Delimiters = new String[] {","};
        CommentTokens = new String[] {""};
        HasHeader = true;
        QuotedData = false;
        FieldWidths = null;
        TrimWhiteSpace = false;
        SkipRows = 0;
        FieldType = FieldType.Delimited;
        UseHeaderAsFields = true;
        Fields = null;
    }

    public ImportConfig(ImportConfig config)
    {
        Name = config.Name;
        Delimiters = config.Delimiters;
        CommentTokens = config.CommentTokens;
        HasHeader = config.HasHeader;
        QuotedData = config.QuotedData;
        FieldWidths = config.FieldWidths;
        TrimWhiteSpace = config.TrimWhiteSpace;
        SkipRows = config.SkipRows;
        FieldType = config.FieldType;
        UseHeaderAsFields = config.UseHeaderAsFields;
        Fields = config.Fields;
    }

    override public string ToString()
    {
        return Name;
    }

    public static explicit operator ImportConfig(string value)
    {
        if (instance.TryGetValue(value, out ImportConfig? result))
        {
            return result;
        } else {
            throw new InvalidCastException();
        }
    }
}
