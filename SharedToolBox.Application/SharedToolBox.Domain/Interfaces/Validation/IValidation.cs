using SharedToolBox.Domain.Validation;

namespace SharedToolBox.Domain.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}