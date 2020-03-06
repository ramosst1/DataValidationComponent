namespace DataValidation.ValidationRules
{
    public interface IRuleDetail
    {
        string Message { get; set; }
        string Rule { get; set; }
    }
}