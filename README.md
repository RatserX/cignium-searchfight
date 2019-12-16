# Cignium Searchfight

This a C# console application which lets users obtain information from search results, such as the total results number. Currently, as it finishes processing the results, it displays the total results number for each search query inputted and which keyword had the most results.
As of now, it retrieves data from the Bing, Google and Yahoo search engines.

# Usage

```sh
$ Cignium.Searchfight.exe search_queries
```

Example:


```sh
$ Cignium.Searchfight.exe .net java "java script"
```

# Configuration

Configurable options, such as the API Key and the request URLs, can be modified inside the ConstantHelpers.cs class.

# Resources

## Search Engines

Add aditional search engines by creating a new folder, interface and class respectively in the SearchEngine folder. Make sure to inherit the `BaseSearchEngine` class. Aditional functionality can be added if needed. Be sure to check the search engines already included in this project for reference.

# Deployment

Compile or publish the `Cignium.Searchfight` project and run the generated EXE file from the chosen deployment folder.
