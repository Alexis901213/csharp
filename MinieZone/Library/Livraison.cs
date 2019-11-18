using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public enum sexe
    {
        Masculin,
        Feminin
    }
    public class Livraison
    {
        public static Dictionary<string, int> shippingFees = new Dictionary<string, int>();
        public string nom { get; private set; }
        public string prenom { get; private set; }
        public string adresse { get; private set; }
        public int codePostal { get; private set; }
        public string ville { get; private set; }
        public string pays { get; private set; }
        public string adresseLivraison { get; private set; }
        public int codePostalLivraison { get; private set; }
        public string villeLivraison { get; private set; }
        public string paysLivraison { get; private set; }
        public double prix { get; set; }
        public int delai { get; private set; }
        public sexe sexe { get; private set; }

        public Livraison(string nom, string prenom,
                          string adresse, int codePostal, string ville, string pays,
                          string adresseLivraison, int codePostalLivraison, string villeLivraison, string paysLivraison, 
                          sexe sexe, int delai = 7)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.codePostal = codePostal;
            this.ville = ville;
            this.pays = pays;
            this.adresseLivraison = adresseLivraison;
            this.codePostalLivraison = codePostalLivraison;
            this.villeLivraison = villeLivraison;
            this.paysLivraison = paysLivraison;
            this.prix = GetPrixLivraison();
            this.delai = delai;
            this.sexe = sexe;
        }

        public int GetPrixLivraison()
        {
            int prix = 0;
            if (shippingFees.Count == 0)
                RemplirDictionairePrix();

            foreach (var item in shippingFees)
            {
                if (item.Key.ToUpper() == this.paysLivraison.ToUpper())
                {
                    prix = item.Value;
                    break;
                }
                else
                    prix = 20;
            }
            this.prix = prix;
            return prix;
        }

        public static void RemplirDictionairePrix()
        {
            shippingFees.Add("France", 5);
            shippingFees.Add("Allemagne", 10);
            shippingFees.Add("Autriche", 10);
            shippingFees.Add("Belgique", 10);
            shippingFees.Add("Bulgarie", 10);
            shippingFees.Add("Chypre", 10);
            shippingFees.Add("Croatie", 10);
            shippingFees.Add("Danemark", 10);
            shippingFees.Add("Espagne", 10);
            shippingFees.Add("Estonie", 10);
            shippingFees.Add("Finlande", 10);
            shippingFees.Add("Grèce", 10);
            shippingFees.Add("Hongrie", 10);
            shippingFees.Add("Irelande", 10);
            shippingFees.Add("Italie", 10);
            shippingFees.Add("Lettonie", 10);
            shippingFees.Add("Lituanie", 10);
            shippingFees.Add("Luxembourg", 10);
            shippingFees.Add("Malte", 10);
            shippingFees.Add("Pologne", 10);
            shippingFees.Add("Portugal", 10);
            shippingFees.Add("Pays-Bas", 10);
            shippingFees.Add("Republique tchèque", 10);
            shippingFees.Add("Roumanie", 10);
            shippingFees.Add("Royaume-Uni", 10);
            shippingFees.Add("Slovaquie", 10);
            shippingFees.Add("Slovénie", 10);
            shippingFees.Add("Suède", 10);
        }

        public string LivraisonDetails()
        {
            return $"le nom est {nom}," +
                   $"le prenom est {prenom},\n" +
                   $"l'adresse est {adresseLivraison}, {codePostalLivraison}, {villeLivraison}, {paysLivraison},\n" +
                   $"les frais de livraisons sont de {this.prix}€," +
                   $" le délai est de {delai} jour(s), soit le {DateTime.Now.AddDays(7)}.\n";
        }
    }
}
