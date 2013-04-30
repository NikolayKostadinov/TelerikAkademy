namespace Labyrinth
{
    public static class Extensions
    {
        public static bool IsValidPosition(this Position source, int fieldSize)
        {
            if (source.X < fieldSize && source.X >= 0 && source.Y >= 0 && source.Y < fieldSize)
            {
                return true;
            }
            return false;
        }

        public static bool IsWinning(this Position source, int fieldSize)
        {
            if (source.X == 0 || source.X == fieldSize - 1 || source.Y == 0 || source.Y == fieldSize - 1)
            {
                return true;
            }
            return false;
        }
    }
}
