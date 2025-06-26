using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lotus_surrogacy_agency_Admin_panel.Modal
{
    public class DonorModal
    {
        [Key]
        [Column("donor_id", TypeName = "int(11)")]
        public int DonorId { get; set; }

        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; } = null!;

        [Column("fullname")]
        [StringLength(100)]
        public string Fullname { get; set; } = null!;

        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Column(TypeName = "int(11)")]
        public int Age { get; set; }

        [StringLength(50)]
        public string Complexion { get; set; } = null!;

        [Column("phone", TypeName = "int(50)")]
        public string Phone { get; set; }

        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; } = null!;

        [Column("status")]
        public bool Status { get; set; }

        [StringLength(100)]
        public string Address { get; set; } = null!;

        [Column("HIV status")]
        [StringLength(100)]
        public string HivStatus { get; set; } = null!;

        [Column(TypeName = "int(10)")]
        public int Height { get; set; }

        [Column(TypeName = "int(10)")]
        public int Weight { get; set; }

        public string? StatusName {  get; set; }
    }
}
