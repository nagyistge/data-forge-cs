using RSG;

namespace Pancas
{
    public interface IDataFrameDeserializer
    {
        IPromise<IDataFrame> As(IDataFormatPlugin dataFormatPlugin);
    }
}