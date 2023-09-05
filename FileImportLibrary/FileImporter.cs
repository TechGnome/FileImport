using System.Data;

namespace TechGnome.FileImport.FileImportLibrary;
public class FileImporter
{

    private static DataTable CreateDataTable(TextFieldParser reader, ImportConfig config)
    {
        List<DataColumn> dataColumns = new List<DataColumn>();
        if(config.UseHeaderAsFields || config.Fields == null || config.Fields.Count == 0)
        {
            string[]? fields = reader.ReadFields();
            foreach(string field in fields)
            {
                dataColumns.Add(new(field, System.Type.GetType("System.String")));
            }
        } else {
            foreach(string field in config.Fields)
            {
                dataColumns.Add(new(field, System.Type.GetType("System.String")));
            }
        }
        var dataTable = new DataTable();
        dataTable.Columns.AddRange(dataColumns.ToArray());
        return dataTable;
    }

    private static TextFieldParser CreateParser(string source, ImportConfig config) 
    {
        return new TextFieldParser(source)
        {
            TextFieldType = config.FieldType,
            Delimiters = config.Delimiters!= null ? config.Delimiters.ToArray() : Array.Empty<string>(),
            HasFieldsEnclosedInQuotes = config.QuotedData
            // CommentTokens = config.CommentTokens != null ? config.CommentTokens.ToArray() : Array.Empty<string>(),
            // FieldWidths = config.FieldWidths,
            // TrimWhiteSpace = config.TrimWhiteSpace
        };
    }

    public static DataTable Peek(string source)
    {
        return Peek(source, ImportConfig.DEFAULT);
    }

    public static DataTable Peek(string source, ImportConfig config)
    {
        var importDataTable = new DataTable();
        var reader = CreateParser(source, config); 
        importDataTable = CreateDataTable(reader, config);
        return importDataTable;
    }

    public static DataTable Import(string source)
    {
        return Import(source, ImportConfig.DEFAULT);
    }

    public static DataTable Import(string source, ImportConfig config)
    {
        var reader = CreateParser(source, config);
        DataTable importDataTable = CreateDataTable(reader, config);
        for (int rows = config.SkipRows ?? default; rows > 0 && !reader.EndOfData; rows--)
        {
            reader.ReadLine();
        }
        while(!reader.EndOfData)
        {
            string[] currentRow = reader.ReadFields();
            importDataTable.Rows.Add(currentRow);
        }
        return importDataTable;
    }
}
