using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Commande
    {
        public Guid identifiant { get; private set; }
        public DateTime date { get; private set; }
        public List<Article> listArticles { get; private set; }
        public Livraison livraison { get; private set; }

        public Commande(Guid identifiant, DateTime date, List<Article> listArticles, Livraison livraison)
        {
            if (listArticles.Count > 0)
            {
                this.identifiant = identifiant;
                this.date = date;
                this.listArticles = listArticles;
                this.livraison = livraison;
            }
            else
            {
                Console.WriteLine("EmptyArticleException");
                Console.WriteLine("Impossible de passer une commande qui ne contient aucun article");
                Log log = new Log("EmptyArticleException");
            }
        }

        public string CommandeDetails()
        {
            try
            {
                if (Livraison.shippingFees.Count == 0)
                    Livraison.RemplirDictionairePrix();
                if (livraison.paysLivraison == "France" && listArticles.Count > 3)
                    livraison.prix = 0;
                else if (Livraison.shippingFees.ContainsKey(livraison.paysLivraison) && livraison.paysLivraison != "France" && (this.GetTotalPrice() >= 50 || listArticles.Count >= 4))
                    livraison.prix = 0;
                else if (!Livraison.shippingFees.ContainsKey(livraison.paysLivraison) && listArticles.Count >= 5 && this.GetTotalPrice() >= 100)
                    livraison.prix = 0;
                return $"La commande a pour identifiant {this.identifiant},\n" +
                           $"a été passé le {this.date},\n" +
                           //$"a cette liste d'article {listArticles.ForEach(la => la.ArticleDetails())},\n" +
                           $"Le prix coutera {CoutCommande(listArticles)}€" +
                           $" les détails de la livraison sont \n{livraison.LivraisonDetails()}\n.";
            }
            catch (Exception ex)
            {
                Log log = new Log(ex.ToString());
                return string.Empty;
            }
        }

        public decimal CoutCommande(List<Article> listArticle)
        {
            try
            {
                decimal prixCommande = 0;
                foreach (Article article in listArticle)
                    prixCommande += article.prixTTC;
                return prixCommande;
            }
            catch (Exception ex)
            {
                Log log = new Log(ex.ToString());
                return 0;
            }
        }

        public decimal moyenne(List<Article> articleList)
        {
            try
            {
                decimal toReturn = 0;
                foreach (var article in articleList)
                    toReturn += article.prixTTC;
                return toReturn / articleList.Count;
            }
            catch (Exception ex)
            {
                Log log = new Log(ex.ToString());
                return 0;
            }
        }

        public decimal GetTotalPrice()
        {
            decimal prix = 0;
            foreach (var item in this.listArticles)
                prix += item.prixTTC;
            return prix;
        }
    }
}