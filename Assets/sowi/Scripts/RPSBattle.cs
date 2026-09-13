using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPSBattle : MonoBehaviour
{
    public GameObject shit;
    public GameObject[] enemies;
    public GameObject enemyAnchor;

    GameObject _enemy;
    int enemyHealth = 100;
    int playerHealth = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewBattle();
    }

    // Battle Control
    public void NewBattle() {
        enemyHealth = 100;
        playerHealth = 100;
        _enemy = SpawnRandomEnemy();
    }

    public void EndBattle() {
        Destroy(_enemy);
        NewBattle();
   }
    public void MakeShit() {
        GameObject _shit = Instantiate(shit, transform);
        Destroy(_shit, 2);
    }

    // Actor Control

    public void DamageBro(int value) {
        enemyHealth -= value;
        if (enemyHealth <= 0) EndBattle();
    }

    public void DamagePlayer(int value) {
        playerHealth -= value;
        if (playerHealth <= 0) Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    int lastEnemy = 100;
    GameObject SpawnRandomEnemy() {
        int i = lastEnemy;
        while (i == lastEnemy)
        {
            i = Random.Range(0, enemies.Length);
        }
        lastEnemy = i;
        return Instantiate(enemies[i], enemyAnchor.transform);
    }

    public void BeginShootout() {
        SceneManager.LoadScene("FPS", LoadSceneMode.Additive);
        Scene FPSScene = SceneManager.GetSceneByName("FPS");
        Sprite oldSprite = _enemy.GetComponent<SpriteRenderer>().sprite;

        StartCoroutine(ShootoutStage2(FPSScene, oldSprite));
    }

    private IEnumerator ShootoutStage2(Scene FPSScene, Sprite oldSprite) {
        while (!FPSScene.isLoaded) { yield return null; }

        SceneManager.SetActiveScene(FPSScene);
        SceneManager.UnloadSceneAsync("MainWorld");

        GameObject ThreeDEnemy = GameObject.Find("Enemy");
        ThreeDEnemy.transform.Find("hackerman_0").GetComponent<SpriteRenderer>().sprite = oldSprite;
    }
}
