using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AK.Wwise.Event SoundEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SoundEvent.Post(gameObject);
        }
    }
}
