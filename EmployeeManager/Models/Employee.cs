using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public Employee()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
    }

    //public partial class NewsAnnouncement
    //{
    //    private Item[] _items;

    //    public NewsAnnouncement()
    //    {
    //    }


    //    [JsonProperty("Items")]
    //    public Item[] Items
    //    {
    //        get => _items; set
    //        {
    //            _items = value;
    //        }
    //        }

    //        [JsonProperty("ItemCount")]
    //        public long ItemCount { get; set; }

    //    [JsonProperty("PageSize")]
    //    public long PageSize { get; set; }

    //    [JsonProperty("Links")]
    //    public Link[] Links { get; set; }

    //    [JsonProperty("PageNumber")]
    //    public long PageNumber { get; set; }

    //    [JsonProperty("PageCount")]
    //    public long PageCount { get; set; }



    //}
}
