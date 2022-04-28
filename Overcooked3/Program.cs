using System;
using System.Collections.Generic;
using System.Linq;

namespace Overcooked3
{
    #region Informations Importantes
    //Info Importante : Pour rentrer une commande il faut absolument une fois la commande écrite, écrire au moins un caractère que ce soit un espace où une lettre.
    // Le Console.ReadLine.Split ne peut être nul càd aucune des deux partie composés par cette fonction ne peut être nul sinon le programme s'arrête//
    // Une fois le choix de commande effectué, vous ne pouvez pas changer  : Si vous aveez entré 1 alors, vous ne pourrez accéder qu'aux ingrédients et pas aux recettes.
    // Pour cela il faut relancer le programme
    #endregion
    class Program
    {
        // Espace qui me permet de déclarer des variables globales //
        #region  Globales

        public static string[] StockIngredients = { "" };
        public static string[] StockRecipes = { "" };
        #endregion

        // La fonction Main me permet d'exécuter mon programme//
        #region Execution

        #region Main
        static void Main()
        {
            List<string> Commandes = new List<string>(); // Je déclare une liste de string nommée Commandes//
            string choixInputIngr = (""); // je déclare une string vide nommée choixInputIngr// 
            string ChoixInputRec = ("");// je déclare une string vide nommée choixInputRec// 
            string Choix = ("");// je déclare une string vide nommée Choix// 

        //------------ ICI J'EXECUTE MES AUTRES METHODES------------//
            TableauCommande(Commandes);
            Intro();
            ViewCommands(Commandes);
            Menu(ChoixInputRec, choixInputIngr, Choix, Commandes);
            
        }
        #endregion

        #region Intro
        static void Intro() // Cette méthide est nommée intro puisqu'elle est le début du programme.
        {
            //Console.WriteLine  permet ici à l'ordinateur  d'écrire quelque chose directement dans la console.
            Console.WriteLine(" Bienvenue dans votre Assitant personnel de Cuisine aussi appelé APC:"); 
            

        }
        #endregion

        #region Menu
        static void Menu(string choixInputIngr, string ChoixInputRec, string Choix, List<string> Commandes) 
            // cette méthode possède des arguments,
            // qui sont entre autres des variables déclarées précedemment dans d'autres méthodes ce qui me permet de les récupérer dans une autre méthode
        {
            Console.WriteLine(" ");
            choixInputIngr = ("1"); // J'assigne une valeur à ma string choixInputIngr que j'ai déclarée précedemment dans le Main
             ChoixInputRec = ("2");
            Console.WriteLine(" Si vous souhaitez ajouter où voir vos ingrédients tapez :" + choixInputIngr);
            Console.WriteLine(" Si vous souhaitez créer où voir vos recettes tapez :" + ChoixInputRec);
            Console.WriteLine(" Si vous voulez voir toutes les commandes utiliser la commande : /help");
            Choix = Console.ReadLine();
            if (Choix == choixInputIngr) // if est une condition  permettant d'effectuer quelque chose si la condition est vraie
            {
                InputCommandeIngredients(Commandes, choixInputIngr, ChoixInputRec, Choix);
            }
            if( Choix == ChoixInputRec)
            {
                InputCommandeRecipes(Commandes, choixInputIngr, ChoixInputRec, Choix);
            }

            if (Choix == Commandes[4])
            {

                Console.WriteLine("Voici la liste des commandes :");
                Console.WriteLine(" ");
                WriteToConsole(Commandes);
                Menu(ChoixInputRec, choixInputIngr, Choix, Commandes);
            }
        }
        #endregion
        static void ViewCommands(List<string> Commandes) // cette méthode prends en paramètre "Commandes"//
           {
                Console.WriteLine(" ");
                Console.WriteLine(" Voici les commandes dont vous pouvez vous servir pour ajouter/ créer des recettes où  ingrédients te voir ceux déja inscrits :" );
                Console.WriteLine(" ");
                WriteToConsole(Commandes);
           }


        #region TableauCommande
        static void  TableauCommande(List<string> Commandes) 
        {
            // Commandes.Add permet d'ajouter des valeurs dans cette Liste. Dans ce cas précis j'ajoute ("/addIngredients")
            Commandes.Add("/addIngredients");
            Commandes.Add("/makeRecipes");
            Commandes.Add("/viewRecipes");
            Commandes.Add("/viewIngredients");
            Commandes.Add("/help");
            Commandes[4] = "/help";
            Commandes[3] = "/viewIngredients";
            Commandes[2] = "/viewRecipes";
            Commandes[1] = "/makeRecipes";
            Commandes[0] = "/addIngredients"; // une fois ajouter la valeur  ("/addIngredients") je l'assigne maintenant à la 1ere place de l'index dans ma liste
        }
        #endregion

        #region InputCommandeForIngredients
        static void InputCommandeIngredients(List<string> Commandes, string choixInputIngr, string ChoixInputRec, string Choix)
        {
            
            
             Console.WriteLine(" ");
             Console.WriteLine(" Veuillez renseignez une commande:");
             Console.WriteLine(" ");
            string[] InputIngredients = Console.ReadLine().Split(' '); // Console.ReadLine().Split("") permet de demander deux Inputs en un sur la même ligne à rentrer au joueur
                string Input = InputIngredients[0]; // la string Input est égale à la 1ere partie de InputIngredients donc le 1er input à rentrer//
                string Ingredients = InputIngredients[1];// la string Ingredients est égale à la 1ere partie de InputIngredients donc le 2nd input à rentrer//

                if (Input == Commandes[0] && Ingredients != null)
                {
                    Console.WriteLine(" Votre ingredient a bien été ajouté");
                    CreateTableauIngredients(StockIngredients, Input, Ingredients);
                    InputCommandeIngredients(Commandes, choixInputIngr, ChoixInputRec, Choix);
                }

                if (Input == Commandes[0] && InputIngredients[1] == null)
                {

                Console.WriteLine(" Veuillez d'abord renseigner un ingredient");
                    InputCommandeIngredients(Commandes, choixInputIngr, ChoixInputRec, Choix);
                }

                if (Input == Commandes[3])
                {

                   WriteToConsoleStockIngredients(StockIngredients);
                    InputCommandeIngredients(Commandes, choixInputIngr, ChoixInputRec, Choix);
                }

                if (Ingredients == null)
                {
                    Console.WriteLine("veuillez renseignez un ingredient avec la commande :" + Commandes[0] + " l'ingredient souhaité");
                    InputCommandeIngredients(Commandes, choixInputIngr, ChoixInputRec, Choix);
                } 

            


        }
        #endregion

        #region InputCommandeForRecipes
        static void InputCommandeRecipes(List<string> Commandes, string choixInputIngr, string ChoixInputRec, string Choix)
        {

            // Le Console.ReadLine.Split ne peut être nul c.à.d aucune des deux partie composés par cette fonction ne peut être nul sinon le programme s'arrête//

            Console.WriteLine(" ");
            Console.WriteLine(" Veuillez renseignez une commande:");
            Console.WriteLine(" ");
            string[] InputRecipes = Console.ReadLine().Split(' ');
                string Input_R = InputRecipes[0];
                string Recipes = InputRecipes[1];

                if (Input_R == Commandes[1] && Recipes == null)
                {
                    Console.WriteLine(" Veuillez créer où choisir  une recette");
                    InputCommandeRecipes(Commandes, choixInputIngr, ChoixInputRec, Choix);
                }

                if (Input_R == Commandes[1] && Recipes != null)
                {
                    Console.WriteLine("Votre recette as bien été ajoutée");
                    CreateTableauRecipe(StockRecipes, Recipes, Input_R);
                    InputCommandeRecipes(Commandes, choixInputIngr, ChoixInputRec, Choix);
                }
                

                 if(Input_R ==Commandes[2] && Recipes != null)
                {
                  WriteToConsoleStockRecipes(StockRecipes);
                    InputCommandeRecipes(Commandes, choixInputIngr, ChoixInputRec, Choix);
                }
            
                if (Input_R == Commandes[2] && Recipes == null)
                {
                Console.WriteLine("Vuiller d'abord créer une recette");
                    InputCommandeRecipes(Commandes, choixInputIngr, ChoixInputRec, Choix);
                }

            
           


        }
        #endregion

        #region CreateTableauForRecipe
        static void  CreateTableauRecipe(string[] StockRecipes, string Recipes, string Input_R)
        {
          
            Recipes.ToArray(); // permet de convertir Recipes en tableau
            foreach(char recipes in Recipes) // pour chaque characteres dans Recipes
            {
                StockRecipes[0] = Recipes;// la 1ere valeur de StockRecipes est égale à la valeur de Recipes
            }
           
        }

        #endregion

        #region CreateTableauForIngredients
        static void CreateTableauIngredients(string[] StockIngredients,  string Input, string Ingredients)
            {
              
                 Ingredients.ToArray();
                foreach (char ingredient in Ingredients)
                {
                    StockIngredients[0] = Ingredients;
                
                }
                
            
            }
        #endregion

        #region WriteToConsole
        static void WriteToConsole(List<string> Commandes) // cette méthode me permet de faire apparaître les valeurs dans Commandes
        {
            foreach (string  o in Commandes)
            {
                Console.WriteLine(o);
            }
        }
        #endregion

        #region WriteToConsoleStockIngredients
        static void WriteToConsoleStockIngredients(string[] StockIngredients)
        {
            foreach (string  o in StockIngredients)
            {
                Console.WriteLine(o);
            }
        }
        #endregion

        #region WriteToConsoleStockRecipes
        static void WriteToConsoleStockRecipes(string[] StockRecipes)
        {
            foreach (string o in StockRecipes)
            {
                Console.WriteLine(o);
            }
        }
        #endregion

        #endregion
    }
}
