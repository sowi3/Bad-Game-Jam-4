using UnityEngine;
public class  ActionHandler : MonoBehaviour
{
    Gesture playerAction;
    Gesture enemyAction;
    
    // Interface Begin
    public void OnGestureButtonPress(int action) {
        playerAction = (Gesture)action;
    }
    public void EndTurn()
    {
        enemyAction = EnemyDecide();
        InflictOutcome();
    }

    // Interface End

    enum Gesture
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
        if (enemyAction == Gesture.Gun) { print("trigger quick action ecentr tune, respond to gun in time with middle finger"); }
        else
        {
            switch (playerAction)
            {
                case Gesture.Rock:
                    // rock loses to paper you're supposed to know that smh
                    if (enemyAction == Gesture.Paper) { return false; } else { return true; }
                case Gesture.Paper:
                    // Paper got cut ouchie ow ow
                    if (enemyAction == Gesture.Scissors) { return false; } else { return true; }
                case Gesture.Scissors:
                    // euggh
                    if (enemyAction == Gesture.Rock) { return false; } else { return true; }
                case Gesture.MiddleFinger:
                    // bro is sad and hates you
                    Application.Quit();
                    break;
                case Gesture.Gun:
                    // bro is- SHUT UP SHU*T UP I WIN
                    if (enemyAction == Gesture.MiddleFinger) { print("your failed to shoot him, no op"); break; } else { print("your did it"); }
                    break;
                default:
                    Application.Quit();
                    break;
            }
        }
        return false;
    }

    private Gesture EnemyDecide() {
        // Fuckass function
        int decision = Random.Range(0, Gesture.GetNames(typeof(Gesture)).Length); 
        Gesture decisionGesture = (Gesture)decision;
        print(decisionGesture);
        return decisionGesture;
    }
}