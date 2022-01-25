namespace Courseloop.Models.Shared;

using System;
using Newtonsoft.Json;

public class MacquarieMetadata
{
    //TODO DateTime.DateTimeNow could become some dependancy to allow unit testing?
    //Otherwise it should be set another way.
    public DateTime DATE_DATA_RETRIEVED { get; init; } = DateTime.Now;

    [JsonProperty("modDate", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? ModificationDate { get; set; }
    [JsonProperty("code")]
    public string Code { get; set; }
    public string CodeSubject
    {
        get => Code[..4];
    }

    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("implementationYear")]
    public ushort ImplementationYear { get; set; }
    [JsonProperty("studyLevel")]
    public string StudyLevel { get; set; }
    [JsonProperty("hostName")]
    public string HostName { get; set; }
    [JsonProperty("contentTypeLabel")]
    public string ContentTypeLabel { get; set; }
    [JsonProperty("inode")]
    public string IndexNode { get; set; }
    /*
      Archived

      Alawys false
  */
    [JsonProperty("archived")]
    public bool Archived { get; set; }
    /*
        Host

        Always "f9b505e0-10b8-46ff-9032-507dd4c56b92": 2432
    */
    [JsonProperty("host")]
    public string Host { get; set; }
    /*
       Locked

       Always True
   */
    [JsonProperty("working")]
    public bool Working { get; set; }
    /*
        Locked

        Always False
    */
    [JsonProperty("locked")]
    public bool Locked { get; set; }
    [JsonProperty("stInode")]
    /*
        STIndexNode

        Always     "80917640-cfce-43e7-95e1-12de915927c2": 2432
    */
    public string STIndexNode { get; set; }
    [JsonProperty("contentType")]
    public string ContentType { get; set; }
    /*
        Live

        Always true for unit data returned.
    */
    [JsonProperty("live")]
    public bool Live { get; set; }
    [JsonProperty("owner")]
    public string Owner { get; set; }
    [JsonProperty("identifier")]
    public string Identifier { get; set; }
    [JsonProperty("studyLevelValue")]
    /*
        StudyLevelValue

        Valid options:
            "research_master": 192,
            "undergrad": 1208,
            "pathway": 41,
            "postgrad": 988,
            "undergrad,postgrad": 2,
            "postgrad,research_master": 1

            TODO Make StudyLevelValue enum?
    */
    public string StudyLevelValue { get; set; }
    [JsonProperty("languageId")]
    public ushort LanguageId { get; set; }
    [JsonProperty("URL_MAP_FOR_CONTENT")]
    public string UrlMapForContent { get; set; }
    [JsonProperty("parentAcademicOrg")]
    public string ParentAcademicOrg { get; set; }
    [JsonProperty("url")]
    public string Url { get; set; }
    [JsonProperty("titleImage")]
    public string TitleImage { get; set; }
    [JsonProperty("folder")]
    public string Folder { get; set; }
    [JsonProperty("hasTitleImage")]
    public bool HasTitleImage { get; set; }
    [JsonProperty("sortOrder")]
    public ushort SortOrder { get; set; }
    [JsonProperty("modUser")]
    public string ModificationUser { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("id")]
    public string Id => $"{Code}.{ImplementationYear}";
}
