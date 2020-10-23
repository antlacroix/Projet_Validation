using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models
{
    public partial class participation
    {
        public int Id
        {
            get { return id; }
        }

        public participant Participant
        {
            get { return participant; }
            set
            {
                participant = value;
            }
        }

        public role_participant Role
        {
            get { return role_participant; }
            set
            {
                role_participant = value;
            }
        }

        public film Movie
        {
            get { return film; }
            set
            {
                film = value;
            }
        }

        public override bool Equals(object obj)
        {
            var participation = obj as participation;

            return (Participant == participation.Participant && Role == participation.Role && Movie == participation.Movie);
        }

        public override int GetHashCode()
        {
            int hashParticipant = Participant == null ? 0 : Participant.GetHashCode();
            int hashRole = Role == null ? 0 : Role.GetHashCode();
            int hashMovie = Movie == null ? 0 : Movie.GetHashCode();

            return hashParticipant ^ hashRole ^ hashMovie;
        }

    }
}
