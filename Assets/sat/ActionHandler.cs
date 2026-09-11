using System.IO.Compression;
using UnityEngine;
public class  ActionHandler : MonoBehaviour
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
        if (IsPlayerAdvantageous()) { print("bro took damage"); } else { print("player took damage"); }
    }

    private bool IsPlayerAdvantageous() {
        // quick event calll
        // calls quick event
        // actually it calls the quick event if the gfesturem  is kquiuck event calling wworthy
        if (broAction == Gesture.Gun) { print("trigger quick action"); }
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
                    break;
                case Gesture.Gun:
                    // bro is- SHUT UP SHU*T UP I WIN
                    Debug.Log("your did it");
                    break;
                default:
                    Application.Quit();
                    break;
            }
        }
        return false;
    }
}