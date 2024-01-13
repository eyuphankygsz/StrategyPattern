using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : IMovable
{
    Transform _boss,_rotater;
    Vector3 _startPoint;
    Vector3 _endPoint;
    bool arrived;
    public CircleMove(Transform rotater, Transform boss, Vector3 startPoint)
    {
        _rotater = rotater;
        _boss = boss;
        _startPoint = startPoint;
        _endPoint = startPoint;
        _endPoint.y = 2;
    }
    public void Move()
    {
        if(!arrived)
        {
            _boss.position = Vector3.MoveTowards(_boss.position, _endPoint, 0.02f);
            if (Vector3.Distance(_boss.position,_endPoint) < 0.1f)
            {
                arrived = true;
            }
        }
        else
        {
            _rotater.Rotate(0,0,145 * Time.deltaTime);
        }
    }
    public void ResetMove()
    {
        _rotater.rotation = Quaternion.identity;
        arrived = false;
    }

}
