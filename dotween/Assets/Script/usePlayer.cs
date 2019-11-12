using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class usePlayer : MonoBehaviour
{
    public Collider[] hitColliders;
    private bool CheckOverlap;

    [Range(0, 10)]
    public float Radius;
    [Range(0, 5)]
    public float Speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObjectDetect();
        FollowMove();
    }

    private void ObjectDetect()
    {
        hitColliders = Physics.OverlapSphere(transform.position, Radius, 1 << 9);
        CheckOverlap = Physics.CheckSphere(transform.position, Radius, 1 << 9);
    }

    private void FollowMove()
    {
        if (CheckOverlap)
        {
            this.transform.DOMove(hitColliders[0].transform.position, Speed, false);
        }

        else
        {
            this.transform.DOMove(transform.position, 0, false);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
