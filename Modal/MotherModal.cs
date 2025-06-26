using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lotus_surrogacy_agency_Admin_panel.Modal
{
    public class MotherModal
    {
        [Key]
        [Column("mother_id", TypeName = "int(11)")]
        public int MotherId { get; set; }

        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; } = null!;

        [Column("fullname")]
        [StringLength(100)]
        public string Fullname { get; set; } = null!;

        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Column("phone", TypeName = "int(50)")]
        public int Phone { get; set; }

        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; } = null!;

        [Column("status")]
        public bool Status { get; set; }

        [Column(TypeName = "int(10)")]
        public int Age { get; set; }

        [Column("marital status")]
        [StringLength(50)]
        public string MaritalStatus { get; set; } = null!;

        [StringLength(100)]
        public string Occupation { get; set; } = null!;

        [StringLength(100)]
        public string Address { get; set; } = null!;

        public string? StatusName { get; set; }
    }
}
