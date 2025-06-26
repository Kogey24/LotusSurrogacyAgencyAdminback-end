using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lotus_surrogacy_agency_Admin_panel.Modal
{
    public class ParentModal
    {
        [Key]
        [Column("parents_id", TypeName = "int(11)")]
        public int ParentsId { get; set; }

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
        public string Phone { get; set; }

        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; } = null!;

        [Column("gender")]
        [StringLength(20)]
        public string Gender { get; set; } = null!;

        [Column("status")]
        public bool Status { get; set; }

        [StringLength(100)]
        public string Address { get; set; } = null!;

        public string? StatusName { get; set; }

    }
}
