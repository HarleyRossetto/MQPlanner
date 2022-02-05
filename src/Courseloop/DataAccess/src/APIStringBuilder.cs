namespace Courseloop.DataAccess;

using System;
using System.Text;

public class HandbookApiRequestBuilder
{
    protected StringBuilder API_STRING = new(250);

    private string? _code = null;
    public string? Code {
        get { return _code; }
        set {
            if (value is not null)
                _code = value;
        }
    }

    protected string BASE_API_STRING { get; set; } = "https://macquarie-prod-handbook.factor5-curriculum.com.au/api/content/render/false/query/+contentType:mq2_p";
    public int? ImplementationYear { get; set; } = null;
    public int? Limit { get; set; } = null;

    public APIResourceType ResourceType { get; set; } = APIResourceType.Unit;

    public HandbookApiRequestBuilder() { }

    public HandbookApiRequestBuilder(int? implementationYear, APIResourceType resourceType) : this() {
        ImplementationYear = implementationYear;
        ResourceType = resourceType;
    }

    public HandbookApiRequestBuilder(string code, int? implementationYear, APIResourceType resourceType) : this() {
        Code = code;
        ImplementationYear = implementationYear;
        ResourceType = resourceType;
    }

    protected virtual string GetBaseAPIString() { return ""; }
    protected virtual string GetRequestDataType() {
        return ResourceType switch {
            APIResourceType.Course => "course",
            APIResourceType.Unit => "subject",
            _ => "",
        };
    }

    public override string ToString() {
        API_STRING.Clear();
        API_STRING.Append(BASE_API_STRING);
        API_STRING.Append(GetRequestDataType());

        if (ImplementationYear is not null) {
            API_STRING.Append($"%20+mq2_p{GetRequestDataType()}.implementationYear:{ImplementationYear}");
        }
        if (Code is not null) {
            API_STRING.Append($"%20+mq2_p{GetRequestDataType()}.code:{Code}");
        }
        if (Limit is not null) {
            API_STRING.Append($"/limit/{Limit}");
        }
        return API_STRING.ToString();
    }
    public virtual void Reset() {
        Code = null;
        ImplementationYear = null;
        Limit = null;
    }
}

public enum APIResourceType
{
    Unit,
    Course
}


//Leaving these as syntatic sugar for the moment
public class UnitApiRequestBuilder : HandbookApiRequestBuilder
{

    public UnitApiRequestBuilder() : base(DateTime.Now.Year, APIResourceType.Unit) {
        //BASE_API_STRING = GetBaseAPIString();
    }

    public UnitApiRequestBuilder(int? implementationYear) : base(implementationYear, APIResourceType.Unit) {
        //BASE_API_STRING = GetBaseAPIString();
    }

    public UnitApiRequestBuilder(string unitCode) : base(unitCode, DateTime.Now.Year, APIResourceType.Unit) {
        //BASE_API_STRING = GetBaseAPIString();
    }

    public UnitApiRequestBuilder(string unitCode, int? implementationYear) : base(unitCode, implementationYear, APIResourceType.Unit) {
        //BASE_API_STRING = GetBaseAPIString();
    }

}

public class CourseApiRequestBuilder : HandbookApiRequestBuilder
{
    public CourseApiRequestBuilder() : base(DateTime.Now.Year, APIResourceType.Course) {
        //BASE_API_STRING = GetBaseAPIString();
    }

    public CourseApiRequestBuilder(int? implementationYear) : base(implementationYear, APIResourceType.Course) {
        //BASE_API_STRING = GetBaseAPIString();
    }


    public CourseApiRequestBuilder(string unitCode) : base(unitCode, DateTime.Now.Year, APIResourceType.Course) {
        //BASE_API_STRING = GetBaseAPIString();
    }

    public CourseApiRequestBuilder(string unitCode, int? implementationYear) : base(unitCode, implementationYear, APIResourceType.Course) {
        //BASE_API_STRING = GetBaseAPIString();
    }

}
