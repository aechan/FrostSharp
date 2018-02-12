# FrostSharp
<img src="https://frost.po.et/3737874e2ab4a890144e13c7c7aeb2ff.svg" width=100px/> <img src="https://camo.githubusercontent.com/0617f4657fef12e8d16db45b8d73def73144b09f/68747470733a2f2f646576656c6f7065722e6665646f726170726f6a6563742e6f72672f7374617469632f6c6f676f2f6373686172702e706e67" width=100px/>

## .NET Core library wrapping po.et's Frost API.

## Usage

Examples:
```csharp
// Your api key
string APIKey = "your api key here";

// Create a Frost configuration with all default values (should work for most people)
var Config = new Configuration();

// do we want all HTTP request logging to stdout (mostly useful for testing)
bool logging = false;

// Create the client we will use.
var client = new Frost(APIKey, Config, logging);

// Create a work (Work name, date created, date published, author name, work content)
WorkAttributes myWork = new WorkAttribute("Work Name", DateTime.UtcNow, DateTime.UtcNow, "Alec Chan", "This is the content of the work");

// Post the work onto the po.et network (runs asynchronously)
string myWorkId = await client.CreateWork(myWork);

// Look up a work by work ID
WorkAttributes thisIsTheSameWorkWeJustPosted = await client.GetWork(myWorkId);

// Get all the works that your API key has posted
List<WorkAttributes> listOfWorks = await client.GetAllWorks();
```

## Development

Building library:
`cd FrostSharp && dotnet build`

Running tests:
`cd FrostSharp.Tests && dotnet test`

To contribute:

- Clone this repo
- Create an integration branch (e.g. <yourname>-integration)
- Make changes
- Submit a pull request to pull changes into master