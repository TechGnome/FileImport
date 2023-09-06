using System.Data;

namespace TechGnome.FileImport.FileImportLibrary;
public class FileImporter
{

    private static List<DataColumn> BuildDataColumns(string[] fields)
    {
        List<DataColumn> dataColumns = new List<DataColumn>();

        foreach(string field in fields)
        {
            Type? colType = Type.GetType("System.String", false, true);
            if (colType == null )
            {
                throw new InvalidDataException("Unable to crete the correct type secified.");
            }
            dataColumns.Add(new(field, colType));
        }
        return dataColumns;
    }

    private static List<DataColumn> CreateDataColumns(TextFieldParser reader, ImportConfig config)
    {
        List<DataColumn> dataColumns;
        if(config.UseHeaderAsFields || config.Fields == null || config.Fields.Count == 0)
        {
            string[]? fields = reader.ReadFields();
            if (fields == null) {
                    throw new InvalidDataException("Unable to determine the field columns of the file.");
            }
            dataColumns = BuildDataColumns(fields);
        } else {
            dataColumns = BuildDataColumns(config.Fields.ToArray());
        }

        return dataColumns;
    }

    private static DataTable CreateDataTable(TextFieldParser reader, ImportConfig config)
    {
        var dataTable = new DataTable();
        var dataColumns = CreateDataColumns(reader, config);
        dataTable.Columns.AddRange(dataColumns.ToArray());
        return dataTable;
    }

    private static TextFieldParser CreateParser(string source, ImportConfig config) 
    {
        return new TextFieldParser(source)
        {
            TextFieldType = config.FieldType,
            Delimiters = config.Delimiters!= null ? config.Delimiters.ToArray() : Array.Empty<string>(),
            HasFieldsEnclosedInQuotes = config.QuotedData,
            FieldWidths = config.FieldWidths != null ? config.FieldWidths : Array.Empty<int>(),
            CommentTokens = config.CommentTokens != null ? config.CommentTokens.ToArray() : Array.Empty<string>(),
            TrimWhiteSpace = config.TrimWhiteSpace
        };
    }

    public static List<DataColumn> Peek(string source)
    {
        return Peek(source, ImportConfig.DEFAULT);
    }

    public static List<DataColumn> Peek(string source, ImportConfig config)
    {
        var reader = CreateParser(source, config); 
        return CreateDataColumns(reader, config);
    }

    public static DataTable Import(string source)
    {
        return Import(source, ImportConfig.DEFAULT);
    }

    public static DataTable Import(string source, ImportConfig config)
    {
        var reader = CreateParser(source, config);
        if(reader == null)
        {
            throw new Exception("Unable to parse the file.");
        }
        DataTable importDataTable = CreateDataTable(reader, config);
        for (int rows = config.SkipRows ?? default; rows > 0 && !reader.EndOfData; rows--)
        {
            reader.ReadLine();
        }
        while(!reader.EndOfData)
        {
            string[]? currentRow = reader.ReadFields();
            if (currentRow == null) 
            {
                throw new InvalidDataException("Unable to properly parse the data row");
            }
            importDataTable.Rows.Add(currentRow);
        }
        return importDataTable;
    }
}
