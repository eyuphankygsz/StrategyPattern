using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossControll : MonoBehaviour
{
    [SerializeField] IMovable moveBehavior;
    public List<IMovable> movables;
    int counter;
    Vector3 startPos;
    //Only for show
    public TextMeshProUGUI txt;
    void Start()
    {
        counter = 0;
        startPos = transform.position;

        movables = new List<IMovable>
        {
            new LinearMove(transform, startPos),
            new ReturnMove(transform,startPos),
            new StopMove(),
            new CircleMove(transform.parent,transform, startPos),
            new ReturnMove(transform,startPos)
        };

        StartCoroutine(ChangeBehaviour());
    }


    IEnumerator ChangeBehaviour()
    {
        if (moveBehavior != null)
        moveBehavior.ResetMove();
       
        txt.text = "Strategy:\n" + movables[counter];
        moveBehavior = movables[counter];
        counter = (counter + 1) == 5 ? 0 : counter + 1;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeBehaviour());
    }
    // Update is called once per frame
    void Update()
    {
        moveBehavior?.Move();
    }
}
