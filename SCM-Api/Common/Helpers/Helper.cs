namespace Common.Helpers
{
    using System.Text;

    public class Helper
    {
        public static DateTime GetCurrentUTCDateTime() => DateTime.UtcNow;

        /// <summary>
        /// Convert data to CSV.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="genericList"></param>
        /// <returns>string data.</returns>
        public static string ConvertToCSV<T>(List<T> genericList)
        {
            // Create a StringBuilder to store the CSV data
            var CsvBuilder = new StringBuilder();

            // Get the list of properties for the type T
            var properties = typeof(T).GetProperties();

            // Append header row
            var header = string.Join(",", properties.Select(p => p.Name));
            CsvBuilder.AppendLine(header);

            // Append data rows
            foreach (var item in genericList)
            {
                var row = string.Join(",", properties.Select(p => p.GetValue(item)?.ToString()));
                CsvBuilder.AppendLine(row);
            }

            var CsvData = CsvBuilder.ToString();
            return CsvData;
        }

    }
}
