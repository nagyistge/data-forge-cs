using RSG;

namespace DataForge
{
    public interface IDataFrameSerializer
    {
        IPromise To(IDataSourcePlugin dataSourcePlugin);
    }
}