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

    [Header("Events")]
    public GameEvent clientMoved;

    [Header("State")]
    public bool HasEnteredBar = false;

    private Action<BarOrder> spawnCluesAction = null;

    public void EnterBar(Action<BarOrder> onEnteredBar = null)
    {
        spawnCluesAction = onEnteredBar;
        
        order = new BarOrder(generateRandom: true);
        animator.SetTrigger(CharacterInTrigger);
        clientMoved.Raise();
        HasEnteredBar = true;
    }

    public bool ServeOrder(BarOrder servedOrder)
    {
        return order.IsFulfilled(servedOrder);
    }

    public void LeaveBar()
    {
        animator.SetTrigger(CharacterOutTrigger);
        clientMoved.Raise();
    }

    public void StartSpawningClues()
    {
        spawnCluesAction?.Invoke(order);
    }

    // Run by animatin event after leaving
    public void MarkClientLeftTheBar()
    {
        HasEnteredBar = false;
    }
}
