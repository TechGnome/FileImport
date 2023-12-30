
namespace TechGnome.FileImport.FileImportLibraryTest;
public class ImportConfigTest
{

    private static string CONFIGFILENAME = "./Resources/config/Config_Default";

    [Test]
    public void TestConfigSave_Json()
    {
        var config = new ImportConfig();
        ImportConfig.Save("./testFile.json", config);
    }

    [Test]
    public void TestConfigSave_Xml()
    {
        var config = new ImportConfig();
        ImportConfig.Save("./testFile.xml", config);
    }

    [Test]
    public void TestConfigSave_Yaml()
    {
        var config = new ImportConfig();
        ImportConfig.Save("./testFile.yaml", config);
    }

    [Test]
    public void TestConfigSave_Yml()
    {
        var config = new ImportConfig();
        ImportConfig.Save("./testFile.yml", config);
    }

    [Test]
    public void TestConfigLoad_Json()
    {
        var config = ImportConfig.Load(CONFIGFILENAME + ".json");
        var baseline = new ImportConfig();
        Assert.That(config, Is.Not.Null);
        Assert.That(config.Name, Is.EqualTo(baseline.Name));
        Assert.That(config.Delimiters, Is.Not.Null);
        Assert.That(baseline.Delimiters, Is.Not.Null);
        Assert.That(config.Delimiters[0], Is.EqualTo(baseline.Delimiters[0]));
        Assert.That(config.HasHeader, Is.EqualTo(baseline.HasHeader));
        Assert.That(config.QuotedData, Is.EqualTo(baseline.QuotedData));
        Assert.That(config.SkipRows, Is.EqualTo(baseline.SkipRows));
    }

    [Test]
    public void TestConfigLoad_Xml()
    {
        var config = ImportConfig.Load(CONFIGFILENAME + ".xml");
        var baseline = new ImportConfig();
        Assert.That(config, Is.Not.Null);
        Assert.That(config.Name, Is.EqualTo(baseline.Name));
        Assert.That(config.Delimiters, Is.Not.Null);
        Assert.That(baseline.Delimiters, Is.Not.Null);
        Assert.That(config.Delimiters[0], Is.EqualTo(baseline.Delimiters[0]));
        Assert.That(config.HasHeader, Is.EqualTo(baseline.HasHeader));
        Assert.That(config.QuotedData, Is.EqualTo(baseline.QuotedData));
        Assert.That(config.SkipRows, Is.EqualTo(baseline.SkipRows));
    }

    [Test]
    public void TestConfigLoad_Yaml()
    {
        var config = ImportConfig.Load(CONFIGFILENAME + ".yaml");
        var baseline = new ImportConfig();
        Assert.That(config, Is.Not.Null);
        Assert.That(config.Name, Is.EqualTo(baseline.Name));
        Assert.That(config.Delimiters, Is.Not.Null);
        Assert.That(baseline.Delimiters, Is.Not.Null);
        Assert.That(config.Delimiters[0], Is.EqualTo(baseline.Delimiters[0]));
        Assert.That(config.HasHeader, Is.EqualTo(baseline.HasHeader));
        Assert.That(config.QuotedData, Is.EqualTo(baseline.QuotedData));
        Assert.That(config.SkipRows, Is.EqualTo(baseline.SkipRows));
    }

    [Test]
    public void TestConfigLoad_Yml()
    {
        var config = ImportConfig.Load(CONFIGFILENAME + ".yml");
        var baseline = new ImportConfig();
        Assert.That(config, Is.Not.Null);
        Assert.That(config.Name, Is.EqualTo(baseline.Name));
        Assert.That(config.Delimiters, Is.Not.Null);
        Assert.That(baseline.Delimiters, Is.Not.Null);
        Assert.That(config.Delimiters[0], Is.EqualTo(baseline.Delimiters[0]));
        Assert.That(config.HasHeader, Is.EqualTo(baseline.HasHeader));
        Assert.That(config.QuotedData, Is.EqualTo(baseline.QuotedData));
        Assert.That(config.SkipRows, Is.EqualTo(baseline.SkipRows));
    }

}
