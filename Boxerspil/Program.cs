namespace Boxerspil
{
    class Program
    {
        static void Main(string[] args) => StartGame<Game>();
        private static void StartGame<T>() where T : Game, new()
        {
            T game = new T();
            game.Start();
            game.Update();
            game.Shutdown();
        }
    }
}
