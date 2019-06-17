using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmy.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonth { get; set; }
        public int DiscountRate { get; set; }


        public static readonly int UnSpecified = 0;

        public static readonly int PayAsYouGo = 1;
    }
}