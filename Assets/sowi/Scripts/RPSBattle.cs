using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class RPSBattle : MonoBehaviour
{
    public GameObject shit;
    public GameObject enemy;
    public GameObject enemyAnchor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(enemy, enemyAnchor.transform);
    }

    public void MakeShit() {
        GameObject _shit = Instantiate(shit, transform);
        Destroy(_shit, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
    public void ButtonClickEvent(int input)
    {
        //這是一個測試函數，用來向朋友示範如何操作按鈕和介面。What does this mean??
        Destroy(gameObject);
        Debug.Log(input);
    }
}
