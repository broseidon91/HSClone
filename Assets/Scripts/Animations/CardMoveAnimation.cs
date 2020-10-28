using System;
using UnityEngine;

public class CardMoveAnimation : AnimationEvent
{

    private Vector3 start;
    private Vector3 end;
    private GameObject behaviour;
    private float time = 0;
    private float animationTime = 0;
    
    public CardMoveAnimation(Guid guid) :base(guid)
    {

    }


    public override void OnEnd()
    {
        
    }

    public override void OnSetup(Data data)
    {
        start = data.Get<Vector3>("start");
        end = data.Get<Vector3>("end");
        behaviour = data.Get<GameObject>("behaviour");
        animationTime = data.Get<float>("animationTime");

    }

    public override void OnStart()
    {
        QueueNextEffect();
    }

    public override void OnUpdate()
    {
        time += Time.deltaTime;
        behaviour.transform.position = Vector3.Lerp(start, end, time / animationTime);

        if (time > animationTime)
        {
            EndAnimation();
        }
    }
}