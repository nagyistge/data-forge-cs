namespace Pancas
{
    public interface IRow
    {
        /// <summary>
        /// Get column value by colun name.
        /// </summary>
        T ByColumn<T>(string columnName);

        /// <summary>
        /// Get column value by column index.
        /// </summary>
        T ByColumn<T>(int columnIndex);
    }
}