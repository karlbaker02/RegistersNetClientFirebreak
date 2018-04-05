namespace GovukRegistersApiClientNet.Models
{
    public interface IRecord
    {
        IItem GetItem();
        IEntry GetEntry();
    }
}
