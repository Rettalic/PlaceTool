using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommandHandler 
{
    public void Execute();
    public void Undo();
}
