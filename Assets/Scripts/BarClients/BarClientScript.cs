using System;
using UnityEngine;

public class BarClientScript : MonoBehaviour
{
    public BarOrder order;
    public SpriteRenderer spriteRenderer;
    
    [Header("Animation")]
    public Animator animator;
    public string CharacterInTrigger = "ComeIn";
    public string CharacterOutTrigger = "GoAway";

    [Header("State")]
    public bool clientIsWaiting = false;
    public bool isDoneWaiting = false;

    public Action OnClientLeft = null;
    public Action OnClientIsDoneWaiting = null;

    private Action<BarOrder> spawnCluesAction = null;
    private Action despawnCluesAction = null;

    [Space]
    public float timeToStayInBar = 3f;
    public float timeRemaining;

    void Update()
    {
        if (!clientIsWaiting)
        {
            return;
        }

        if (timeRemaining <= 0f)
        {
            timeRemaining = timeToStayInBar;
            isDoneWaiting = true;
            OnClientIsDoneWaiting?.Invoke();
            return;
        }

        timeRemaining -= Time.deltaTime;
    }

    public void EnterBar(Action<BarOrder> onEnteredBar = null, Action onLeftBar = null)
    {
        if (clientIsWaiting)
        {
            return;
        }

        clientIsWaiting = true;

        spawnCluesAction = onEnteredBar;
        despawnCluesAction = onLeftBar;
        
        order = new BarOrder(generateRandom: true);
        animator.SetTrigger(CharacterInTrigger);

        timeRemaining = timeToStayInBar;
        isDoneWaiting = false;
    }

    // public bool ServeOrder(BarOrder servedOrder)
    // {
    //     return order.IsFulfilled(servedOrder);
    // }

    public void LeaveBar()
    {
        despawnCluesAction?.Invoke();
        animator.SetTrigger(CharacterOutTrigger);
    }

    public void StartSpawningClues()
    {
        spawnCluesAction?.Invoke(order);
    }

    // Run by animatin event after leaving
    public void MarkClientLeftTheBar()
    {        
        clientIsWaiting = false;
        OnClientLeft?.Invoke();
    }
}
