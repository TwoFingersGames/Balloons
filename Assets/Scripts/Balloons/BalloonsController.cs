using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BalloonsController : MonoBehaviour
{
    public Marker marker;
    public List<Balloon> balloons;
    public List<Balloon> activeBalloons;
    
    public void OnBalloonClick(Balloon target)
    {
        activeBalloons[0].Atack(activeBalloons[1].transform.position);
        if (target.SelectBall == State.None&&activeBalloons.Count < 1)
        {
            target.SelectBall = State.First;
            activeBalloons.Add(target);
            Instantiate(marker, target.transform.position, target.transform.rotation, target.transform);
        }
        else if(target.SelectBall == State.None && activeBalloons.Count < 2)
        {
            target.SelectBall = State.Second;
            activeBalloons.Add(target);
            Instantiate(marker, target.transform.position, target.transform.rotation, target.transform);
            //activeBalloons[0].Atack(activeBalloons[1].transform.position);
        }
        else
        {
            activeBalloons.Clear();
        }
        //clickedBalloon.Click -= OnBalloonClick;
        
    }

    

}

