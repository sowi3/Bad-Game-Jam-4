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
   }
    public void MakeShit() {
        GameObject _shit = Instantiate(shit, transform);
        Destroy(_shit, 2);
    }

    // Actor Control

    public void DamageBro(int value) {
        enemyHealth -= value;
    }

    public void DamagePlayer(int value) {
        playerHealth -= value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    GameObject SpawnRandomEnemy() {
        int i = Random.Range(0, enemies.Length);
        return Instantiate(enemies[i], enemyAnchor.transform);
    }
}
