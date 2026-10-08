// Фрагмент для static partial class Game
// (рядом с Draw / CloneBoard / ReadMove из материала курса)

public static BoardState InitializeGame()
{
    const int size = 8;
    Board board = new Board(size);

    for (int row = 0; row < size; row++)
    {
        for (int col = 0; col < size; col++)
        {
            char symbol = symbols[r.Next(symbols.Length)];
            board.cells[row, col] = new Element(symbol);
        }
    }

    return new BoardState(board, 0);
}
