using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UseEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject[] MovePoint;
    [SerializeField]
    private GameObject[] Enemy;

    [Range(0, 5)]
    public float Speed = 2.0f;

    int endPoint = 0;
    // Start is called before the first frame update
    void Start()
    {

        this.transform.DOMove(MovePoint[endPoint].transform.position, Speed, false).OnComplete(() => NextMove());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void NextMove()
    {
        endPoint++;
        endPoint %=   MovePoint.Length;
        this.transform.DOMove(MovePoint[endPoint].transform.position, Speed, false).OnComplete(() => NextMove());
    }
}
