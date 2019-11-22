using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace RomainJ.MinieBicks.Data
{
    public class Conges
    {
        public Conges(DateTime dateAbsenceDebut, DateTime dateAbsenvceFin, int iD_Personne, Personne personne, int iD_TypeConges, TypeConges typeConges)
        {
            DateAbsenceDebut = dateAbsenceDebut;
            DateAbsenceFin = dateAbsenvceFin;
            ID_Personne = iD_Personne;
            Personne = personne;
            ID_TypeConges = iD_TypeConges;
            TypeConges = typeConges;
        }

        public Conges(int idConge, DateTime dateAbsenceDebut, DateTime dateAbsenceFin, int iD_Personne, Personne personne, int iD_TypeConges, TypeConges typeConges)
        {
            IdConge = idConge;
            DateAbsenceDebut = dateAbsenceDebut;
            DateAbsenceFin = dateAbsenceFin;
            ID_Personne = iD_Personne;
            Personne = personne;
            ID_TypeConges = iD_TypeConges;
            TypeConges = typeConges;
        }
        public Conges(DateTime dateAbsenceDebut, DateTime dateAbsenceFin, int iD_Personne, int iD_TypeConges)
        {
            DateAbsenceDebut = dateAbsenceDebut;
            DateAbsenceFin = dateAbsenceFin;
            ID_Personne = iD_Personne;
            ID_TypeConges = iD_TypeConges;
        }

        public static void AddConge(Conges conges)
        {
            using (var db = new MineBricksContext())
            {
                db.Add(conges);
                db.SaveChanges();
            }
        }

        public static int GetNombreCongeRestant(TypeConges typeConges)
        {
            int nb;
            using (var db = new MineBricksContext())
            {
                nb = Convert.ToInt32(db.Conges
                    .Where(c => c.TypeConges == typeConges)
                    .Select(c => (c.DateAbsenceFin - c.DateAbsenceDebut).Days));
            }

            return nb;
        }

        [Key]
        public int IdConge { get; set; }

        public DateTime DateAbsenceDebut { get; set; }
        public DateTime DateAbsenceFin { get; set; }

        [ForeignKey("Personne")]
        public int ID_Personne { get; set; }

        public Personne Personne { get; set; }

        [ForeignKey("TypeConges")]
        public int ID_TypeConges { get; set; }

        public virtual TypeConges TypeConges { get; set; }
    }
}
