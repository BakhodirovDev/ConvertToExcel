namespace ConvertToExcel.Class
{
    public class Organization
    {
        public int Id { get; set; }                 // Tashkilotning noyob identifikatori
        public string Name { get; set; }            // Tashkilotning nomi
        public string Address { get; set; }         // Tashkilotning manzili
        public string PhoneNumber { get; set; }     // Tashkilotning aloqa raqami
        public string Email { get; set; }           // Tashkilotning elektron pochta manzili
        public DateTime EstablishedDate { get; set; } // Tashkilotning tashkil etilgan sanasi
        public string Website { get; set; }         // Tashkilotning rasmiy veb-sayti
        public int NumberOfEmployees { get; set; }  // Tashkilotdagi ishchilar soni
        public string Industry { get; set; }        // Tashkilot faoliyat yuritadigan soha
        public bool IsActive { get; set; }          // Tashkilot faolmi yoki yo'qmi
    }

}
