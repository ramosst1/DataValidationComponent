namespace DataValidation
{
    public interface IValidationMessage
    {
        string ErrorMessage { get;  set; }
        string FieldName { get; set; }
    }
}