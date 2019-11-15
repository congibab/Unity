using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UseEnemy : MonoBehaviour
{
    public Collider[] hitColliders;
    private bool CheckOverlap;

    [SerializeField]
    private GameObject[] MovePoint;
    [SerializeField]
    private GameObject[] Enemy;

    [Range(0, 5)]
    public float Speed = 2.0f;

    [Range(0, 10)]
    public float Radius;

    int endPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOMove(MovePoint[endPoint].transform.position, Speed, false).OnComplete(() => NextMove());
    }

    // Update is called once per frame
    void Update()
    {
        ObjectDetect();
        FollowMove();
    }

    void NextMove()
    {
        endPoint++;
        endPoint %=   MovePoint.Length;
        this.transform.DOMove(MovePoint[endPoint].transform.position, Speed, false).OnComplete(() => NextMove());
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
            //this.transform.DOMove(MovePoint[endPoint].transform.position, Speed, false).OnComplete(() => NextMove());
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
