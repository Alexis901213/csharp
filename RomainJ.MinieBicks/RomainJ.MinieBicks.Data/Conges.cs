using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RomainJ.MinieBicks.Data
{
    public class Conges
    {
        public Conges(DateTime dateAbsence, int iD_Personne, Personne personne, int iD_TypeConges, TypeConges typeConges)
        {
            DateAbsence = dateAbsence;
            ID_Personne = iD_Personne;
            Personne = personne;
            ID_TypeConges = iD_TypeConges;
            TypeConges = typeConges;
        }

        public Conges(int idConge, DateTime dateAbsence, int iD_Personne, Personne personne, int iD_TypeConges, TypeConges typeConges)
        {
            IdConge = idConge;
            DateAbsence = dateAbsence;
            ID_Personne = iD_Personne;
            Personne = personne;
            ID_TypeConges = iD_TypeConges;
            TypeConges = typeConges;
        }
        public Conges(DateTime dateAbsence, int iD_Personne, int iD_TypeConges)
        {
            DateAbsence = dateAbsence;
            ID_Personne = iD_Personne;
            ID_TypeConges = iD_TypeConges;
        }
        [Key]
        public int IdConge { get; set; }

        public DateTime DateAbsence { get; set; }

        [ForeignKey("Personne")]
        public int ID_Personne { get; set; }

        public Personne Personne { get; set; }

        [ForeignKey("TypeConges")]
        public int ID_TypeConges { get; set; }

        public virtual TypeConges TypeConges { get; set; }
    }
}
