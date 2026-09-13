using System.Collections;
using UnityEngine;

public class  ActionHandler : MonoBehaviour
{
    public RendererOfGesture _renderGesture;
    public RPSBattle RPSScript;
    public QTEText QTE;

    Gesture playerAction;
    Gesture enemyAction;
    bool isCanThePlayerCastQuestionMark = true;

    private void Start()
    {
        _renderGesture = FindAnyObjectByType<RendererOfGesture>();
    }

    // Display gestures and damage effects

    // Interface Begin
    public void OnGestureButtonPress(int action) {
        if (isCanThePlayerCastQuestionMark)
        {
            playerAction = (Gesture)action;
            EndTurn();
            isCanThePlayerCastQuestionMark = false;
            StartCoroutine(TimerAndThenOpenAndCloseBracket());
        }
    }
    // Interface End

    // The IEnumerator
    private float TheAmountOfSeconds = 5f;
    private IEnumerator TimerAndThenOpenAndCloseBracket() {
        yield return new WaitForSeconds(TheAmountOfSeconds);
        isCanThePlayerCastQuestionMark = true;
    }
    

    private void EndTurn()
    {
        RPSScript.MakeShit();
        enemyAction = EnemyDecide();
    }

    public void WhenShitHitsTheFan() {
        _renderGesture.RenderGesture(0, (int)playerAction);
        _renderGesture.RenderGesture(1, (int)enemyAction);
        CalculateConclusion();
    }

    enum Gesture
    {
        Rock,
        Paper,
        Scissors,
        MiddleFinger,
        Gun,
    }
    private void CalculateConclusion() {
        if (enemyAction == Gesture.Gun)
        {
            if (playerAction == Gesture.Gun) { RPSScript.BeginShootout(); }
            else { QTE.triggerQTE(); }
        }
        else
        {
            switch (playerAction)
            {
                case Gesture.Rock:
                    ConcludeStage2(Gesture.Paper);
                    break;
                case Gesture.Paper:
                    ConcludeStage2(Gesture.Scissors);
                    break;
                case Gesture.Scissors:
                    ConcludeStage2(Gesture.Rock);
                    break;
                case Gesture.MiddleFinger:
                    if (enemyAction == Gesture.MiddleFinger) { return; } else {Application.Quit(); }
                    break;
                case Gesture.Gun:
                    if (enemyAction == Gesture.MiddleFinger) { return; } else { RPSScript.DamageBro(50); }
                    break;
                default:
                    Application.Quit();
                    break;
            }
        }
    }

    private void ConcludeStage2(Gesture winningGest) {
        if (enemyAction == winningGest) { RPSScript.DamagePlayer(10); }
        else if (enemyAction == playerAction) { return; }
        else { RPSScript.DamageBro(10); }
    }

    private Gesture EnemyDecide() {
        // Fuckass function
        int decision = Random.Range(0, Gesture.GetNames(typeof(Gesture)).Length); 
        Gesture decisionGesture = (Gesture)decision;
        return decisionGesture;
    }
}