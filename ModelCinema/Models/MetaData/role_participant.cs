using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(role_participantMetadata))]
    public partial class role_participant 
    {
        public int Id
        {
            get { return id; }
        }

        public string Role
        {
            get { return role; }
            set
            {
                role = value;
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
            var role = obj as role_participant;
            return (this.Role.Equals(role.Role));
        }

        public override int GetHashCode()
        {
            return this.Role.GetHashCode();
        }
    }

    public class role_participantMetadata
    {
        [Required]
        [DisplayName("Role")]
        [StringLength(50)]
        public string Role { get; set; }
    }
}