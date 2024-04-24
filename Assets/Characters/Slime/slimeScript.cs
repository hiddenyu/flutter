using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    public Transform target;
    public float slimeSpeed = 0.75f;
    public float minDist = 0.16f;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
		target = GameObject.FindWithTag ("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();

        transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, slimeSpeed * Time.deltaTime);

    }
}
