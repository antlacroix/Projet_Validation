using System;
using ModelCinema.Models.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCinema.Models.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private cinema_dbEntities db;
        //private CinemaRepository cinemaRepo;
        //private ContactInfoRepository contactInfoRepo;
        private GenreRepository genreRepo;
        private MovieGenreRepository movieGenreRepo;
        private MovieRepository movieRepo;
        private ParticipantRepository participantRepo;
        private RoleParticipantRepository roleParticipantRepo;
        private ParticipationRepository participationRepo;
        //private RoomRepository roomRepo;
        //private SessionRepository sessionRepo;
        //private UserRepository userRepo;
        //private UserTypeRepository userTypeRepo;
        //private EquipmentRepository equipmentRepo;
        //private AddressRepository addressRepo;

        public UnitOfWork(cinema_dbEntities dbContext)
        {
            db = dbContext;
        }

        //public CinemaRepository CinemaRepo
        //{
        //    get
        //    {
        //        if (cinemaRepo == null)
        //        {
        //            cinemaRepo = new CinemaRepository(db);
        //        }
        //        return cinemaRepo;
        //    }
        //}

        //public ContactInfoRepository ContactInfoRepo
        //{
        //    get
        //    {
        //        if (contactInfoRepo == null)
        //        {
        //            contactInfoRepo = new ContactInfoRepository(db);
        //        }
        //        return contactInfoRepo;
        //    }
        //}

        public GenreRepository GenreRepo
        {
            get
            {
                if (genreRepo == null)
                {
                    genreRepo = new GenreRepository(db);
                }
                return genreRepo;
            }
        }

        public MovieGenreRepository MovieGenreRepo
        {
            get
            {
                if (movieGenreRepo == null)
                {
                    movieGenreRepo = new MovieGenreRepository(db);
                }
                return movieGenreRepo;
            }
        }

        public MovieRepository MovieRepo
        {
            get
            {
                if (movieRepo == null)
                {
                    movieRepo = new MovieRepository(db);
                }
                return movieRepo;
            }
        }

        public ParticipantRepository ParticipantRepo
        {
            get
            {
                if (participantRepo == null)
                {
                    participantRepo = new ParticipantRepository(db);
                }
                return participantRepo;
            }
        }

        public RoleParticipantRepository RoleParticipantRepo
        {
            get
            {
                if (roleParticipantRepo == null)
                {
                    roleParticipantRepo = new RoleParticipantRepository(db);
                }
                return roleParticipantRepo;
            }
        }
        public ParticipationRepository ParticipationRepo
        {
            get
            {
                if (participationRepo == null)
                {
                    participationRepo = new ParticipationRepository(db);
                }
                return participationRepo;
            }
        }

        //public RoomRepository RoomRepo
        //{
        //    get
        //    {
        //        if (roomRepo == null)
        //        {
        //            roomRepo = new RoomRepository(db);
        //        }
        //        return roomRepo;
        //    }
        //}

        //public SessionRepository SessionRepo
        //{
        //    get
        //    {
        //        if (sessionRepo == null)
        //        {
        //            sessionRepo = new SessionRepository(db);
        //        }
        //        return sessionRepo;
        //    }
        //}

        //public UserRepository UserRepo
        //{
        //    get
        //    {
        //        if (userRepo == null)
        //        {
        //            userRepo = new UserRepository(db);
        //        }
        //        return userRepo;
        //    }
        //}

        //public UserTypeRepository UserTypeRepo
        //{
        //    get
        //    {
        //        if (userTypeRepo == null)
        //        {
        //            userTypeRepo = new UserTypeRepository(db);
        //        }
        //        return userTypeRepo;
        //    }
        //}

        //public EquipmentRepository EquipmentRepo
        //{
        //    get
        //    {
        //        if (equipmentRepo == null)
        //        {
        //            equipmentRepo = new EquipmentRepository(db);
        //        }
        //        return equipmentRepo;
        //    }
        //}

        //public AddressRepository AddressRepo
        //{
        //    get
        //    {
        //        if (addressRepo == null)
        //        {
        //            addressRepo = new AddressRepository(db);
        //        }
        //        return addressRepo;
        //    }

        //}

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //Pour flusher le contenu rapidement pendant les test, a enlever apres
        public void FlushMovies()
        {
            db.participants.RemoveRange(db.participants);
            db.role_participant.RemoveRange(db.role_participant);
            db.participations.RemoveRange(db.participations);
            db.genre_film.RemoveRange(db.genre_film);
            db.genres.RemoveRange(db.genres);
            db.films.RemoveRange(db.films);
            db.SaveChanges();
        }
    }
}

