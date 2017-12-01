namespace Ucrs.Data.Common.Models.Contracts
{
    public interface IUser : IIdentifiable<string>, IDeletableEntity
    {
        string Email { get; set; }
    }
}
