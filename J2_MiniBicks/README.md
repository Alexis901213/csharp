# MinieBicks

## Le contexte

Le client a été impressionné par notre réactivité et la qualité du prototype que nous lui avons développé.
La confiance grandissante, il nous propose d'intervenir sur un second projet, encore plus important.
Le client nous assure que si ce projet est un succès il ouvrira les portes à une longue collaboration.

## Les objectifs

Il s'agit cette fois-ci non seulement de développer une bibliothèque de classes mais également :

1. de construire une interface graphique: soit en WPF (.Net Framework) soit en ASP.Net MVC (Core 3.0)
2. de se connecter à une base de données en utilisant [Entity Framework](https://docs.microsoft.com/en-us/ef/core/) dans sa nouvelle version [Core 3.0](https://devblogs.microsoft.com/dotnet/announcing-ef-core-3-0-and-ef-6-3-general-availability/).
3. le choix de la base de données à utiliser est libre. Sont conseillées SqlLite, Microsoft SQL Server ou Azure Cosmos DB en fonction de vos connaissances existantes et de vos aspirations futures. [Cliquez ici](https://docs.microsoft.com/en-us/ef/core/providers/index?tabs=dotnet-core-cli) pour voir les packages NuGet à utiliser selon votre choix.

## Le sujet

Vous avez le choix entre:

* Partir sur le sujet proposé ci-dessous

**OU**

* Développer une solution à un projet personnel.
  * A noter que dans ce cas il faudra également fournir un document texte qui décrit succinctement votre sujet et liste les exigences principales de votre projet.

## Sujet MiniBicks

### Architecture

Une solution contenant au minimum 3 projets est attendue:

* *Id_Perso*.MiniBicks.UI, qui contiendra uniquement du code lié à de l'affichage (en fonction de la technologie choisie: ASP.Net MVC ou WPF)
* *Id_Perso*.MiniBicks.Lib, qui contiendra l'ensemble de la logique de votre application
* *Id_Perso*.MiniBicks.Data, qui contiendra l'accès et le requêtage de la base de données (avec Entity Framework Core 3.0)

### Énonce

L'entreprise Bicks est une petite ESN qui a connu une croissante extrêmement rapide grâce à l'expertise et au professionnalisme de ses consultants. Il y a un an encore ils n'étaient qu'une quinzaine de personnes. Aujourd'hui ils ont dépassés la barre des 100 collaborateurs.

Dans ce contexte, les process internes mis en place à la création de l'entreprise ne sont plus adaptés. Il s'agit maintenant de mettre en place des solutions et des outils informatiques qui permettront de supporter cette croissance fulgurante tout en simplifiant la vie aux employés.

L'entreprise Bicks ayant une expertise plus importante dans le domaine du .Net Framework que dans les autres technologies, il vous est demandé d'utiliser du .Net C# et d'utiliser les versions les plus récentes que vous trouverez.

Pour l'instant, l'entreprise a une organisation avec une hiérarchie assez plate. On retrouve au sommet un comité de direction. Un niveau intermédiaire composé de managers, chefs d'équipes et de responsables. Le reste des collaborateurs sont généralement des consultants ou des personnes qui s'occupent de la gestion administrative de l'entreprise.

Dernière particularité: l'entreprise Bicks est répartie sur plusieurs Pays. Certains process seront légèrement différent en fonction du Pays dans lequel travaille le collaborateur.

#### 1. Gestion des comptes utilisateurs

Un utilisateur a un identifiant unique, un nom, un prénom, une adresse, un role et un supérieur hiérarchique (à part notre PDG M. NORRIS bien évidemment). Selon le role dans l'entreprise, l'employé est autorisé (ou pas) à être le supérieur hiérarchique d'autres employés.

#### 2. Gestion des congés/absences

Chaque employé doit être en mesure de faire une demande de congés.
Un employé a 25 jours de congés par année. En France, il a également 10 jours de RTT par an et 12 en Belgique. Les autres pays ont un bonus de 5 jours de congés par an mais pas de RTT. Il faudra mettre en place de compteur de congés qui rappel à l'employé le nombre de jours qu'il lui reste (RTT et congés payés doivent être séparés).

Il faudra également prendre en compte que certaines absence particulière seront également gérer dans cette gestion des congés. Notamment:

* Congés non payés (illimités): nécessite une validation par un supérieur hiérarchique et un commentaire justifiant de la demande
* Décès (entre 1 et 5 jours selon le cas): nécessite un justificatif
* Naissance (3 jours)
* Marriage (4 jours)
* Maternité (16 semaines)
* Paternité (11 jours): valide uniquement si posé 1 mois avant la date de congés demandée
* Autres (enfant malade): nécessite justificatif et validation par un supérieur hiérarchique

Chaque employé cumule une partie de ses congés annuels chaque mois. Seule exception: les collègues allemands ont l'ensemble de leur congés à disposition dès le 1er Janvier.

N'oubliez pas de gérer un maximum de cas: impossible de posé un congé si le compteur tombe à 0. Le compteur ne devrait jamais tomber en-dessous de 0. Gérer la validation ou le refus par un supérieur hiérarchique, le manque de justificatifs obligatoires entraine le refus automatique, etc...

#### 3. Gestion des remboursements

Nos consultants sont souvent amenés à se déplacer pendant plusieurs jours dans le cadre de leur mission. Ces déplacements entraînent des frais qui leur sont remboursés sous réserve de justificatif (photo ou scan à fournir et à uploader dans votre système).

Il existe plusieurs types de frais:

* Transport en commun (TTC)
* Distance en km dans le cas de l'utilisation du véhicule personnel (le justificatif demandé est l'itinéraire parcouru). Somme remboursée = km x 0.33€.
* Péage / Parking (TTC et montant TVA)
* Téléphone (TTC)
* Repas (TTC et montant TVA)
* Logement (TTC et montant TVA)
* Divers (essence, matériel, etc..) (TTC et montant TVA)

Particularités pour les frais kilométriques:

* Limite de 27€ par jour
* Si la limite de 27€ est atteinte, il est possible de reporter le reste sur le jour ouvré (=Lundi à Vendredi inclus) suivant.

Il faudra également penser à proposer 3 reportings:

* Un tableau pour l'utilisateur qui récapitule l'ensemble de ses remboursements sur un mois
* Un tableau pour l'administration qui récapitule la somme à rembourser à chaque employé
* Un schéma pour l'administration qui récapitule les frais totaux sur un mois et leur répartition en fonction du type de frais.

### Conseils

1. **Faites au plus simple !** Il faut d'abord que ça fonctionne, avant de vouloir essayé d'améliorer son code et de gérer tous les cas d'utilisations qui vous viennent à l'esprit.
2. Si un point n'est pas assez clair: libre à vous d'interpréter de la manière que vous jugerez la plus pertinente. Imaginez ce qu'il se passerait dans la vie réelle en entreprise pour vous guider.
3. **N'oubliez pas de commit/push régulièrement !** Cela fait partie de votre évaluation.
4. **Il est parfaitement normal de ne pas arriver à tout faire.** Si malgré tout vous avez l'impression d'avoir répondu à l'ensemble des exigences ou si vous avez remarqué une erreur/incohérence, merci de me contacter par email.
