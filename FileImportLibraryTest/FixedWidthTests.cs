using System.Data;

namespace TechGnome.FileImport.FileImportLibraryTest;

public class FixedWidthTest
{

    private static string TESTFILE = "./Resources/data/SampleData";
    private static string CONFIGFILENAME = "./Resources/config/Config_FixedWidth";
    private int[] FIELD_WIDTHS = new int[] { 10, 7, 10, 10, 7, 10, 9, 15, 10, -1, };
    private ImportConfig fixedWidthConfig;

    [SetUp]
    public void Setup()
    {
        fixedWidthConfig = new ImportConfig(ImportConfig.FIXED_WIDTH) { FieldWidths = FIELD_WIDTHS };
    }

    [Test]
    public void TestImport_FixedWidth()
    {
        DataTable result = FileImporter.Import(TESTFILE + ".fwt", fixedWidthConfig);

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
    public void TestPeek_FixedWidth()
    {
        List<DataColumn> result = FileImporter.Peek(TESTFILE + ".fwt", fixedWidthConfig);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(10));
        Assert.That(result[0].ColumnName, Is.EqualTo("Field 1"));
        Assert.That(result[1].ColumnName, Is.EqualTo("Field 2"));
        Assert.That(result[2].ColumnName, Is.EqualTo("Field 3"));
        Assert.That(result[3].ColumnName, Is.EqualTo("Field 4"));
        Assert.That(result[4].ColumnName, Is.EqualTo("Field 5"));
        Assert.That(result[5].ColumnName, Is.EqualTo("Field 6"));
        Assert.That(result[6].ColumnName, Is.EqualTo("Field 7"));
        Assert.That(result[7].ColumnName, Is.EqualTo("Field 8"));
        Assert.That(result[8].ColumnName, Is.EqualTo("Field 9"));
        Assert.That(result[9].ColumnName, Is.EqualTo("Field 10"));
    }

    [Test]
    public void TestConfigSave_FixedWidth_Json()
    {
        var config = new ImportConfig(ImportConfig.FIXED_WIDTH) { FieldWidths = FIELD_WIDTHS };
        ImportConfig.Save("./fixedWidthConfig.json", config);
    }

    [Test]
    public void TestConfigSave_FixedWidth_Xml()
    {
        var config = new ImportConfig(ImportConfig.FIXED_WIDTH) { FieldWidths = FIELD_WIDTHS };
        ImportConfig.Save("./fixedWidthConfig.xml", config);
    }

    [Test]
    public void TestConfigSave_FixedWidth_Yaml()
    {
        var config = new ImportConfig(ImportConfig.FIXED_WIDTH) { FieldWidths = FIELD_WIDTHS };
        ImportConfig.Save("./fixedWidthConfig.yaml", config);
    }

    [Test]
    public void TestConfigLoad_FixedWidth_Json()
    {
        var config = ImportConfig.Load( CONFIGFILENAME + ".json");
        Assert.That(config, Is.Not.Null);
        Assert.That(config.Name, Is.EqualTo(fixedWidthConfig.Name));
        Assert.That(config.Delimiters, Is.Null);
        Assert.That(config.HasHeader, Is.EqualTo(fixedWidthConfig.HasHeader));
        Assert.That(config.QuotedData, Is.EqualTo(fixedWidthConfig.QuotedData));
        Assert.That(config.SkipRows, Is.EqualTo(fixedWidthConfig.SkipRows));
        Assert.That(config.FieldWidths, Is.Not.Null);
        Assert.That(fixedWidthConfig.FieldWidths, Is.Not.Null);
        Assert.That(config.FieldWidths, Has.Length.EqualTo(fixedWidthConfig.FieldWidths.Length));
    }

    [Test]
    public void TestConfigLoad_FixedWidth_Xml()
    {
        var config = ImportConfig.Load( CONFIGFILENAME + ".xml");
        Assert.That(config, Is.Not.Null);
        Assert.That(config.Name, Is.EqualTo(fixedWidthConfig.Name));
        Assert.That(config.Delimiters, Is.Null);
        Assert.That(config.HasHeader, Is.EqualTo(fixedWidthConfig.HasHeader));
        Assert.That(config.QuotedData, Is.EqualTo(fixedWidthConfig.QuotedData));
        Assert.That(config.SkipRows, Is.EqualTo(fixedWidthConfig.SkipRows));
        Assert.That(config.FieldWidths, Is.Not.Null);
        Assert.That(fixedWidthConfig.FieldWidths, Is.Not.Null);
        Assert.That(config.FieldWidths, Has.Length.EqualTo(fixedWidthConfig.FieldWidths.Length));
    }

    [Test]
    public void TestConfigLoad_FixedWidth_Yaml()
    {
        var config = ImportConfig.Load( CONFIGFILENAME + ".yaml");
        Assert.That(config, Is.Not.Null);
        Assert.That(config.Name, Is.EqualTo(fixedWidthConfig.Name));
        Assert.That(config.Delimiters, Is.Null);
        Assert.That(config.HasHeader, Is.EqualTo(fixedWidthConfig.HasHeader));
        Assert.That(config.QuotedData, Is.EqualTo(fixedWidthConfig.QuotedData));
        Assert.That(config.SkipRows, Is.EqualTo(fixedWidthConfig.SkipRows));
        Assert.That(config.FieldWidths, Is.Not.Null);
        Assert.That(fixedWidthConfig.FieldWidths, Is.Not.Null);
        Assert.That(config.FieldWidths, Has.Length.EqualTo(fixedWidthConfig.FieldWidths.Length));
    }

}