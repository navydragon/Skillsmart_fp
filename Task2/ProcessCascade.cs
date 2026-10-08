// Фрагмент для static partial class Game
// (рядом с FindMatches / RemoveMatches / FillEmptySpaces из материала курса)

public static BoardState ProcessCascade(BoardState currentState)
{
    var matches = FindMatches(currentState.Board);

    // Каскад завершён: возвращаем текущее состояние без изменений.
    if (matches.Count == 0)
        return currentState;

    // RemoveMatches удаляет комбинации, применяет гравитацию и начисляет очки.
    BoardState stateAfterRemoval = RemoveMatches(currentState, matches);
    BoardState stateAfterFill = FillEmptySpaces(stateAfterRemoval);

    // После заполнения могли появиться новые комбинации.
    return ProcessCascade(stateAfterFill);
}
