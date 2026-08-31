using UnityEngine;

public class Chestinteraction : MonoBehaviour, IIinteractable
{
    Animator anim;
    bool opened;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    public void Interact()
    {
        if (!opened) anim.SetTrigger("Open");
        else anim.SetTrigger("Close");
        opened = !opened;
    }

}
