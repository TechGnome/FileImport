using System.Data;

namespace TechGnome.FileImport.FileImportLibraryTest;

public class FileImportTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestImport_Default()
    {
        DataTable result = FileImporter.Import("../../../data/SampleData.csv");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Columns.Count, Is.EqualTo(10));
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Rows.Count, Is.EqualTo(16));

        // Check the fields - from the file header row
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Columns[1].ColumnName, Is.EqualTo("Field 2"));
        Assert.That(result.Columns[2].ColumnName, Is.EqualTo("Field 3"));
        Assert.That(result.Columns[3].ColumnName, Is.EqualTo("Field 4"));
        Assert.That(result.Columns[4].ColumnName, Is.EqualTo("Field 5"));
        Assert.That(result.Columns[5].ColumnName, Is.EqualTo("Field 6"));
        Assert.That(result.Columns[6].ColumnName, Is.EqualTo("Field 7"));
        Assert.That(result.Columns[7].ColumnName, Is.EqualTo("Field 8"));
        Assert.That(result.Columns[8].ColumnName, Is.EqualTo("Field 9"));
        Assert.That(result.Columns[9].ColumnName, Is.EqualTo("Field 10"));

        // Sample some of the data
        Assert.That(result.Rows[0]["Field 1"],  Is.EqualTo("Text 11"));
        Assert.That(result.Rows[1]["Field 2"],  Is.EqualTo("246"));
        Assert.That(result.Rows[2]["Field 3"],  Is.EqualTo("2023-08-03"));
        Assert.That(result.Rows[3]["Field 4"],  Is.EqualTo("Text 42"));
        Assert.That(result.Rows[4]["Field 5"],  Is.EqualTo("2280"));
        Assert.That(result.Rows[5]["Field 6"],  Is.EqualTo("2023-09-06"));
        Assert.That(result.Rows[6]["Field 7"],  Is.EqualTo("Text 73"));
        Assert.That(result.Rows[7]["Field 8"],  Is.EqualTo("256"));
        Assert.That(result.Rows[8]["Field 9"],  Is.EqualTo("2023-10-09"));
        Assert.That(result.Rows[9]["Field 10"], Is.EqualTo("Text 104"));

        // Sample the last row
        Assert.That(result.Rows[15]["Field 1"],  Is.EqualTo("Text 161"));
        Assert.That(result.Rows[15]["Field 2"],  Is.EqualTo("1968"));
        Assert.That(result.Rows[15]["Field 3"],  Is.EqualTo("2023-08-16"));
        Assert.That(result.Rows[15]["Field 4"],  Is.EqualTo("Text 162"));
        Assert.That(result.Rows[15]["Field 5"],  Is.EqualTo("7296"));
        Assert.That(result.Rows[15]["Field 6"],  Is.EqualTo("2023-09-16"));
        Assert.That(result.Rows[15]["Field 7"],  Is.EqualTo("Text 163"));
        Assert.That(result.Rows[15]["Field 8"],  Is.EqualTo("65536"));
        Assert.That(result.Rows[15]["Field 9"],  Is.EqualTo("2023-10-16"));
        Assert.That(result.Rows[15]["Field 10"], Is.EqualTo("Text 164"));

    }

    [Test]
    public void TestImport_CSV()
    {
        DataTable result = FileImporter.Import("../../../data/SampleData_Quotes.csv", ImportConfig.CSV);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Columns.Count, Is.EqualTo(10));
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Rows.Count, Is.EqualTo(16));

        // Check the fields - from the file header row
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Columns[1].ColumnName, Is.EqualTo("Field 2"));
        Assert.That(result.Columns[2].ColumnName, Is.EqualTo("Field 3"));
        Assert.That(result.Columns[3].ColumnName, Is.EqualTo("Field 4"));
        Assert.That(result.Columns[4].ColumnName, Is.EqualTo("Field 5"));
        Assert.That(result.Columns[5].ColumnName, Is.EqualTo("Field 6"));
        Assert.That(result.Columns[6].ColumnName, Is.EqualTo("Field 7"));
        Assert.That(result.Columns[7].ColumnName, Is.EqualTo("Field 8"));
        Assert.That(result.Columns[8].ColumnName, Is.EqualTo("Field 9"));
        Assert.That(result.Columns[9].ColumnName, Is.EqualTo("Field 10"));

        // Sample some of the data
        Assert.That(result.Rows[0]["Field 1"],  Is.EqualTo("Text 1,1"));
        Assert.That(result.Rows[1]["Field 2"],  Is.EqualTo("246"));
        Assert.That(result.Rows[2]["Field 3"],  Is.EqualTo("2023-08-03"));
        Assert.That(result.Rows[3]["Field 4"],  Is.EqualTo("Text 4,2"));
        Assert.That(result.Rows[4]["Field 5"],  Is.EqualTo("2280"));
        Assert.That(result.Rows[5]["Field 6"],  Is.EqualTo("2023-09-06"));
        Assert.That(result.Rows[6]["Field 7"],  Is.EqualTo("Text 7,3"));
        Assert.That(result.Rows[7]["Field 8"],  Is.EqualTo("256"));
        Assert.That(result.Rows[8]["Field 9"],  Is.EqualTo("2023-10-09"));
        Assert.That(result.Rows[9]["Field 10"], Is.EqualTo("Text 104"));

        // Sample the last row
        Assert.That(result.Rows[15]["Field 1"],  Is.EqualTo("Text 16,1"));
        Assert.That(result.Rows[15]["Field 2"],  Is.EqualTo("1968"));
        Assert.That(result.Rows[15]["Field 3"],  Is.EqualTo("2023-08-16"));
        Assert.That(result.Rows[15]["Field 4"],  Is.EqualTo("Text 16,2"));
        Assert.That(result.Rows[15]["Field 5"],  Is.EqualTo("7296"));
        Assert.That(result.Rows[15]["Field 6"],  Is.EqualTo("2023-09-16"));
        Assert.That(result.Rows[15]["Field 7"],  Is.EqualTo("Text 16,3"));
        Assert.That(result.Rows[15]["Field 8"],  Is.EqualTo("65536"));
        Assert.That(result.Rows[15]["Field 9"],  Is.EqualTo("2023-10-16"));
        Assert.That(result.Rows[15]["Field 10"], Is.EqualTo("Text 164"));

    }

    [Test]
    public void TestImport_CSV_SkipRows()
    {
        DataTable result = FileImporter.Import("../../../data/SampleData_Quotes.csv", new ImportConfig( ImportConfig.CSV ){SkipRows = 10});

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Columns.Count, Is.EqualTo(10));
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Rows.Count, Is.EqualTo(6));

        // Check the fields - from the file header row
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Columns[1].ColumnName, Is.EqualTo("Field 2"));
        Assert.That(result.Columns[2].ColumnName, Is.EqualTo("Field 3"));
        Assert.That(result.Columns[3].ColumnName, Is.EqualTo("Field 4"));
        Assert.That(result.Columns[4].ColumnName, Is.EqualTo("Field 5"));
        Assert.That(result.Columns[5].ColumnName, Is.EqualTo("Field 6"));
        Assert.That(result.Columns[6].ColumnName, Is.EqualTo("Field 7"));
        Assert.That(result.Columns[7].ColumnName, Is.EqualTo("Field 8"));
        Assert.That(result.Columns[8].ColumnName, Is.EqualTo("Field 9"));
        Assert.That(result.Columns[9].ColumnName, Is.EqualTo("Field 10"));

        // Sample the last row
        Assert.That(result.Rows[5]["Field 1"],  Is.EqualTo("Text 16,1"));
        Assert.That(result.Rows[5]["Field 2"],  Is.EqualTo("1968"));
        Assert.That(result.Rows[5]["Field 3"],  Is.EqualTo("2023-08-16"));
        Assert.That(result.Rows[5]["Field 4"],  Is.EqualTo("Text 16,2"));
        Assert.That(result.Rows[5]["Field 5"],  Is.EqualTo("7296"));
        Assert.That(result.Rows[5]["Field 6"],  Is.EqualTo("2023-09-16"));
        Assert.That(result.Rows[5]["Field 7"],  Is.EqualTo("Text 16,3"));
        Assert.That(result.Rows[5]["Field 8"],  Is.EqualTo("65536"));
        Assert.That(result.Rows[5]["Field 9"],  Is.EqualTo("2023-10-16"));
        Assert.That(result.Rows[5]["Field 10"], Is.EqualTo("Text 164"));
    }

    [Test]
    public void TestImport_TAB()
    {
        DataTable result = FileImporter.Import("../../../data/SampleData.tab", ImportConfig.TAB);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Columns.Count, Is.EqualTo(10));
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Rows.Count, Is.EqualTo(16));

        // Check the fields - from the file header row
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Columns[1].ColumnName, Is.EqualTo("Field 2"));
        Assert.That(result.Columns[2].ColumnName, Is.EqualTo("Field 3"));
        Assert.That(result.Columns[3].ColumnName, Is.EqualTo("Field 4"));
        Assert.That(result.Columns[4].ColumnName, Is.EqualTo("Field 5"));
        Assert.That(result.Columns[5].ColumnName, Is.EqualTo("Field 6"));
        Assert.That(result.Columns[6].ColumnName, Is.EqualTo("Field 7"));
        Assert.That(result.Columns[7].ColumnName, Is.EqualTo("Field 8"));
        Assert.That(result.Columns[8].ColumnName, Is.EqualTo("Field 9"));
        Assert.That(result.Columns[9].ColumnName, Is.EqualTo("Field 10"));

        // Sample some of the data
        Assert.That(result.Rows[0]["Field 1"],  Is.EqualTo("Text 11"));
        Assert.That(result.Rows[1]["Field 2"],  Is.EqualTo("246"));
        Assert.That(result.Rows[2]["Field 3"],  Is.EqualTo("2023-08-03"));
        Assert.That(result.Rows[3]["Field 4"],  Is.EqualTo("Text 42"));
        Assert.That(result.Rows[4]["Field 5"],  Is.EqualTo("2280"));
        Assert.That(result.Rows[5]["Field 6"],  Is.EqualTo("2023-09-06"));
        Assert.That(result.Rows[6]["Field 7"],  Is.EqualTo("Text 73"));
        Assert.That(result.Rows[7]["Field 8"],  Is.EqualTo("256"));
        Assert.That(result.Rows[8]["Field 9"],  Is.EqualTo("2023-10-09"));
        Assert.That(result.Rows[9]["Field 10"], Is.EqualTo("Text 104"));

        // Sample the last row
        Assert.That(result.Rows[15]["Field 1"],  Is.EqualTo("Text 161"));
        Assert.That(result.Rows[15]["Field 2"],  Is.EqualTo("1968"));
        Assert.That(result.Rows[15]["Field 3"],  Is.EqualTo("2023-08-16"));
        Assert.That(result.Rows[15]["Field 4"],  Is.EqualTo("Text 162"));
        Assert.That(result.Rows[15]["Field 5"],  Is.EqualTo("7296"));
        Assert.That(result.Rows[15]["Field 6"],  Is.EqualTo("2023-09-16"));
        Assert.That(result.Rows[15]["Field 7"],  Is.EqualTo("Text 163"));
        Assert.That(result.Rows[15]["Field 8"],  Is.EqualTo("65536"));
        Assert.That(result.Rows[15]["Field 9"],  Is.EqualTo("2023-10-16"));
        Assert.That(result.Rows[15]["Field 10"], Is.EqualTo("Text 164"));

    }

    [Test]
    public void TestImport_TAB_Quotes()
    {
        DataTable result = FileImporter.Import("../../../data/SampleData_Quotes.tab", new ImportConfig(ImportConfig.TAB) { QuotedData = true });

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Columns.Count, Is.EqualTo(10));
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Rows.Count, Is.EqualTo(16));

        // Check the fields - from the file header row
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Columns[1].ColumnName, Is.EqualTo("Field 2"));
        Assert.That(result.Columns[2].ColumnName, Is.EqualTo("Field 3"));
        Assert.That(result.Columns[3].ColumnName, Is.EqualTo("Field 4"));
        Assert.That(result.Columns[4].ColumnName, Is.EqualTo("Field 5"));
        Assert.That(result.Columns[5].ColumnName, Is.EqualTo("Field 6"));
        Assert.That(result.Columns[6].ColumnName, Is.EqualTo("Field 7"));
        Assert.That(result.Columns[7].ColumnName, Is.EqualTo("Field 8"));
        Assert.That(result.Columns[8].ColumnName, Is.EqualTo("Field 9"));
        Assert.That(result.Columns[9].ColumnName, Is.EqualTo("Field 10"));

        // Sample some of the data
        Assert.That(result.Rows[0]["Field 1"],  Is.EqualTo("Text 1,1"));
        Assert.That(result.Rows[1]["Field 2"],  Is.EqualTo("246"));
        Assert.That(result.Rows[2]["Field 3"],  Is.EqualTo("2023-08-03"));
        Assert.That(result.Rows[3]["Field 4"],  Is.EqualTo("Text 4,2"));
        Assert.That(result.Rows[4]["Field 5"],  Is.EqualTo("2280"));
        Assert.That(result.Rows[5]["Field 6"],  Is.EqualTo("2023-09-06"));
        Assert.That(result.Rows[6]["Field 7"],  Is.EqualTo("Text 7,3"));
        Assert.That(result.Rows[7]["Field 8"],  Is.EqualTo("256"));
        Assert.That(result.Rows[8]["Field 9"],  Is.EqualTo("2023-10-09"));
        Assert.That(result.Rows[9]["Field 10"], Is.EqualTo("Text 104"));

        // Sample the last row
        Assert.That(result.Rows[15]["Field 1"],  Is.EqualTo("Text 16,1"));
        Assert.That(result.Rows[15]["Field 2"],  Is.EqualTo("1968"));
        Assert.That(result.Rows[15]["Field 3"],  Is.EqualTo("2023-08-16"));
        Assert.That(result.Rows[15]["Field 4"],  Is.EqualTo("Text 16,2"));
        Assert.That(result.Rows[15]["Field 5"],  Is.EqualTo("7296"));
        Assert.That(result.Rows[15]["Field 6"],  Is.EqualTo("2023-09-16"));
        Assert.That(result.Rows[15]["Field 7"],  Is.EqualTo("Text 16,3"));
        Assert.That(result.Rows[15]["Field 8"],  Is.EqualTo("65536"));
        Assert.That(result.Rows[15]["Field 9"],  Is.EqualTo("2023-10-16"));
        Assert.That(result.Rows[15]["Field 10"], Is.EqualTo("Text 164"));

    }

    [Test]
    public void TestImport_Custom()
    {
        DataTable result = FileImporter.Import("../../../data/SampleData-Custom.dat", new ImportConfig(ImportConfig.USERDEFINED) { Name = "Tilde", Delimiters = new List<string> { new("~") } });

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Columns.Count, Is.EqualTo(10));
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Rows.Count, Is.EqualTo(16));

        // Check the fields - from the file header row
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Columns[1].ColumnName, Is.EqualTo("Field 2"));
        Assert.That(result.Columns[2].ColumnName, Is.EqualTo("Field 3"));
        Assert.That(result.Columns[3].ColumnName, Is.EqualTo("Field 4"));
        Assert.That(result.Columns[4].ColumnName, Is.EqualTo("Field 5"));
        Assert.That(result.Columns[5].ColumnName, Is.EqualTo("Field 6"));
        Assert.That(result.Columns[6].ColumnName, Is.EqualTo("Field 7"));
        Assert.That(result.Columns[7].ColumnName, Is.EqualTo("Field 8"));
        Assert.That(result.Columns[8].ColumnName, Is.EqualTo("Field 9"));
        Assert.That(result.Columns[9].ColumnName, Is.EqualTo("Field 10"));

        // Sample some of the data
        Assert.That(result.Rows[0]["Field 1"],  Is.EqualTo("Text 11"));
        Assert.That(result.Rows[1]["Field 2"],  Is.EqualTo("246"));
        Assert.That(result.Rows[2]["Field 3"],  Is.EqualTo("2023-08-03"));
        Assert.That(result.Rows[3]["Field 4"],  Is.EqualTo("Text 42"));
        Assert.That(result.Rows[4]["Field 5"],  Is.EqualTo("2280"));
        Assert.That(result.Rows[5]["Field 6"],  Is.EqualTo("2023-09-06"));
        Assert.That(result.Rows[6]["Field 7"],  Is.EqualTo("Text 73"));
        Assert.That(result.Rows[7]["Field 8"],  Is.EqualTo("256"));
        Assert.That(result.Rows[8]["Field 9"],  Is.EqualTo("2023-10-09"));
        Assert.That(result.Rows[9]["Field 10"], Is.EqualTo("Text 104"));

        // Sample the last row
        Assert.That(result.Rows[15]["Field 1"],  Is.EqualTo("Text 161"));
        Assert.That(result.Rows[15]["Field 2"],  Is.EqualTo("1968"));
        Assert.That(result.Rows[15]["Field 3"],  Is.EqualTo("2023-08-16"));
        Assert.That(result.Rows[15]["Field 4"],  Is.EqualTo("Text 162"));
        Assert.That(result.Rows[15]["Field 5"],  Is.EqualTo("7296"));
        Assert.That(result.Rows[15]["Field 6"],  Is.EqualTo("2023-09-16"));
        Assert.That(result.Rows[15]["Field 7"],  Is.EqualTo("Text 163"));
        Assert.That(result.Rows[15]["Field 8"],  Is.EqualTo("65536"));
        Assert.That(result.Rows[15]["Field 9"],  Is.EqualTo("2023-10-16"));
        Assert.That(result.Rows[15]["Field 10"], Is.EqualTo("Text 164"));

    }

    [Test]
    public void TestPeek_Default()
    {
        DataTable result = FileImporter.Peek("../../../data/SampleData.csv");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Columns.Count, Is.EqualTo(10));
        Assert.That(result.Rows.Count, Is.EqualTo(0));
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Columns[1].ColumnName, Is.EqualTo("Field 2"));
        Assert.That(result.Columns[2].ColumnName, Is.EqualTo("Field 3"));
        Assert.That(result.Columns[3].ColumnName, Is.EqualTo("Field 4"));
        Assert.That(result.Columns[4].ColumnName, Is.EqualTo("Field 5"));
        Assert.That(result.Columns[5].ColumnName, Is.EqualTo("Field 6"));
        Assert.That(result.Columns[6].ColumnName, Is.EqualTo("Field 7"));
        Assert.That(result.Columns[7].ColumnName, Is.EqualTo("Field 8"));
        Assert.That(result.Columns[8].ColumnName, Is.EqualTo("Field 9"));
        Assert.That(result.Columns[9].ColumnName, Is.EqualTo("Field 10"));
    }

    [Test]
    public void TestPeek_CSV()
    {
        DataTable result = FileImporter.Peek("../../../data/SampleData.csv", ImportConfig.CSV);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Columns.Count, Is.EqualTo(10));
        Assert.That(result.Rows.Count, Is.EqualTo(0));
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Columns[1].ColumnName, Is.EqualTo("Field 2"));
        Assert.That(result.Columns[2].ColumnName, Is.EqualTo("Field 3"));
        Assert.That(result.Columns[3].ColumnName, Is.EqualTo("Field 4"));
        Assert.That(result.Columns[4].ColumnName, Is.EqualTo("Field 5"));
        Assert.That(result.Columns[5].ColumnName, Is.EqualTo("Field 6"));
        Assert.That(result.Columns[6].ColumnName, Is.EqualTo("Field 7"));
        Assert.That(result.Columns[7].ColumnName, Is.EqualTo("Field 8"));
        Assert.That(result.Columns[8].ColumnName, Is.EqualTo("Field 9"));
        Assert.That(result.Columns[9].ColumnName, Is.EqualTo("Field 10"));
    }

    [Test]
    public void TestPeek_UserDefined()
    {
        DataTable result = FileImporter.Peek("../../../data/SampleData-Custom.dat", new ImportConfig(ImportConfig.USERDEFINED) { Name = "Tilde", Delimiters = new List<string> { new("~") } });

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Columns.Count, Is.EqualTo(10));
        Assert.That(result.Rows.Count, Is.EqualTo(0));
        Assert.That(result.Columns[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result.Columns[1].ColumnName, Is.EqualTo("Field 2"));
        Assert.That(result.Columns[2].ColumnName, Is.EqualTo("Field 3"));
        Assert.That(result.Columns[3].ColumnName, Is.EqualTo("Field 4"));
        Assert.That(result.Columns[4].ColumnName, Is.EqualTo("Field 5"));
        Assert.That(result.Columns[5].ColumnName, Is.EqualTo("Field 6"));
        Assert.That(result.Columns[6].ColumnName, Is.EqualTo("Field 7"));
        Assert.That(result.Columns[7].ColumnName, Is.EqualTo("Field 8"));
        Assert.That(result.Columns[8].ColumnName, Is.EqualTo("Field 9"));
        Assert.That(result.Columns[9].ColumnName, Is.EqualTo("Field 10"));
    }
}