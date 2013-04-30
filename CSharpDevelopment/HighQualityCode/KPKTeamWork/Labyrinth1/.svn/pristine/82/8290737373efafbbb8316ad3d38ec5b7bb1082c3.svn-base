using System;
using System.Linq;

namespace Labyrinth
{
    public class LabyrinthProgram
    {
        readonly static Playfield playfield = new Playfield(Configuration.GAME_FIELD_SIZE);
        readonly static Message message = new Message();
        private static Scoreboard scores;
        private static Player player;

        public static void NewGame()
        {
            message.IntroOfLabyrinthGame();

            Position playerInitioalPos = new Position(Configuration.GAME_FIELD_SIZE / 2, Configuration.GAME_FIELD_SIZE / 2);

            player = new Player(playerInitioalPos);
            playfield.CreateGameField(player);

            message.NewLine();

            player = new Player(playerInitioalPos);
            playfield.RenderGameField(player);            
        }

        public static void Main(string[] args)
        {
            NewGame();
            scores = new Scoreboard();
            message.PrintAlloudMoves();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "exit")
            {
                
                switch (input)
                {
                    case "top":
                        Console.WriteLine(scores.Show(Configuration.FILE_NAME));
                        break;
                    case "restart":
                        NewGame();
                        break;
                    case "L":
                        if (!player.Move(Direction.Left))
                        {
                            message.PrintInvalidMoveMessage();
                        }
                        else
                        {
                            player.Points++;
                            playfield.RenderGameField(player);
                        }
                        break;
                    case "U":
                        if (!player.Move(Direction.Up))
                        {
                            message.PrintInvalidMoveMessage();
                        }
                        else
                        {
                            player.Points++;
                            playfield.RenderGameField(player);
                        }
                        break;
                    case "R":
                        if (!player.Move(Direction.Right))
                        {
                            message.PrintInvalidMoveMessage();
                        }
                        else
                        {
                            player.Points++;
                            playfield.RenderGameField(player);
                        }
                        break;
                    case "D":
                        if (!player.Move(Direction.Down))
                        {
                            message.PrintInvalidMoveMessage();
                        }
                        else
                        {
                            player.Points++;
                            playfield.RenderGameField(player);
                        }
                        break;
                    default:
                        {
                            message.PrintInvalidMoveMessage();
                            break;
                        }
                }

                if (player.Position.IsWinning(Configuration.GAME_FIELD_SIZE))
                {
                    message.PrintWonMessage(player.Points);
                    player.Name = Console.ReadLine();
                    scores.Add(Configuration.FILE_NAME, player);
                    message.NewLine();
                    NewGame();
                }

                message.PrintAlloudMoves();
            }

            Console.Write("Good Bye!");
            Console.ReadKey();
        }
    }
}
