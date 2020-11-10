using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.MetaData
{
    [MetadataType(typeof(programmationMetaData))]
    public partial class programmation
    {
        private bool isSelected = false;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
    }
    public class programmationMetaData
    {
        
    }
}
