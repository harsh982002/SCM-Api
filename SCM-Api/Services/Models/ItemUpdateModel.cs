using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ItemUpdateModel
    {
        public int ItemId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string ItemSegment { get; set; } = null!;

        public string ItemType { get; set; } = null!;

        public string? RegulatedUnitCost { get; set; }

        public byte? CompanyId { get; set; }

        public byte? ItemUomId { get; set; }

        public byte? ItemAvailabilityId { get; set; }

        public byte? StatusId { get; set; }

        public byte? PurchaseCategoryId { get; set; }

        public List<int>? Departments { get; set; }

        public List<byte>? ReasonCodes { get; set; }
    }
}
