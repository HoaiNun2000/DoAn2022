using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sammishop.Models
{
    [JsonObject(IsReference = true)]
    public class Product : BaseModel
    {
        public string Name { get; set; }
        /// <summary>
        /// thông số kỹ thuật
        /// </summary>
        public string Specifications { get; set; }

        public string Decriptions { get; set; }

        /// <summary>
        /// Giá gốc
        /// </summary>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// Giá bán
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// Tồn kho
        /// </summary>
        public int Inventory { get; set; }

        // Hàng mới
        public bool IsNew { get; set; }

        /// <summary>
        /// Lượt xem
        /// </summary>
        public int View { get; set; }
        

        /// <summary>
        /// Nhà cung cấp
        /// </summary>
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        /// <summary>
        /// Thương hiệu (nhà sản xuất)
        /// </summary>
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }


        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<File> Files { get; set; }

        public virtual List<Cart> Carts { get; set; }

        public virtual List<DiscountProduct> DiscountProducts { get; set; }
    }
}
