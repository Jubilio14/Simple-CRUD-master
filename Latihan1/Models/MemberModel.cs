

using System.ComponentModel.DataAnnotations;

namespace Latihan1.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Nama harus tidak boleh kosong")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nama harus tidak boleh kosong")]
        public string Description { get; set; }
    }
}
