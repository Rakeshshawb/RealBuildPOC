using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealBuildPOC.Shared.DTOs
{
    public class UserDto
    {

    }
    public class CityDto
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string CityCode { get; set; }

        public long FK_StateID { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }   // nullable in DB

        public DateTime? DeletedOn { get; set; }   // nullable in DB
    }
}
