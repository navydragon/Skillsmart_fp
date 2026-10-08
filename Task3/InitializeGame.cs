// Не силен в C#, но выяснилось, что там нет |> как в F# и пришлось загуглить Pipe

public static TOut Pipe<TIn, TOut>(this TIn value, Func<TIn, TOut> func)
    => func(value);

public static BoardState InitializeGame(int boardSize = 8)
{
    return
        new BoardState(new Board(boardSize), 0)
        .Pipe(FillEmptySpaces)
        .Pipe(ProcessCascade);
}

public static BoardState ProcessCascade(BoardState currentState)
{
    var matches = FindMatches(currentState.Board);

    if (matches.Count == 0)
        return currentState;

    return

        currentState.Pipe(state => RemoveMatches(state, matches))
        .Pipe(FillEmptySpaces)
        .Pipe(ProcessCascade);
}
