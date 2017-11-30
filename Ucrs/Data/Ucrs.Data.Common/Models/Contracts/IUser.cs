namespace Ucrs.Data.Common.Models.Contracts
{
    public interface IStudent : IIdentifiable<string>, IDeletableEntity
    {
        string Email { get; set; }
    }
}
