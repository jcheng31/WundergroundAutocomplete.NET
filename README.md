WundergroundAutocomplete.NET
============================

A portable class library for the Weather Underground (Wunderground)
[Autocomplete API](http://api.wunderground.com/weather/api/d/docs?d=autocomplete-api). Supports .NET 4.5, Silverlight 4, and WP7.5+

This API allows searching for cities or hurricanes using partial queries. The
results provide unique identifiers which can then be used with other 
Wunderground APIs. 

# Getting Started

Install the package through [NuGet](https://www.nuget.org):
`Install-Package WundergroundAutocomplete`

## Creating and Executing Requests

By default, queries are for cities alone:

```C#
using WundergroundAutocomplete;

...

var request = new SearchRequest("Los Angeles");
SearchResponse response = await request.ExecuteAsync();

if (response.IsSuccessful) 
{
	// response.Results holds a list of all returned results.
}

```

You can also specify that you're interested in hurricanes only, or both cities
and hurricanes:

```C#

var hurricaneRequest = new SearchRequest("Katrina", ResultFilter.HurricanesOnly);
var bothIncluded = new SearchRequest("Katrin", ResultFilter.CitiesAndHurricanes);
```

Results can also be further restricted to a particular country. Note that
Wunderground [does not use ISO country codes](http://www.wunderground.com/weather/api/d/docs?d=resources/country-to-iso-matching):

```C#

var usOnly = new SearchRequest("Amsterdam", ResultFilter.CitiesOnly, "US");
```

## Handling Results

There are two types of results that the service returns: `City` or `Hurricane`.

Both of these have `Name` and `Link` properties, the latter of which acts as an
identifier that can be used to get information about the city/huricane from
other APIs.

Both `City` and `Hurricane` retain all information that the API returns, though
these are exposed through (hopefully) more-readable properties. For example, a
cities' `tzs` field in the API is exposed as `.ShortTimeZone`.

XML comments have been included for each property, describing the field they map
to. 

# Dependencies
The 
[Microsoft HTTP Client Libraries](https://www.nuget.org/packages/Microsoft.Net.Http/)
and [Microsoft Async](https://www.nuget.org/packages/Microsoft.Bcl.Async/)
are used to support `HttpClient` and the `await` and `async` keywords in 
Silverlight 4 and Windows Phone Silverlight 7.5.