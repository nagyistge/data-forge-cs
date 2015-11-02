namespace Pancas
{
    public interface IDataFrameLoader
    {
        IDataFrame As(IDataFormatPlugin dataFormatPlugin);
    }
}