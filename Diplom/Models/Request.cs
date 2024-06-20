using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Diplom.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public string? Eiscode { get; set; }

    public double? LimitsForRequestPrice { get; set; }

    public string? PositionPlanChart { get; set; }

    public double? ProvisionOfRequest { get; set; }

    public int? DeadlineCompletionWork { get; set; }

    public double? ProvisionOfContract { get; set; }

    public string? StuffName { get; set; }

    public double? OkpdTwoCode { get; set; }

    public double? NmckPrice { get; set; }

    public int? TermOfContract { get; set; }

    public int? PartnerId { get; set; }

    public int? UserId { get; set; }

    public string? RequestStatus { get; set; }

    public string? SupplierStatus { get; set; }

    public string? AdditionalInformation { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public ulong? CodeRefinement { get; set; }

    public ulong? PreparingObjectDescription { get; set; }

    public ulong? PreparingDraftLetter { get; set; }

    public ulong? PreparationDraftCalculationNmcc { get; set; }

    public ulong? PreparationDraftContract { get; set; }

    public ulong? PreparationDraftNotification { get; set; }

    public ulong? PreparationPublicationNotification { get; set; }

    public DateOnly? RequestCreationDate { get; set; }

    public DateOnly? RequestClosingDate { get; set; }

    public string? StuffType { get; set; }

    public string? UserName { get; set; }
    [JsonIgnore]
    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    [JsonIgnore]
    public virtual User? Partner { get; set; }
    [JsonIgnore]
    public virtual ICollection<Taskforrequest> Taskforrequests { get; set; } = new List<Taskforrequest>();
    [JsonIgnore]
    public virtual User? User { get; set; }
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
