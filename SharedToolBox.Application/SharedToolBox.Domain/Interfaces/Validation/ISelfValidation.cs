using SharedToolBox.Domain.Validation;

namespace SharedToolBox.Domain.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}