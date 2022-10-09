using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interactable
{
    protected override void Interact()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
