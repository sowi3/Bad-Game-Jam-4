using UnityEngine;

public class popupsript : MonoBehaviour
{
    Transform target;
    public AudioSource yayyyyy;
    bool yayplayed;

    //im tired
    void Start()
    {
        target = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position + target.forward * -0.6f + target.up * 0.4f;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 1 * Time.deltaTime);
        if (transform.position == targetPos)
        {
            if (!yayplayed)
            {
                yayyyyy.Play();
                yayplayed = true;
            }
        } else {
            yayplayed = false;
        }
    }
}