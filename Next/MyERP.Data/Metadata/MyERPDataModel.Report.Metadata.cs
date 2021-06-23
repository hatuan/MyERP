using System.ComponentModel.DataAnnotations;

namespace MyERP.DataAccess
{
    [MetadataType(typeof(Report.Metadata))]
    public partial class Report
    {
        public partial class Metadata
        {
    
            [Key]
            [Required()]
            public object Id { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object RepId { get; set; }
    
            [StringLength(3)]
            [Required()]
            public object RepNo { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object Text { get; set; }
    
            [StringLength(256)]
            [Required()]
            public object Title { get; set; }
    
            [StringLength(256)]
            public object FileName { get; set; }
    
            public object Blob { get; set; }
        }
    }
}
