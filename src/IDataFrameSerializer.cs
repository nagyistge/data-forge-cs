using RSG;

namespace Pancas
{
    public interface IDataFrameSerializer
    {
        IPromise To(IDataSourcePlugin dataSourcePlugin);
    }
}