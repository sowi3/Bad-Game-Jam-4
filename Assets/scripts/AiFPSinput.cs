using System.Collections;
using UnityEngine;

public class AiFPSinput : MonoBehaviour
{
    public FPSMovementScript fuck;
    private Transform aimTarget;
    private Vector3 moveTarget;
    private States state;

    public GameObject popup;

    private enum States
    {

        Idle,
        Wander,
        Aggro,
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = States.Idle;
    }

    // Update is called once per frame


    void FixedUpdate()
    {
        if (scanning != false)
        {
        }
        else
        {
            StartCoroutine(ScanForEnemy());
        }
        
        //useless code but im keeping it in cause lowkey why touch it if it works
        //and 10 other awesome programming tips #supscripbe
        switch (state)
        {
            case States.Idle:
                FindSomewhereToWalkTo();
                state = States.Wander;
                break;
            case States.Wander:

                break;
            case States.Aggro:
                break;
        }
        if (aimTarget != null)
        {

            Vector3 targetDir = aimTarget.position - transform.position;
            Vector3 aimTargetPos = aimTarget.position;
            targetDir.y = 0;
            aimTargetPos.y = 0;
            float curAngle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);
            if (curAngle > 1)
            {
                fuck.Rotate(-1 * Time.fixedDeltaTime);
            } else if ( curAngle < -1)
            {
                fuck.Rotate(1 * Time.fixedDeltaTime);
            } else
            {
                fuck.Shoot();
            }
            float curDistance = Vector3.Distance(transform.position, aimTargetPos);
            if (curDistance > 30)
            {
                fuck.Move(1 * Time.fixedDeltaTime);
            } else if (curDistance < 20)
            {
                fuck.Move(-1 * Time.fixedDeltaTime);
            }
        }
    }

//Also useless code 
//ignore pls
    void FindSomewhereToWalkTo()
    {
        Vector3 target = new Vector3(0,0,0);
        target.x = Random.Range(-10f,10f);
        target.z = Random.Range(-10f,10f);
        moveTarget = target + transform.position;
    }

    bool scanning;
    IEnumerator ScanForEnemy()
    {
        scanning = true;
        state = States.Wander;
        GameObject[] allValidTargets = GameObject.FindGameObjectsWithTag("AIKillTarget");
        aimTarget = GetNearestEnemy(allValidTargets);

        yield return new WaitForSeconds(2);
        scanning = false;
    }

    const float maxViewDistance = 60f;

    Transform GetNearestEnemy(GameObject[] enemies)
    {
        Vector3 currentPosition = transform.position;
        Transform testedClosestEnemy = null;
        float testedNearestDistance = maxViewDistance;
        foreach (var targetHit in enemies)
        {
            float distance = Vector3.Distance(targetHit.transform.position, currentPosition);
            if (testedNearestDistance > distance)
            {
                testedClosestEnemy = targetHit.transform;
                testedNearestDistance = distance;
            }
        }
        return testedClosestEnemy;
    }

    void OnDestroy()
    {
        Instantiate(popup, transform.position, Quaternion.identity);
    }
}
