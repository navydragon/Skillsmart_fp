public static TOut Pipe<TIn, TOut>(this TIn value, Func<TIn, TOut> func)
    => func(value);

public static BoardState ProcessCascade(BoardState currentState)
{
    var matches = FindMatches(currentState.Board);

    if (matches.Count == 0)
        return currentState;

    return currentState
        .Pipe(state => RemoveMatches(state, matches))
        .Pipe(FillEmptySpaces)
        .Pipe(ProcessCascade);
}
