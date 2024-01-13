using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class LinearMove : IMovable
{

    bool right = true;
    float speed = 3;
    Vector3 _startPos;
    float end;
    Transform _boss;
    public LinearMove(Transform boss,Vector3 startPos)
    {
        _boss = boss;
        _startPos = startPos;
    }
    public void Move()
    {

        if (right)
        {
            _boss.transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (_boss.position.x >= end)
            {
                end = _startPos.x - 4;
                right = false;
            }
        }
        else
        {
            _boss.transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (_boss.position.x <= end)
            {
                end = _startPos.x + 4;
                right = true;
            }

        }
    }
    public void ResetMove()
    {
        right = true;
        end = _startPos.x + 4;
    }

}
