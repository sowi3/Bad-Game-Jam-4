using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

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
        print(enemyHealth);
        if (enemyHealth <= 0) EndBattle();
    }

    public void DamagePlayer(int value) {
        playerHealth -= value;
        print(playerHealth);
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
}
