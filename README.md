<a name="readme-top"></a>

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
<br />
[![.NET][gh-buid-badge]][gh-build-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/techgnome/FileImport">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">FileImport</h3>

  <p align="center">
    A simple to use file import library for us with .NET.
    <br />
    <a href="https://github.com/techgnome/FileImport"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    ·
    <a href="https://github.com/techgnome/FileImport/issues">Report Bug</a>
    ·
    <a href="https://github.com/techgnome/FileImport/issues">Request Feature</a>
    ·
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About FileImport

FileImport is designed to be a simple and easy way to import text files. Built as a wrapper around the TextFieldParser, it is intended to deal with the boilerplate, mundane code of creating a file reader and pulling in the data. With a single line of code, it is possible to fill a datatable with simple data from a CSV file. Nedd to import a TAB delimited file? Add a simple parameter andd you're done. Got a fixed width file? Another quick change, and you're back to doing what you do best - writing code.

The design behind the FileImport library is intended to be sa simple or as complex as you want it to be. It can, by default, read in aa simple basic CSV file just by using one line using the built-in default settings.

The long term goal is to develop something that can read in a simple file, or if needed, allow for rules of validation and translation.

### Methods
_Import(string fileName)_ - Imports a file using the default settings. Returns a DataTable with the imported data in it.

_Import(string fileName,ImportConfig config)_ - Imports a file using the specified import configurations. Returns a DataTable with the imported data in it.

_Peek(string fileName)_ - Inspects the file using the default config settings and returns a `List<DataColumn>`. Does not actually import or inspect the data, but simply returns a List<> with the found colums based on the configuration.

_Peek(string fileName,ImportConfig config)_ - Imports the file using the specified import config settings and returns a `List<DataColumn>`. Does not actually import or inspect the data, but simply returns a List<> with the found colums based on the configuration.

### Import Configurations

The FileImport librsry has six pre-defined ImportConfig settings. Each one can be used as-is, or as a template in creating custom config settings.

Each configuration has the following properties:
* Name - string - Name of the configuration 
* Delimiter - string[] - Array of delimiters to use
* HasHeader - bool - If true, treat the first row in the file as a header
* QuotedData - bool - Flag indicating if the file has quoted data for field vlaues
* SkipRows - int - Determines if rows should be skipped when reading the file. This value does not include the header row.
* FieldType - FieldType - Determines if the file being imported is Delimited, or FkedWidth.
* UseHeaderAsFields - bool - when true, uses the values found in the header row for the field names
* CommentToken - string[] - Array of delimiters markong comment lines in the file **
* FieldWidth - int[] - Array of integers indicating the width of each field when used with fixed-width format files
* TrimWhiteSpacce - bool - Flag indicating if white space should be trimmed from field values.
* Fields - string[] - Array of strings to use as the field names **

** NOTE: Not all of the configuration items listed have been completely implemented. The properties are available, but may not be in use yet.

The following chart shows all of the current preset configurations and their settings.

Confg | Name | Delimiter | HasHeader | QuotedData | SkipRows | FieldType | UseHeaderAsFields| CommentToken | FieldWidths | TrimWhitespace  | Fields
:--- | :--- | :---: | :---: | :---: | :---: | :--- | :---: | :---: | :--- | :---: | :--- 
Default | Default | `,` | true | false | 0 | Delimited | true | null | null | false | null
CSV | CSV | `,` | true | false | 0 | Delimited | true | null | null | false | null
CSV_EXTENDED | CSV Extended | `,` | true | true | 0 | Delimited | true | null | null | false | null
TAB | Tab | `\t` | true | false | 0 | Delimited | true | null | null | false | null
PIPE | Pipe | `\|` | true | false | 0 | Delimited | true | null | null | false | null
SEMICOLON | Semicolon | `;` | true | false | 0 | Delimited | true | null | null | false | null
USERDEFINED | User | `List<string>` | true | false | 0 | Delimited | true | null | null | false | null
FIXED_WIDTH | Fixed Width | `{empty}` | true | false | 0 | FixedWidth | true | null | `int?[]` | true | null


#### Custom
To create a custom configuration, override the needed proprties in the constructor.

Exmples:
To use the default config and skip the first 5 rows:

`ImportConfig customConfig = new ImportConfig() { skipRows = 5 };`

Skip the first 5 rows, no header, in a TAB-delimited file:

`ImportConfig customConfig = new ImportConfig(ImportConfig.TAB) { HasHeader = falsse, SkipRows = 5 };`

Use the tilde (~) as a custom delimiter:
`ImportConfig customConfig = new ImportConfig(ImportConfig.USERDEFINED) {Delimiters = new string() {"~"} }`

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

The FileImport Library was built using .Net 6.0, and is compatible with Net 7.0. At this time it has not been tested or used with earlier versions of .Net Core, or .Net Framework.

NUnit is used for unit testing during development. The entire test suite is included as part of the solution.

Development was done with VSCode on a Linux system.

* [![C# .Ney 6.0][CSharpNet60]][CSharpNet60-url]
* [![C# .Ney 7.0][CSharpNet70]][CSharpNet70-url]
* [![Developed using VSCode][VSCode]][VSCode-url]
* [![Packages from NUget][Nuget]][NUget-url]
* [![NUget package YamlDotNet][YamlDotNet]][YamlDotNet-url]
* [![Tested using NUnit Testing][NUnit]][NUnit-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

While at this time there isn't a NUget Package available for FileImport, one is planned. In the meantime, clone/fork the repo and build the solution.

### Prerequisites

The only prerequisite for FileImport is .NET. That's it. Ok, and Git. Or something that can pull a GitHub repo. Until I can get a NUget Package together.

### Installation

1. Fork the repo in GitHub
2. Clone the repo
   ```sh
   git clone https://github.com/your_username_/LetterImport.git
   ```
3. Change to the new repo directory
   ```sh
   cd FileImport
   ```
4. Build the solution
   ```sh
   dotnet build
   ```
5. Add a reference to the dll in your project
6. Rule the world!

To run the test project use:
```sh
dotnet test
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Import the FileImportLibrary namesapace at the top of your code file:
```C#
using TechGnome.FileImport.FileImportLibrary;
```

Or by adding a global import in your `Usings.cs` file:
```C#
global using TechGnome.FileImport.FileImportLibrary;
```

After importing the namespace, using the lobrary is simple.

### Examples

Default import, a simple CSV file, with a header, and no quoted data:
```C#
DataTable result = FileImporter.Import("SampleData.txt");
```

CSV import with a header and quoted data:
```C#
DataTable result = FileImporter.Import("SampleData.txt", ImportConfig.CSV);
```

TAB import, with header, no quoted data:
```C#
DataTable result = FileImporter.Import("SampleData.txt", ImportConfig.TAB);
```

TAB import, with header, quoted data:
```C#
DataTable result = FileImporter.Import("SampleData.txt", new ImportConfig(ImportConfig.TAB) { QuotedData = true });
```

Custom import, user-defined delimiter, header, no quoted data
```C#
DataTable result = FileImporter.Import("SampleData.txt", new ImportConfig(ImportConfig.USERDEFINED) { Name = "Tilde", Delimiters = new String[] { "~" } });
```

_For more examples, please refer to the [FileimportLibraryTest](https://github.com/TechGnome/FileImport) project._

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ROADMAP -->
## Roadmap

- [x] CSV support
  - [x] ~~Header row~~
  - [x] ~~Header used for field names~~
  - [x] ~~Data is unquoted~~
- [x] ~~Additional CSV support~~
  - [x] ~~Enable quoted data~~
- [x] ~~Ability to "peek" at a file and see what columns are present~~
  - [x] ~~CSV files~~
  - [x] ~~Tab~~
  - [x] ~~Pipe~~
  - [x] ~~Semicolon~~
  - [x] ~~User-defined~~
  - [x] ~~Fixed-width~~
- [x] ~~Additional delimiter support (in progresss)~~
  - [x] ~~Tab~~
  - [x] ~~Pipe~~
  - [x] ~~Semicolon~~
  - [x] ~~User-defined~~
- [x] ~~Add support for fixed-width ~~
  - [x] ~~user-defined column widths~~
- [x] ~~Ability to store configurations in a file~~
  - [x] ~~JSON format~~
  - [x] ~~XML format~~
  - [x] ~~YAML format~~
- [x] ~~Ability to reaad and use configuration files~~
  - [x] ~~JSON format~~
  - [x] ~~XML format~~
  - [x] ~~YAML format~~
- [x] ~~Ability to skip rows at the beginning of a file~~
- [x] ~~Support comments in the imported file~~
- [ ] Support multiple format layouts in a single file
- [ ] Add ability to perform field validation
- [ ] Allow field data types
- [ ] Allow field expressions
- [ ] Allow field transformaton/substitutions
- [ ] Plugin system to allow greater control
- [ ] Create a NUget package
- [ ] Any thing else I or someone else caan think of


See the [open issues](https://github.com/techgnome/FileImport/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See [LICENSE](https://github.com/TechGnome/FileImport/blob/main/LICENSE) for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Chris Anderson - [@TechGnome42](https://twitter.com/TechGnome42) - topher.anderson42@gmail.com

Project Link: [https://github.com/techgnome/FileImport](https://github.com/techgnome/FileImport)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [VS Code]([VSCode-url])
* [.NET]([CSharpNet60-url])
* [NUget]({NUget-url})
* [Unit]([Unit0url])
* [YamlDotNet]([YamlDotNet-url])
* [Choose an Open Source License](https://choosealicense.com)
* [Img Shields](https://shields.io)
* [GitHub Pages](https://pages.github.com)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/techgnome/FileImport.svg?style=for-the-badge
[contributors-url]: https://github.com/techgnome/FileImport/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/techgnome/FileImport.svg?style=for-the-badge
[forks-url]: https://github.com/techgnome/FileImport/network/members
[stars-shield]: https://img.shields.io/github/stars/techgnome/FileImport.svg?style=for-the-badge
[stars-url]: https://github.com/techgnome/FileImport/stargazers
[issues-shield]: https://img.shields.io/github/issues/techgnome/FileImport.svg?style=for-the-badge
[issues-url]: https://github.com/techgnome/FileImport/issues
[license-shield]: https://img.shields.io/github/license/techgnome/FileImport.svg?style=for-the-badge
[license-url]: https://github.com/techgnome/FileImport/blob/master/LICENSE.txt

[gh-buid-badge]: https://github.com/TechGnome/FileImport/actions/workflows/dotnet.yml/badge.svg?branch=main
[gh-build-url]: https://github.com/TechGnome/FileImport/actions/workflows/dotnet.yml

[CSharpNet60]: https://img.shields.io/badge/C%23-.Net_6.0-blue?logo=csharp
[CSharpNet70]: https://img.shields.io/badge/C%23-.Net_7.0-blue?logo=csharp
[CSharpNet60-url]: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
[CSharpNet70-url]: https://dotnet.microsoft.com/en-us/download/dotnet/7.0
[VSCode]: https://img.shields.io/badge/VS_Code-007ACC?logo=visualstudiocode
[VSCode-url]: https://code.visualstudio.com/
[NUget]: https://img.shields.io/badge/-NUget-004880?logo=nuget
[NUget-url]: https://www.nuget.org/
[NUnit]: https://img.shields.io/badge/Tested_by-NUnit-green?logo=nuget
[NUnit-url]: https://docs.nunit.org/index.html

[YamlDotNet]: https://img.shields.io/badge/-YamlDotNet-004880?logo=yaml
[YamlDotNet-url]: https://github.com/aaubry/YamlDotNet
