using System.Data;

namespace TechGnome.FileImport.FileImportLibraryTest;
public class CommentTest
{

    private static string TESTFILE = "./Resources/data/SampleData";

    [Test]
    public void TestComments_CSV_WhackWhack()
    {
        DataTable result = FileImporter.Import(TESTFILE + "_Comments.csv", new ImportConfig(ImportConfig.CSV) { CommentTokens = new List<string>{"//"} });

        Assert.That(result.Rows.Count, Is.EqualTo(4));
        
    }

    [Test]
    public void TestComments_CSV_WhackWhack_CommentError()
    {
        DataTable result = FileImporter.Import(TESTFILE + "_Comments.csv", new ImportConfig(ImportConfig.CSV));

        Assert.That(result.Rows.Count, Is.EqualTo(5));
        
    }

    [Test]
    public void TestComments_FixedWidth()
    {
        DataTable result = FileImporter.Import(TESTFILE + "_Comments.fwt", new ImportConfig(ImportConfig.FIXED_WIDTH) { CommentTokens = new List<string>{";;"}, FieldWidths = new int[] { 7, 7, 7} });

        Assert.That(result.Rows.Count, Is.EqualTo(9));
        
    }

    [Test]
    public void TestComments_FixedWidth_CommentError()
    {
        DataTable result = FileImporter.Import(TESTFILE + "_Comments.fwt", new ImportConfig(ImportConfig.FIXED_WIDTH) { FieldWidths = new int[] { 7, 7, 7} });

        Assert.That(result.Rows.Count, Is.EqualTo(11));
        
    }
}
