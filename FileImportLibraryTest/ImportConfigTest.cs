
namespace TechGnome.FileImport.FileImportLibraryTest;
public class ImportConfigTest
{
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

    //        InvalidConfigurationException ex = Assert.Throws<InvalidConfigurationException>(
        //     () => test.StartPosition = 50);
        // Assert.That(ex.Message, Is.EqualTo("StartPosition cannot exceed the EndPosition"));

    [Test]
    public void TestConfigLoad_Json()
    {
        var config = ImportConfig.Load("./testFile.json");
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
        var config = ImportConfig.Load("./testFile.xml");
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
        var config = ImportConfig.Load("./testFile.yaml");
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
        var config = ImportConfig.Load("./testFile.yml");
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
