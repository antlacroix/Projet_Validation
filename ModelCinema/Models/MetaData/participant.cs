using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(participantMetadata))]
    public partial class participant
    {
        //min Length/Value for participant's proprety
        public const int
            nameMin = 2;
        //max Length/Value for participant's proprety
        public const int
            nameMax = 50;

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
            return Name == null ? 0 : Name.GetHashCode();
        }
    }

    public class participantMetadata
    {
        [Required]
        [DisplayName("Nom")]
        [StringLength(participant.nameMax)]
        public string Name { get; set; }
    }
}
