using Assets.ScriptableObjects.Chanels;
using Assets.ScriptableObjects.Dialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : InteractableObject
{
    [SerializeField] private DialogChanel dialogChanel;
    [SerializeField] private Dialog dialog;

    protected override void Interact()
    {
        dialogChanel.RaiseDialogStart(dialog);
    }
}
