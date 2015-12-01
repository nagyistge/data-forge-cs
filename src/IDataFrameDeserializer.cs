using RSG;

namespace DataForge
{
    public interface IDataFrameDeserializer
    {
        IPromise<IDataFrame> As(IDataFormatPlugin dataFormatPlugin);
    }
}