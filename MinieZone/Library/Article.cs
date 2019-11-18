using System;

namespace Library
{
    public class Article
    {
        public Guid identifiant { get; private set; }
        public string name { get; private set; }
        public decimal prixHT { get; private set; }
        public decimal prixTTC { get; private set; }

        public Article(Guid identifiant, decimal prixHT, decimal prixTTC, string name = "nom")
        {
            this.identifiant = identifiant;
            this.name = string.IsNullOrWhiteSpace(name) ? "Nom" : name;
            if (prixHT >= 0)
                this.prixHT = prixHT;
            else
                this.prixTTC = 0;
            if (prixTTC >= 0)
                this.prixTTC = prixTTC;
            else
                this.prixTTC = 0;
        }

        public string ArticleDetails()
        {
            return $"l'article {name}," +
                   $"a l'identifiant {identifiant}, " +
                   $"le prix HT est de {prixHT}€ " +
                   $"et son prix TTC est de {prixTTC}€.\n";
        }
    }
}