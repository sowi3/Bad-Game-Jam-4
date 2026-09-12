using UnityEngine;

public class RendererOfGesture : MonoBehaviour
{
    public GameObject enemySide;
    public GameObject playerSide;

    // Gesture Sprites
    public GameObject MiddleFinger;
    public GameObject Gun;
    public GameObject Rock;
    public GameObject Paper;
    public GameObject Scissors;

    public void RenderGesture(int side, int gesture) {
        GameObject targetSide = playerSide;
        switch (side) {
            case 1:
                targetSide = enemySide;
                break;
            case 0:
                targetSide = playerSide;
                break;
            default:
                Application.Quit();
                break;
        }

        switch (gesture) {
            case 0:
                Instantiate(Rock, targetSide.transform);
                break;
            case 1:
                Instantiate(Paper, targetSide.transform);
                break;
            case 2:
                Instantiate(Scissors, targetSide.transform);
                break;
            case 3:
                Instantiate(MiddleFinger, targetSide.transform);
                break;
            case 4:
                Instantiate(Gun, targetSide.transform);
                break;
            default:
                Application.Quit();
                break;
        }
    }

}
