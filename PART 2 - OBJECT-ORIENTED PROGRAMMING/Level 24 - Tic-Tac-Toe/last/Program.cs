new TicTacToeGame().Run();
public class TicTacToeGame
{
    public void Run()
    {
        Player player1 = new Player(Cell.X);
        Player player2 = new Player(Cell.O);
        Console.WriteLine("Press Enter to Start");
        while (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            Board board = new Board();
            BoardRenderer renderer = new BoardRenderer();
            Console.Clear();
            Player currentPlayer = player1;
            int round = 1;
            while (round < 10)
            {
                Console.WriteLine($"It is {currentPlayer.Symbol}'s turn.");
                renderer.Draw(board);
                Console.Write("What square do you want to play in?");
                currentPlayer.PickSquare(board);
                Console.WriteLine();
                if (DidHeWin(currentPlayer, board))
                {
                    Console.Clear();
                    renderer.Draw(board);
                    break;
                }
                Console.Clear();
                round++;
                currentPlayer = currentPlayer == player1 ? player2 : player1;
            }
            if (round == 10)
            {
                renderer.Draw(board);
                Console.WriteLine($"Draw. Score: X - {player1.Score}, O - {player2.Score}.");
                Console.Write("Press Enter to play again.");
            }
            else
            {
                Console.WriteLine($"{currentPlayer.Symbol} Won. Score: X - {player1.Score}, O - {player2.Score}.");
                Console.Write("Press Enter to play again.");
            }
        }
    }
    private bool DidHeWin(Player player, Board board)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board.Squares[i, 0] == player.Symbol && board.Squares[i, 1] == player.Symbol && board.Squares[i, 2] == player.Symbol)
            {
                player.Score++;
                return true;
            }
            if (board.Squares[0, i] == player.Symbol && board.Squares[1, i] == player.Symbol && board.Squares[2, i] == player.Symbol)
            {
                player.Score++;
                return true;
            }
        }
        if (board.Squares[0, 0] == player.Symbol && board.Squares[1, 1] == player.Symbol && board.Squares[2, 2] == player.Symbol)
        {
            player.Score++;
            return true;
        }
        if (board.Squares[0, 2] == player.Symbol && board.Squares[1, 1] == player.Symbol && board.Squares[2, 0] == player.Symbol)
        {
            player.Score++;
            return true;
        }
        return false;
    }
}
public class Player
{
    public Cell Symbol { get; }
    public int Score { get; set; }
    public Player(Cell symbol)
    {
        Symbol = symbol;
    }
    public void PickSquare(Board board)
    {
        while (true)
        {
            ConsoleKey key = Console.ReadKey().Key;
            while (key != ConsoleKey.NumPad1 && key != ConsoleKey.NumPad2 && key != ConsoleKey.NumPad3 &&
                   key != ConsoleKey.NumPad4 && key != ConsoleKey.NumPad5 && key != ConsoleKey.NumPad6 &&
                   key != ConsoleKey.NumPad7 && key != ConsoleKey.NumPad8 && key != ConsoleKey.NumPad9)
                key = Console.ReadKey().Key;
            int row = 0, column = 0;
            if (key == ConsoleKey.NumPad7) { row = 0; column = 0; }
            else if (key == ConsoleKey.NumPad8) { row = 0; column = 1; }
            else if (key == ConsoleKey.NumPad9) { row = 0; column = 2; }
            else if (key == ConsoleKey.NumPad4) { row = 1; column = 0; }
            else if (key == ConsoleKey.NumPad5) { row = 1; column = 1; }
            else if (key == ConsoleKey.NumPad6) { row = 1; column = 2; }
            else if (key == ConsoleKey.NumPad1) { row = 2; column = 0; }
            else if (key == ConsoleKey.NumPad2) { row = 2; column = 1; }
            else if (key == ConsoleKey.NumPad3) { row = 2; column = 2; }
            if (board.AssignSquareTo(Symbol, row, column))
                return;
            Console.WriteLine("This cell is already taken. Try again.");
        }
    }
}
public class Board
{
    public Cell[,] Squares { get; } = new Cell[3, 3];

    public bool AssignSquareTo(Cell playerSymbol, int row, int column)
    {
        if (Squares[row, column] == Cell.Empty)
        {
            Squares[row, column] = playerSymbol;
            return true;
        }
        return false;
    }
    public Cell ContentsOf(int row, int column) => Squares[row, column];
}
public class BoardRenderer
{
    public void Draw(Board board)
    {
        char[,] symbols = new char[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                symbols[i, j] = GetCharacterFor(board.ContentsOf(i, j));
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {symbols[i, 0]} | {symbols[i, 1]} | {symbols[i, 2]}");
            if (i < 2)
                Console.WriteLine("---+---+---");
        }
    }
    private char GetCharacterFor(Cell Square) => Square switch { Cell.Empty => ' ', Cell.X => 'X', Cell.O => 'O' };
}
public enum Cell { Empty, X, O }