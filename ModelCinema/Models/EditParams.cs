using ModelCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleSample.Models
{
    public class EditParams
    {
        public string key { get; set; }  // key value is appointment id value - while deleting the appointment it comes
        public string action { get; set; } // action indicates the current action of the CRUD operation. Ex: while adding new appointment the action value coming as "insert"
        public List<seance> added { get; set; } // added indicates the newly added appointment object details while modifying the recurrence events
        public List<seance> changed { get; set; } // changed indicates the edited/updated appointment object details
        public List<seance> deleted { get; set; } // deleted indicates the deleted appointment object details
        public seance value { get; set; } // value indicates the newly added appointment object details
    }
}
