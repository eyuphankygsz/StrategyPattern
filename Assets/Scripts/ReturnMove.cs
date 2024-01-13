using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMove : IMovable
{
    Transform _boss;
    Vector3 _startPoint;
    public ReturnMove(Transform boss, Vector3 startPoint)
    {
        _boss = boss;
        _startPoint = startPoint;
    }
    public void Move()
    {
        _boss.position = Vector3.MoveTowards(_boss.position, _startPoint, 0.01f);
        if (Vector3.Distance(_boss.position, _startPoint) < 0.1)
        {
            _boss.position = _startPoint;
        }
    }
    public void ResetMove()
    {

    }
}
