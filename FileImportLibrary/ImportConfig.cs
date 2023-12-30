using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TechGnome.FileImport.FileImportLibrary;

[XmlRoot("Config", Namespace = "https://github.com/TechGnome/FileImport", IsNullable = false)]
public class ImportConfig
{

    private FieldType _fieldType;

    [XmlAttribute]
    public string Name { get; set; } = "Default";

    [XmlArray("Delimiters")]
    [XmlArrayItem("Delimiter")]
    [JsonPropertyName("delimiters")]
    public List<string>? Delimiters { get; set; } = new List<string> { new(",") };

    [XmlArray("Comments")]
    [XmlArrayItem("Token")]
    [JsonPropertyName("comments")]
    public List<string>? CommentTokens { get; set; } = null;

    [XmlAttribute]
    public bool HasHeader { get; set; } = true;

    [XmlAttribute]
    public bool QuotedData { get; set; } = false;

    [XmlArray("FieldWidths")]
    [XmlArrayItem("Width")]
    [JsonPropertyName("fieldWidths")]
    public int[]? FieldWidths { get; set; } = null;

    [XmlAttribute]
    public bool TrimWhiteSpace { get; set; } = false;

    [XmlIgnore]
    public int? SkipRows { get; set; } = 0;

    [XmlAttribute("SkipRows")]
    [JsonIgnore]
    [YamlIgnore]
    public string SkipRowsValue
    {
        get
        {
            if (SkipRows != null && SkipRows > 0)
            {
                return SkipRows.Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        set
        {
            if (value != null)
            {
                SkipRows = int.Parse(value);
            }
        }
    }


    [XmlAttribute]
    public FieldType FieldType
    {
        get
        {
            return _fieldType;
        }
        set
        {
            _fieldType = value;
            if (value == FieldType.FixedWidth)
            {
                Delimiters = null;
            }
        }
    }

    [XmlAttribute]
    public bool UseHeaderAsFields { get; set; } = true;

    [XmlArray("Fields")]
    [XmlArrayItem("Name")]
    [JsonPropertyName("fields")]
    public List<string>? Fields { get; set; } = null;

    public bool ShouldSerializeSkipRowsValue()
    {
        return SkipRowsValue != string.Empty;
    }

    private static Dictionary<string, ImportConfig> instance = new Dictionary<string, ImportConfig>();

    public static readonly ImportConfig DEFAULT = new();
    public static readonly ImportConfig CSV = new() { Name = "CSV" };
    public static readonly ImportConfig CSV_EXTENDED = new() { Name = "CSV Extended", QuotedData = true };
    public static readonly ImportConfig TAB = new() { Name = "Tab", Delimiters = new List<string> { new("\t") } };
    public static readonly ImportConfig PIPE = new() { Name = "Pipe", Delimiters = new List<string> { new("|") } };
    public static readonly ImportConfig SEMICOLON = new() { Name = "Semicolon", Delimiters = new List<string> { new(";") } };
    public static readonly ImportConfig USERDEFINED = new() { Name = "User", Delimiters = new List<string> { new(";") } };
    public static readonly ImportConfig FIXED_WIDTH = new() { Name = "Fixed Width", FieldType = FieldType.FixedWidth, TrimWhiteSpace = true };

    public ImportConfig()
    {
        Name = "Default";
        Delimiters = new List<string> { new(",") };
        CommentTokens = null;
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
        }
        else
        {
            throw new InvalidCastException();
        }
    }

    public static void Save(string fileName, ImportConfig config)
    {
        switch (fileName.Last(4).ToLower())
        {
            case ".xml":
                SaveAsXml(fileName, config);
                break;
            case ".yml":
            case "yaml":
                SaveAsYaml(fileName, config);
                break;
            case "json":
            default:
                SaveAsJson(fileName, config);
                break;
        }
    }

    public static ImportConfig? Load(string fileName)
    {
        switch (fileName.Last(4).ToLower())
        {
            case ".xml":
                return LoadFromXml(fileName);
            case ".yml":
            case "yaml":
                return LoadFromYaml(fileName);
            case "json":
            default:
                return LoadFromJson(fileName);
        }
    }

    private static void SaveAsJson(string fileName, ImportConfig config)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        File.WriteAllText(fileName, JsonSerializer.Serialize(config, options));
    }

    private static ImportConfig? LoadFromJson(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        return JsonSerializer.Deserialize<ImportConfig?>(jsonString, options)!;
    }

    private static void SaveAsXml(string fileName, ImportConfig config)
    {
        var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        XmlSerializer serializer = new(typeof(ImportConfig));
        TextWriter writer = new StreamWriter(fileName);
        serializer.Serialize(writer, config, emptyNs);
        writer.Close();
    }

    private static ImportConfig? LoadFromXml(string fileName)
    {
        XmlSerializer serializer = new(typeof(ImportConfig));
        FileStream fs = new(fileName, FileMode.OpenOrCreate);
        TextReader reader = new StreamReader(fs);
        ImportConfig? config = (ImportConfig?)serializer.Deserialize(reader);
        return config;
    }

    private static void SaveAsYaml(string fileName, ImportConfig config)
    {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
            .Build();
        var yaml = serializer.Serialize(config);
        File.WriteAllText(fileName, yaml);
    }
    private static ImportConfig? LoadFromYaml(string fileName)
    {
        string yamlString = File.ReadAllText(fileName);
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        return deserializer.Deserialize<ImportConfig>(yamlString);
    }

}
