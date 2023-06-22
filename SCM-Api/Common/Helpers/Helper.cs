namespace Common.Helpers
{
    using NReco.PdfGenerator;
    using System.Text;

    public class Helper
    {
        /// <summary>
        /// For getting the CurrentDateTime.
        /// </summary>
        /// <returns>DateTime data.</returns>
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

        /// <summary>
        /// ConvertHtmlToPdf.
        /// </summary>
        /// <param name="htmlContent"></param>
        /// <returns>Byte.</returns>
        public static byte[] ConvertHtmlToPdf(string body)
        {
            HtmlToPdfConverter converter = new();
            converter.License.SetLicenseKey("PDF_Generator_Src_Examples_Pack_252860367097", "VznQd4kFbjh2VTOCIL2NhgL/QLI5zfE60okWm9AYsgpYZYAlc/1BUxQea1KFKBneH37lSmxD6bzAdDJaq9AVXz8IqyzSnuXWFDKVctaaQXoVtXZYndHsVreJmaRdiSnYdhILIn/nPxk5E0NsCsUvHOoxp+FKhngOXJXgkYIyuDU=");
            converter.PdfToolPath = Path.Combine(Environment.CurrentDirectory, "HtmlTemplate");
            converter.Margins = new PageMargins { Top = 10, Bottom = 10, Left = 10, Right = 10 };
            converter.Orientation = PageOrientation.Portrait;
            converter.Size = PageSize.A4;
            byte[] pdf = converter.GeneratePdf(body);
            return pdf;
        }

    }
}
