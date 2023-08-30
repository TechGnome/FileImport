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
        var reader = new TextFieldParser(source);
        reader.TextFieldType = config.FieldType;
        reader.Delimiters = config.Delimiters;
        reader.HasFieldsEnclosedInQuotes = config.QuotedData;
        // reqader.CommentTokens = config.CommentTokens;
        // reqader.FieldWidths = config.FieldWidths;
        // reqader.TrimWhiteSpace = config.TrimWhiteSpace;

        return reader;
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
        var importDataTable = new DataTable();
        var reader = CreateParser(source, config);
        importDataTable = CreateDataTable(reader, config);
        while(!reader.EndOfData)
        {
            string[] currentRow = reader.ReadFields();
            importDataTable.Rows.Add(currentRow);
        }
        return importDataTable;
    }
}
