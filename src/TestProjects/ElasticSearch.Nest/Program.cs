using Courseloop.Models.Unit;
using Elasticsearch.Net;
using Nest;

var connectionString = "http://macquarie-prod-handbook.factor5-curriculum.com.au/api/es/search";


var drq = new DateRangeQuery {
    Field = "modDate",
    GreaterThanOrEqualTo = DateMath.Anchored(new DateTime(2022, 01, 01)),
    LessThanOrEqualTo = DateMath.Now,
    TimeZone = "+11:00",
    Format = "dd/MM/yyyy||yyyy"
};


var settings = new ConnectionSettings(new Uri(connectionString));

var client = new ElasticClient(settings.UnsafeDisableTls13());

var searchResponse = client.Search<MacquarieUnit>(u => u.AllIndices()
                                                        .From(0)
                                                        .Size(10)
                                                        .Query(q => drq));


System.Console.WriteLine(searchResponse.ToString());                                                        


/*
var settings = new ConnectionConfiguration(new Uri(connectionString));

var lowLevelClient = new ElasticLowLevelClient(settings);

var searchResponse = lowLevelClient.Search<StringResponse>(PostData.Serializable(new {
    from = 0,
    size = 10,
    query = new {
        match = new {
            contentType = new { 
                query = "mq2cf_acfSubject"
            }
        }
    }
}));

var successful = searchResponse.Success;
var responseJson = searchResponse.Body;


System.Console.WriteLine($"Success: {0}\nResponse:{responseJson}");
System.Console.WriteLine($"{searchResponse.DebugInformation}");
searchResponse.TryGetServerError(out var error);
System.Console.WriteLine($"{error?.Error}");
*/