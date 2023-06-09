using System;

namespace Guild
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            Player newP = new Player("Gogo", "Bau");
            Player newP2 = new Player("Goro", "Don");
            newP.Class = "Bro";

            System.Console.WriteLine(newP);

            Guild newG = new Guild("NewG", 3);

            newG.AddPlayer(newP);
            newG.AddPlayer(newP2);

            //newG.RemovePlayer("Goro");
            newG.KickPlayersByClass("Bro");

           Console.WriteLine(newG.Report());
            

        }
    }
}
