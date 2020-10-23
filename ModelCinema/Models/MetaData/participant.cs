using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(participantMetadata))]
    public partial class participant
    {
        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public ICollection<participation> Participations
        {
            get { return participations; }
            set
            {
                participations = value;
            }
        }

        public override bool Equals(object obj)
        {
            var participant = obj as participant;

            return (Name == participant.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    public class participantMetadata
    {
        [Required]
        [DisplayName("Nom")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
