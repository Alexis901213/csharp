using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Library
{
    public class Article
    {
        public Guid identifiant { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                    RaisePropertyChanged();
                }
            }
        }
        public decimal prixHT { get; private set; }
        public decimal prixTTC { get; private set; }

        public Article(Guid identifiant, decimal prixHT, decimal prixTTC, string name)
        {
            this.identifiant = identifiant;
            this.name = name;
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