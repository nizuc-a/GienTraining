namespace TrainingApi.Helpers;

public class TrainingQueryObject
{
    public bool IsAscending { get; set; } = true;

    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 20;
}