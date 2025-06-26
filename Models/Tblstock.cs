using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tblstock")]
[Index("InventoryId", Name = "fk_inventory_id")]
[Index("SupplierId", Name = "fk_supplier_id")]
public partial class Tblstock
{
    [Key]
    [Column("stock_id", TypeName = "int(11)")]
    public int StockId { get; set; }

    [Column("description")]
    [StringLength(50)]
    public string Description { get; set; } = null!;

    [Column("quantity", TypeName = "int(10)")]
    public int Quantity { get; set; }

    [Column("price")]
    public float Price { get; set; }

    [Column("status")]
    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Column("supplier_id", TypeName = "int(11)")]
    public int? SupplierId { get; set; }

    [Column("inventory_id", TypeName = "int(11)")]
    public int? InventoryId { get; set; }

    [ForeignKey("InventoryId")]
    [InverseProperty("Tblstocks")]
    public virtual TblinventoryManager? Inventory { get; set; }

    [ForeignKey("SupplierId")]
    [InverseProperty("Tblstocks")]
    public virtual Tblsupplier? Supplier { get; set; }
}
