using ConvertToExcel.Dtos;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ConvertToExcel.Service
{
    public class ConvertToExcelService
    {
        public byte[] GenerateExcel(List<GetOrganizationDto> organizations)
        {
            if (organizations == null || !organizations.Any())
                throw new ArgumentException("The organization list is empty.");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Litsenziya kontekstini o'rnatish

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Organizations");

                // Sarlavhalar
                worksheet.Cells[1, 1].Value = "Id"; // Id sarlavhasini 1-ustunga qo'shish
                var properties = typeof(GetOrganizationDto).GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[1, i + 2].Value = properties[i].Name; // Boshqa sarlavhalar 2-ustundan boshlanadi
                }

                // Ma'lumotlarni qo'shish
                for (int i = 0; i < organizations.Count; i++)
                {
                    var org = organizations[i];
                    worksheet.Cells[i + 2, 1].Value = i + 1; // Id ustuniga tartib raqamini yozish
                    for (int j = 0; j < properties.Length; j++)
                    {
                        worksheet.Cells[i + 2, j + 2].Value = properties[j].GetValue(org); // Ma'lumotlarni qo'shish
                    }
                }

                // Formatlash
                using (var range = worksheet.Cells[1, 1, 1, properties.Length + 1]) // Sarlavhalar uchun format
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                // Ma'lumotlar qatorlariga chegara chizish
                var dataRange = worksheet.Cells[1, 1, organizations.Count + 1, properties.Length + 1];
                dataRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                // Sana ustuniga format
                worksheet.Column(5).Style.Numberformat.Format = "yyyy-mm-dd";

                worksheet.Cells.AutoFitColumns();

                return package.GetAsByteArray();
            }
        }
    }
}
