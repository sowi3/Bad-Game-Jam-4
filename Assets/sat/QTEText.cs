using System.Collections;
using UnityEngine;

public class QTEText : MonoBehaviour
{
    public RPSBattle RPSScript;
    public AudioSource boomer;
    public Animator woosher;
    bool isPlayerActionMiddleFinger;

    public void triggerQTE() {
        // Play the animation and boom effect
        boomer.Play();
        woosher.SetBool("Woosh", true);
        StartCoroutine(Timeout());
        return;
    }

    public void MiddleFingerButton() {
        isPlayerActionMiddleFinger = true;
    }

    private IEnumerator Timeout() {
        yield return new WaitForSeconds(1);

        woosher.SetBool("Woosh", false); // Turn woosh off FUCK YOU WOOSH I HATE YOU
        if (!isPlayerActionMiddleFinger) RPSScript.DamagePlayer(50);
    }
}
