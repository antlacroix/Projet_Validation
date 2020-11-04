using Effort;
using Effort.DataLoaders;
using ModelCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestModelCinema
{
    public static class MockDB
    {
        public static cinema_dbEntities cinema_DbEntities()
        {
            cinema_dbEntities output = null;

            var data = new ObjectData();
            GetSimpleContacts().ForEach(x => data.Table<contact_info>().Add(x));
            GetSimpleUserStatuses().ForEach(x => data.Table<user_status>().Add(x));
            GetSimpleUsers().ForEach(x => data.Table<user>().Add(x));
            GetSimpleUserTypes().ForEach(x => data.Table<user_type>().Add(x));
            GetSimpleType().ForEach(x => data.Table<type_film>().Add(x));
            GetSimpleFilms().ForEach(x => data.Table<film>().Add(x));
            GetSimpleCinemas().ForEach(x => data.Table<cinema>().Add(x));
            GetSimpleSalleStatus().ForEach(x => data.Table<salle_status>().Add(x));
            GetSimpleSalles().ForEach(x => data.Table<salle>().Add(x));
            GetSimpleSeances().ForEach(x => data.Table<seance>().Add(x));

            try
            {
                var connection = EntityConnectionFactory.CreateTransient("name=cinema_dbEntities", new ObjectDataLoader(data));
                output = new cinema_dbEntities(connection, false);
                return output;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return output;
            }
        }

        private static List<contact_info> GetSimpleContacts()
        {
            var output = new List<contact_info>();
            output.Add(new contact_info() { id = 1, adresse = "adresse 1", code_postal = "CPTEST", tel_number = "4181234567", pays = "canada", province = "qubec", ville = "quebec" });
            output.Add(new contact_info() { id = 2, adresse = "adresse 2", code_postal = "CPTEST", tel_number = "4181234567", pays = "canada", province = "qubec", ville = "quebec" });
            output.Add(new contact_info() { id = 3, adresse = "adresse 3", code_postal = "CPTEST", tel_number = "4181234567", pays = "canada", province = "qubec", ville = "quebec" });
            return output;
        }
        
        private static List<type_film> GetSimpleType()
        {
            var output = new List<type_film>();
            output.Add(new type_film() { id = 1, typage = "Court Métrage" });
            output.Add(new type_film() { id = 2, typage = "Standart" });
            output.Add(new type_film() { id = 3, typage = "Promotionnel" });
            return output;
        }

        private static List<film> GetSimpleFilms()
        {
            var output = new List<film>();
            output.Add(new film() { id = 1, titre = "film test 1", description = "1er film de test", annee_parution = 2000, duree = 15, id_type = 2, metascore = null, ranking = null, rating = null, votes = null, revenu = null, id_film = null });
            output.Add(new film() { id = 2, titre = "film test 2", description = "2e film de test", annee_parution = 2010, duree = 30, id_type = 2, metascore = null, ranking = null, rating = null, votes = null, revenu = null, id_film = null });
            output.Add(new film() { id = 3, titre = "film test 3", description = "3e film de test", annee_parution = 2005, duree = 45, id_type = 2, metascore = null, ranking = null, rating = null, votes = null, revenu = null, id_film = null });
            return output;
        }
        
        private static List<cinema> GetSimpleCinemas()
        {
            var output = new List<cinema>();
            output.Add(new cinema() { id = 1, cinema_name = "cinema test 1", contact_info_id = 1, responsable_user_id = 1 });
            output.Add(new cinema() { id = 2, cinema_name = "cinema test 2", contact_info_id = 2, responsable_user_id = 1 });
            return output;
        }

        private static List<salle_status> GetSimpleSalleStatus()
        {
            var output = new List<salle_status>();
            output.Add(new salle_status() { id = 1, status = "ACTIVE" });
            output.Add(new salle_status() { id = 2, status = "INACTIVE" });
            return output;
        }

        private static List<salle> GetSimpleSalles()
        {
            var output = new List<salle>();
            output.Add(new salle() { id = 1, cinema_id = 1, numero_salle = 1, status_id = 1 });
            output.Add(new salle() { id = 2, cinema_id = 1, numero_salle = 2, status_id = 1 });
            output.Add(new salle() { id = 3, cinema_id = 1, numero_salle = 3, status_id = 1 });
            output.Add(new salle() { id = 4, cinema_id = 2, numero_salle = 1, status_id = 1 });
            output.Add(new salle() { id = 5, cinema_id = 2, numero_salle = 2, status_id = 1 });
            output.Add(new salle() { id = 6, cinema_id = 2, numero_salle = 3, status_id = 2 });
            return output;
        }

        private static List<seance> GetSimpleSeances()
        {
            var output = new List<seance>();
            output.Add(new seance() { id = 1, salle_id = 1, titre_seance = "seance test 1", date_debut = new DateTime(2021, 1, 1, 10, 0, 0), date_fin = new DateTime(2021, 1, 1, 12, 0, 0) });
            output.Add(new seance() { id = 2, salle_id = 1, titre_seance = "seance test 2", date_debut = new DateTime(2021, 1, 1, 13, 0, 0), date_fin = new DateTime(2021, 1, 1, 15, 0, 0) });
            output.Add(new seance() { id = 3, salle_id = 1, titre_seance = "seance test 3", date_debut = new DateTime(2021, 1, 1, 16, 0, 0), date_fin = new DateTime(2021, 1, 1, 18, 0, 0) });
            output.Add(new seance() { id = 4, salle_id = 1, titre_seance = "seance test 4", date_debut = new DateTime(2021, 1, 1, 19, 0, 0), date_fin = new DateTime(2021, 1, 1, 21, 0, 0) });
            output.Add(new seance() { id = 5, salle_id = 1, titre_seance = "seance test 5", date_debut = new DateTime(2021, 1, 1, 22, 0, 0), date_fin = new DateTime(2021, 1, 2, 0, 0, 0) });
            output.Add(new seance() { id = 6, salle_id = 2, titre_seance = "seance test 6", date_debut = new DateTime(2021, 1, 1, 10, 0, 0), date_fin = new DateTime(2021, 1, 1, 12, 0, 0) });
            output.Add(new seance() { id = 7, salle_id = 2, titre_seance = "seance test 7", date_debut = new DateTime(2021, 1, 1, 13, 0, 0), date_fin = new DateTime(2021, 1, 1, 15, 0, 0) });
            output.Add(new seance() { id = 8, salle_id = 2, titre_seance = "seance test 8", date_debut = new DateTime(2021, 1, 1, 16, 0, 0), date_fin = new DateTime(2021, 1, 1, 18, 0, 0) });
            output.Add(new seance() { id = 9, salle_id = 2, titre_seance = "seance test 9", date_debut = new DateTime(2021, 1, 1, 19, 0, 0), date_fin = new DateTime(2021, 1, 1, 21, 0, 0) });
            output.Add(new seance() { id = 10, salle_id = 2, titre_seance = "seance test 10", date_debut = new DateTime(2021, 1, 1, 22, 0, 0), date_fin = new DateTime(2021, 1, 2, 0, 0, 0) });
            output.Add(new seance() { id = 11, salle_id = 3, titre_seance = "seance test 11", date_debut = new DateTime(2021, 1, 1, 10, 0, 0), date_fin = new DateTime(2021, 1, 1, 12, 0, 0) });
            output.Add(new seance() { id = 12, salle_id = 3, titre_seance = "seance test 12", date_debut = new DateTime(2021, 1, 1, 13, 0, 0), date_fin = new DateTime(2021, 1, 1, 15, 0, 0) });
            output.Add(new seance() { id = 13, salle_id = 3, titre_seance = "seance test 13", date_debut = new DateTime(2021, 1, 1, 16, 0, 0), date_fin = new DateTime(2021, 1, 1, 18, 0, 0) });
            output.Add(new seance() { id = 14, salle_id = 3, titre_seance = "seance test 14", date_debut = new DateTime(2021, 1, 1, 19, 0, 0), date_fin = new DateTime(2021, 1, 1, 21, 0, 0) });
            output.Add(new seance() { id = 15, salle_id = 3, titre_seance = "seance test 15", date_debut = new DateTime(2021, 1, 1, 22, 0, 0), date_fin = new DateTime(2021, 1, 2, 0, 0, 0) });
            output.Add(new seance() { id = 16, salle_id = 4, titre_seance = "seance test 16", date_debut = new DateTime(2021, 1, 1, 10, 0, 0), date_fin = new DateTime(2021, 1, 1, 12, 0, 0) });
            output.Add(new seance() { id = 17, salle_id = 4, titre_seance = "seance test 17", date_debut = new DateTime(2021, 1, 1, 13, 0, 0), date_fin = new DateTime(2021, 1, 1, 15, 0, 0) });
            output.Add(new seance() { id = 18, salle_id = 4, titre_seance = "seance test 18", date_debut = new DateTime(2021, 1, 1, 16, 0, 0), date_fin = new DateTime(2021, 1, 1, 18, 0, 0) });
            output.Add(new seance() { id = 19, salle_id = 4, titre_seance = "seance test 19", date_debut = new DateTime(2021, 1, 1, 19, 0, 0), date_fin = new DateTime(2021, 1, 1, 21, 0, 0) });
            output.Add(new seance() { id = 20, salle_id = 4, titre_seance = "seance test 20", date_debut = new DateTime(2021, 1, 1, 22, 0, 0), date_fin = new DateTime(2021, 1, 2, 0, 0, 0) });
            output.Add(new seance() { id = 21, salle_id = 5, titre_seance = "seance test 21", date_debut = new DateTime(2021, 1, 1, 10, 0, 0), date_fin = new DateTime(2021, 1, 1, 12, 0, 0) });
            output.Add(new seance() { id = 22, salle_id = 5, titre_seance = "seance test 22", date_debut = new DateTime(2021, 1, 1, 13, 0, 0), date_fin = new DateTime(2021, 1, 1, 15, 0, 0) });
            output.Add(new seance() { id = 23, salle_id = 5, titre_seance = "seance test 23", date_debut = new DateTime(2021, 1, 1, 16, 0, 0), date_fin = new DateTime(2021, 1, 1, 18, 0, 0) });
            output.Add(new seance() { id = 24, salle_id = 5, titre_seance = "seance test 24", date_debut = new DateTime(2021, 1, 1, 19, 0, 0), date_fin = new DateTime(2021, 1, 1, 21, 0, 0) });
            output.Add(new seance() { id = 25, salle_id = 5, titre_seance = "seance test 25", date_debut = new DateTime(2021, 1, 1, 22, 0, 0), date_fin = new DateTime(2021, 1, 2, 0, 0, 0) });
            return output;
        }

        private static List<user_type> GetSimpleUserTypes()
        {
            var output = new List<user_type>();
            output.Add(new user_type() { id = 1, type = "ADMIN" });
            output.Add(new user_type() { id = 2, type = "PROGRAMATEUR" });
            return output;
        }

        private static List<user_status> GetSimpleUserStatuses()
        {
            var output = new List<user_status>();
            output.Add(new user_status() { id = 1, status = "ACTIF" });
            output.Add(new user_status() { id = 2, status = "INACTIF" });
            return output;
        }

        private static List<user> GetSimpleUsers()
        {
            var output = new List<user>();
            output.Add(new user() { id = 1, login = "login1", name = "name1", contact_info_id = 3, user_status_id = 1, user_type_id = 1 });
            return output;
        }


    }
}
