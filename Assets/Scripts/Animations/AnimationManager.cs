using System.Collections.Generic;
using System.Linq;

public class AnimationManager : IUpdate
{
    public static AnimationManager Instance;

    public delegate void AnimationEndDelegate(AnimationEvent e);

    private List<AnimationEvent> activeAnimations = new List<AnimationEvent>();
    private List<AnimationEvent> queuedAnimations = new List<AnimationEvent>();
    private List<AnimationEvent> removedAnimations = new List<AnimationEvent>();

    public AnimationManager()
    {
        Instance = this;
    }

    public void AddEvent(AnimationEvent animEvent)
    {

        queuedAnimations.Add(animEvent);
        animEvent.onQueueNextEffect += HandleQueueNextEvent;
    }


    private void HandleEventFinished(AnimationEvent e)
    {
        removedAnimations.Add(e);
    }

    private void HandleQueueNextEvent(AnimationEvent e)
    {
        QueueNextEvent();
    }

    public void QueueNextEvent()
    {
        if (queuedAnimations.Count > 0)
        {
            var queued = queuedAnimations[queuedAnimations.Count - 1];
            queuedAnimations.Remove(queued);
            activeAnimations.Add(queued);
            queued.OnStart();
            queued.onAnimationEnd += HandleEventFinished;
        }
    }

    public void Update()
    {

        foreach (var removed in removedAnimations)
        {
            activeAnimations.Remove(removed);
            removed.onAnimationEnd -= HandleEventFinished;
        }

        removedAnimations = new List<AnimationEvent>();


        foreach (var active in activeAnimations)
        {
            active.OnUpdate();
        }


    }
}