using System.ComponentModel.DataAnnotations;

namespace ipmanager.domain.Models
{
    public class IpModel
    {
        [Key]
        public string Ip { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}