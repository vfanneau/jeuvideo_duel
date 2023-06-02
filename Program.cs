namespace class_videogame;

class Character
{
    // VALEURS PAR DEFAUT
    public string name = "guest";
    public int pv = 100;
    public static int att = 30;
    public static int def = 3;

    public bool IsAlive(Character target){
        if(target.pv > 0){
            return true;
        } else {
            return false;
        }
    }

    public bool Attack(Character ennemy){
        if(att < 0){
            att = 0;
        }
        ennemy.pv = ennemy.pv - (att - def);
        return !ennemy.IsAlive(ennemy);
    }
}

class Program
{
    public static bool PlayersTurn(Character player, Character target){
        bool game_over = false;
        string useless;

        Console.WriteLine("Au tour de " + player.name + " de jouer");
        useless = Console.ReadLine();
        game_over = player.Attack(target);
        Console.WriteLine("Aie !");
        if(game_over){
            Console.WriteLine("Bravo " + player.name + " ! Vous avez gagné! Merci d'avoir joué");
        }
        return game_over;
    }
    
    static void Main(string[] args)
    {
        Character Player1 = new Character();
        Character Player2 = new Character();
        Player1.name = "Player 1";
        Player2.name = "Player 2";

        bool game_over = false;

        Console.WriteLine("Bienvenue dans mon mini-jeu (beta)");
        Console.WriteLine("Utilisez la touche entrée pour commencer le combat et passer au tour suivant");

        while(!game_over){
            // GESTION DU TOUR PAR TOUR
            if(!game_over){
                game_over = PlayersTurn(Player1, Player2);
            }
            if(!game_over){
                game_over = PlayersTurn(Player2, Player1);
            }
        }
    }
}

