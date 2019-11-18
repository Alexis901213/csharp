using System;
using Library;
using System.Collections.Generic;

namespace ConsoleView
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Article a = new Article(new Guid(), "article 1", 2.2, 3);
            //Article b = new Article(new Guid(), "article 2", 3.3, 4);
            //Article c = new Article(new Guid(), "article 3", 4.4, 5);

            //List<Article> listArticle = new List<Article>();
            //listArticle.Add(a);
            //listArticle.Add(b);

            //Livraison l = new Livraison("nom1", "prenom1", "adresse1", 12345, "ville1", "adresseLivraison1", 12345, "villeLivraison1", 5);

            //Commande x = new Commande(new Guid(), DateTime.Now, new List<Article>(listArticle), l);

            //Console.WriteLine(a.ArticleDetails());
            //Console.WriteLine(b.ArticleDetails());
            //Console.WriteLine(c.ArticleDetails());
            //Console.WriteLine(l.LivraisonDetails());
            //Console.WriteLine(x.CommandeDetails());

            Article articleExemple = new Article(new Guid(), 1M, 1M, "exemple");
            List<Article> listArticleExemple = new List<Article>();
            for (int i = 0; i <= 99; i++)
                listArticleExemple.Add(articleExemple);
            Livraison livraisonExemple = new Livraison("exmple", "exemple", "addrExemple", 12345, "villeExemple", "France", "adrrLivraisonExemple", 12345, "villeLivraisonEmple", "bsvjhb", sexe.Masculin);
            Commande commandeexemple = new Commande(new Guid(), DateTime.Now, listArticleExemple, livraisonExemple);

            //Commande commandeexemple2 = new Commande(new Guid(), DateTime.Now, new List<Article>(), livraisonExemple);

            Console.WriteLine(commandeexemple.CommandeDetails());

            Console.ReadKey();
        }
    }
}