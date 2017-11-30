namespace Ucrs.Data.Common.Models.Contracts
{
    public interface IIdentifiable<TKey>
    {
        /// <summary>
        /// Specifies that the object that implements this interface is identified by an object of specified generic parameter
        /// </summary>
        /// <typeparam name="TKey">The Type for the identifier</typeparam>
        TKey Id { get; set; }
    }
}
