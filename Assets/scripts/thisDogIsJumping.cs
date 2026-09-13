using UnityEngine;

public class thisDogIsJumping : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Transform target;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) < 10f)
            {
                var AllRBys = FindObjectsByType<Rigidbody>();
                target = GetNearestAnkleToBiteOn(AllRBys);
            }
            _rigidBody.AddForce((target.position - transform.position).normalized * 5f);
        } else
        {
            target = GetNearestAnkleToBiteOn(FindObjectsByType<Rigidbody>());
        }
    }
    Transform GetNearestAnkleToBiteOn(Rigidbody[] enemies)
    {
        Vector3 currentPosition = transform.position;
        Transform testedClosestEnemy = null;
        float testedNearestDistance = Mathf.Infinity;
        foreach (var targetHit in enemies)
        {
            if (targetHit != _rigidBody)
            {
                float distance = Vector3.Distance(targetHit.transform.position, currentPosition);
                if (testedNearestDistance > distance)
                {
                    testedClosestEnemy = targetHit.transform;
                    testedNearestDistance = distance;
                }
            }
        }
        return testedClosestEnemy;

    }
}

