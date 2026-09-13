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
                Destroy(Instantiate(Rock, targetSide.transform), 3);
                break;
            case 1:
                Destroy(Instantiate(Paper, targetSide.transform), 3);
                break;
            case 2:
                Destroy(Instantiate(Scissors, targetSide.transform), 3);
                break;
            case 3:
                Destroy(Instantiate(MiddleFinger, targetSide.transform), 3);
                break;
            case 4:
                Destroy(Instantiate(Gun, targetSide.transform), 3);
                break;
            default:
                Application.Quit();
                break;
        }
    }

}
