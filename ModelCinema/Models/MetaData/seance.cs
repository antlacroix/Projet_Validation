using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelCinema.Models
{
    [MetadataType(typeof(seanceMetaData))]
    public partial class seance
    {
        //min Length/Value for seance's proprety
        public const int
            titreMin = 1;
        public DateTime
            dateDebutMin = DateTime.Now,
            dateFinMin = DateTime.Now.AddMinutes(15);
        //max Length/Value for seance's proprety
        public const int
            titreMax = 50;
        public  DateTime
            dateDebutMax = DateTime.Now.AddYears(50),
            dateFinMax = DateTime.Now.AddYears(50);

        public int Id { get { return this.id; } set { this.id = value; } }
        public string Subject { get { return this.titre_seance; } set { this.titre_seance = value; } }
        public DateTime StartTime
        {
            get { return this.date_debut; }
            set { this.date_debut = value; }
        }
        public DateTime EndTime
        {
            get { return this.date_fin; }
            set { this.date_fin = value; }
        }

        public bool IsAllDay /// Modifier POUR EJS
        {
            get { return false; }
            set { this.IsAllDay = value; }
        }

        public int CinemaId
        {
            get { return this.salle.cinema_id; }
            set { this.salle.cinema_id = value; }
        }

        //public int SalleId
        //{
        //    get { return this.salle_id; }
        //    set { this.salle_id = value; }
        //}

        private string _RecurrenceRule;

        private System.Nullable<int> _RecurrenceID;
        public int? RecurrenceID
        {
            get { return this._RecurrenceID; }
            set { this._RecurrenceID = value; }
        }

        private string _RecurrenceException;
        public string RecurrenceException
        {
            get { return this._RecurrenceException; }
            set { this._RecurrenceException = value; }
        }
        public string RecurrenceRule
        {
            get
            {
                return this._RecurrenceRule;
            }
            set
            {
                if ((this._RecurrenceRule != value))
                {
                    this.OnRecurrenceRuleChanging(value);
                    this.SendPropertyChanging();
                    this._RecurrenceRule = value;
                    this.SendPropertyChanged("RecurrenceRule");
                    this.OnRecurrenceRuleChanged();
                }
            }
        }

        #region Extensibility Method Definitions
        partial void OnLoaded();
        //partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnSubjectChanging(string value);
        partial void OnSubjectChanged();
        partial void OnStartTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnStartTimeChanged();
        partial void OnEndTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnEndTimeChanged();
        partial void OnStartTimezoneChanging(string value);
        partial void OnStartTimezoneChanged();
        partial void OnEndTimezoneChanging(string value);
        partial void OnEndTimezoneChanged();
        partial void OnIsAllDayChanging(System.Nullable<bool> value);
        partial void OnIsAllDayChanged();
        partial void OnRecurrenceRuleChanging(string value);
        partial void OnRecurrenceRuleChanged();
        partial void OnRecurrenceIDChanging(System.Nullable<int> value);
        partial void OnRecurrenceIDChanged();
        partial void OnRecurrenceExceptionChanging(string value);
        partial void OnRecurrenceExceptionChanged();
        partial void OnConferenceIdChanging(System.Nullable<int> value);
        partial void OnConferenceIdChanged();
        #endregion

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class seanceMetaData
    {
        [Required]
        [DisplayName("Date de debut")]
        [DataType(DataType.DateTime)]
        public System.DateTime date_debut { get; set; }

        [Required]
        [DisplayName("Date de fin")]
        [DataType(DataType.DateTime)]
        public System.DateTime date_fin { get; set; }

        [Required]
        [DisplayName("Titre de la seance")]
        [StringLength(seance.titreMax)]
        public string titre_seance { get; set; }

        [DisplayName("Salle")]
        public int salle_id { get; set; }
    }
}