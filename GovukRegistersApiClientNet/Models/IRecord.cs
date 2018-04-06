namespace GovukRegistersApiClientNet.Models
{
    public interface IRecord
    {
        IItem Item { get; }
        IEntry Entry { get; }
    }
}
