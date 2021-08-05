using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dungeon
{
    class Dungeon
    {
        static void Main(string[] args)
        {
            Console.Title = "Clone Wars Dungeon Application";

            int score = 0;

            Weapon rifle = new Weapon(50, 90, "DC-15A Blaster Rifle", 30);
            Player player = new Player("Fives", 70, 40, 350, 350, rifle);

            bool exit = false;

            do
            {
                BattleDroid bd1 = new BattleDroid("B1 Battle Droid", 150, 150, 70, 30, 50, 90, "B1 Battle Droids make up the bulk of the Separatist Alliance's infantry forces, serving as expendable grunts throughout the Clone Wars.");
                SuperBattleDroid sbd1 = new SuperBattleDroid("B2 Super Battle Droid", 300, 300, 70, 40, 60, 110, "B2 Super Battle Droids are an upgraded version of the B1 battle droids, with superior weapons, armor and silver plating.");
                CommandoDroid cd1 = new CommandoDroid("BX-series Droid Commando", 350, 350, 90, 40, 60, 75, "Commando Droids are advanced, lethal droids on the battlefront, equipped with a modified E-5 Blaster Rifle for ranged combat, and a vibrosword for melee attacks.");
                Droideka d1 = new Droideka("Droideka", 350, 350, 50, 40, 30, 155, "The Droideka is a powerful and mobile droid that can deal significant damage with its twin blaster cannons. They can also pull up an energy shield, which significantly increases their health.", false);
                Droideka d2 = new Droideka("Droideka", 350, 350, 50, 40, 30, 155, "The Droideka is a powerful and mobile droid that can deal significant damage with its twin blaster cannons. They can also pull up an energy shield, which significantly increases their health.", true);

                Droid[] droids = { bd1, sbd1, cd1, d1, d2};

                Console.WriteLine(GetRoom());

                Random rand = new Random();
                int randomNbr = rand.Next(droids.Length);
                Droid droid = droids[randomNbr];

                Console.WriteLine("\nThere's a " + droid.Name + "!");

                bool reload = false;

                do
                {
                    //Menu
                    Console.WriteLine("\nAction Menu\n" +
                        "A. Attack\n" +
                        "R. Run Away\n" +
                        "P. Player Info\n" +
                        "E. Enemy Info\n" +
                        "X. Exit\n");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Attack");
                            Combat.DoBattle(player, droid);
                            if (droid.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\nTarget Eliminated!\n");
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }

                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Fall Back!");
                            Console.WriteLine($"You barely make it out alive.");
                            Console.WriteLine();
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine("Droids annihilated: " + score);
                            break;
                        case ConsoleKey.E:
                            Console.WriteLine("Enemy Info");
                            Console.WriteLine(droid);
                            break;
                        case ConsoleKey.X:
                            Console.WriteLine("Let's move out of here!");
                            exit = true;
                            break;
                    }//end switch

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Mission Failed! Fall Back!");
                        exit = true;
                    }

                } while (!exit && !reload);
            } while (!exit);

            Console.WriteLine("You defeated " + score +
                " droid" + (score == 1 ? "." : "s."));

        }//end main

        private static string GetRoom()
        {
            string[] rooms =
            {
                "You arrive on Geonosis, the homeworld of the Geonosians, a species of sentient insectoids. It has a breathable atmosphere, but a hot and arid climate. Its irradiated surface is covered in harsh, rocky deserts, marked by mesas and buttes. Both its rocks and sky are tinted in shades of red. Surface water is scarce, amounting to only 5% of the entire total planetary surface. However, Geonosis has frequent flash floods. From space, it can be seen that Geonosis has awe-inspiring rocky rings. The planet is orbited by fifteen moons, four of which are major.",
                "You arrive on Kamino, a remote water planet outside the main galaxy. The world's oceans hold an abundance of life. Kamino is renowned for its science and production of clone armies and often contracted with private security forces and other clients. Receiving minimal trade, Kamino's imports are only enough to support the planet's population of one billion. There are many cities scattered across the surface that are built on stilts and many of them are devoted to cloning.",
                "You arrive on Kashyyyk, a temperate jungle planet orbiting around a single star located in the Mytaranor sector of the Mid Rim. Covered in wroshyr trees, Kashyyyk serves as homeworld to the Wookiee species. Native fauna such as Can-cells influence the design of starships by the Wookiee inhabitants, while great cities such as Kachirho are built into the planet's trees. The Kashyyykian wilds can be dangerous to many, thanks to dangerous animals such as wyyyschokk spiders and carnivorous plants like the jaw plant and saava.",
                "You arrive on Naboo, a small pastoral world in the Mid Rim, located near the border of the Outer Rim Territories. Naboo's surface is comprised of a vast array of different landscapes, from rolling plains and grassy hills to swampy lakes caused by the water-filled network of deep-sea tunnels. The swamps act as a gateway to the world's seas, where legendary creatures dwell. Beside its natural features, Naboo is considered a world of classical beauty due to the aesthetics of its population centers. The porous crust's natural plasma is harvested for energy and building material, and is generally thought to be the key to many of the planet's secrets.",
                "You arrive on Felucia, a remote world in the Felucia system, overrun with thick, colorful, and humid jungle made up by a unique combination of fungi species. The world is a hotbed of life, and several non-sentient species also inhabit the world, including Gelagrubs, jungle rancors, and tee-muss. Despite its perceived insignificance, its important location and resources (which include the healing plant nysillin) leads to several conflicts both in orbit and on the surface."
            };
            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room;
        }

    }//end class
}//namespace
