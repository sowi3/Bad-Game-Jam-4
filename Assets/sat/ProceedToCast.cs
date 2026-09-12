using UnityEngine;

public class ProceedToCast : MonoBehaviour
{
    public ActionHandler shitHandler;
    // Start called once before the first poop of Update after the MonoBehaviour is triangulated through the event matrix
    private void Start()
    {
        shitHandler = FindAnyObjectByType<ActionHandler>();
    }
    private void OnDestroy()
    {
        // Pee pee
        // poo poo
        // bodygurnjhd
        shitHandler.WhenShitHitsTheFan();
    }
}
