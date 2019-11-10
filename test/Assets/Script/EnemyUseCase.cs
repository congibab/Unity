using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class EnemyUseCase : MonoBehaviour
{
    //  巡回ポイント
    [SerializeField]
    private List<Transform> _movePoints = new List<Transform>();
    [SerializeField]
    private List<Transform> _PlayermovePoints = new List<Transform>();

    GameObject obj;

    private int _startPosition = 0;
    private int _endPosition = 0;
    bool PreCheckOverlap = false;
    bool CheckOverlap;
    public Collider[] hitColliders;


    [Range(0, 10)]
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayermovePoints(_movePoints);

        _endPosition = 1;
        this.transform.DOMove(_PlayermovePoints[_endPosition].localPosition, 1.0f, false)
            .SetEase(Ease.InOutSine)
            .OnComplete(() => NextLoop());
    }

    void Update()
    {
        ObjectDetect();
    }

    private void NextLoop()
    {
        _endPosition++;
        _endPosition %= _PlayermovePoints.Count;

        
        this.transform.DOMove(_PlayermovePoints[_endPosition].localPosition, 1.0f, false)
            //.SetEase(Ease.InOutSine)
            //.SetEase(Ease.OutBounce)
            .OnComplete(() => NextLoop());
    }

    private void ObjectDetect()
    {
        hitColliders = Physics.OverlapSphere(transform.position, radius, 1 << 8);
        CheckOverlap = Physics.CheckSphere(transform.position, radius, 1 << 8);

        Debug.Log(hitColliders.Length);
        if (CheckOverlap != PreCheckOverlap && CheckOverlap == true)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                _PlayermovePoints.Insert(_endPosition, hitColliders[i].transform);

            }
            // obj = GameObject.Find(hitColliders[i].name);
        }

         PreCheckOverlap = CheckOverlap;
    }

  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void SetPlayermovePoints(List<Transform> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            _PlayermovePoints.Add(list[i]);
        }
    }

    

}
    