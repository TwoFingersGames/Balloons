using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCommand : Command
{
    private BalloonsController _balloons;


    public CheckCommand(BalloonsController balloons)
    {
        _balloons = balloons;
    }

    public override void Execute()
    {
        //_balloons.Check();
    }

    public override void Undo()
    {
        //_balloons.SelectNone();
    }
}
