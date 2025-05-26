using System.ComponentModel.DataAnnotations;

namespace TechProcessSupportSys.Dtos.Blank
{
    public class CreateBlankDto
    {
        [Required]
        [MaxLength(30)]
        public string Asortment { get; set; } = "";
        [RegularExpression(@"(ГОСТ\s\d{1,5}(\.\d{1,4}){0,2}-(\d{4}|\d{2})|)")]
        public string? AsortmentGOST { get; set; }
        [Required]
        [MaxLength(30)]
        public string Material { get; set; } = "";
        [RegularExpression(@"^([А-ЯЁ]{1,3}|Без ТО)$")]
        public string? MaterialStateCode { get; set; }
        [RegularExpression(@"(ГОСТ\s\d{1,5}(\.\d{1,4}){0,2}-(\d{4}|\d{2})|)")]
        public string? MaterialGOST { get; set; }
        [Required]
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Diameter { get; set; }
        public bool IsPrivate { get; set; } = false;
    }
}
