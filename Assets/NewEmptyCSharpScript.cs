using System.IO.Compression;
using UnityEngine;
public class  GameLoop : MonoBehaviour
{
    Gesture playerAction;
    Gesture broAction;


    public enum Gesture
    {
        Rock,
        Paper,
        Scissors,
        MiddleFinger,
        Gun,
    }

    private void InflictOutcome() {
        if (IsPlayerAdvantageous()) { DamageBro(); } else { DamagePlayer(); }
    }

    private bool IsPlayerAdvantageous() {
        // quick event calll
        // calls quick event
        // actually it calls the quick event if the gfesturem  is kquiuck event calling wworthy
        if (broAction == Gesture.Gun) { qucikkkEvnbt(); }
        else
        {
            switch (playerAction)
            {
                case Gesture.Rock:
                    // rock loses to paper you're supposed to know that smh
                    if (broAction == Gesture.Paper) { return false; } else { return true; }
                case Gesture.Paper:
                    // Paper got cut ouchie ow ow
                    if (broAction == Gesture.Scissors) { return false; } else { return true; }
                case Gesture.Scissors:
                    // euggh
                    if (broAction == Gesture.Rock) { return false; } else { return true; }
                case Gesture.MiddleFinger:
                    // bro is sad and hates you
                    Application.Quit();
                case Gesture.Gun:
                    // bro is- SHUT UP SHU*T UP I WIN
                    Application.Win();
                default:
                    Application.Quit();
            }
        }
        return false;
    }
}