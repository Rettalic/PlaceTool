using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommandHandler> historyStack     = new Stack<ICommandHandler>();
    private Stack<ICommandHandler> redoHistoryStack = new Stack<ICommandHandler>();

    public void ExecuteCommand(ICommandHandler action)
    {
        action.Execute();
        historyStack.Push(action);
        redoHistoryStack.Clear();
    }

    public void UndoCommand()
    {
        if (historyStack.Count > 0)
        {
            redoHistoryStack.Push(historyStack.Peek());
            historyStack.Pop().Undo();
        }
    }

    public void RedoCommand()
    {
        if (redoHistoryStack.Count > 0)
        {
            historyStack.Push(redoHistoryStack.Peek());
            redoHistoryStack.Pop().Execute();
        }
    }
}
