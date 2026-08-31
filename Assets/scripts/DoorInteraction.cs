using UnityEngine;

public class DoorInteraction : MonoBehaviour, IIinteractable
{
    Animator anim;
    bool opened;
    void Start()
    {
        anim = GameObject.Find("Door").GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Interact()
    {
        if (!opened) anim.SetTrigger("Open");
        else anim.SetTrigger("Close");
        opened = !opened;
    }
}
