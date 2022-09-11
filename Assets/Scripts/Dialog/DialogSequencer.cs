using Assets.ScriptableObjects.Dialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogSequencer
{
    public event Action<Dialog> OnDialogStart;
    public event Action<Dialog> OnDialogEnd;
    public event Action<DialogNode> OnNodeStart;
    public event Action<DialogNode> OnNodeEnd;

    private Dialog currentDialog;
    private DialogNode currentNode;

    public Dialog CurrentDialog => currentDialog;
    public DialogNode CurrentNode => currentNode;

    public void StartDialog(Dialog dialog)
    {
        currentDialog = dialog;
        currentNode = dialog.FirstNode;

        OnDialogStart?.Invoke(currentDialog);
        OnNodeStart?.Invoke(currentNode);
    }

    public void EndDialog(Dialog dialog)
    {
        currentDialog = null;
        OnDialogEnd?.Invoke(dialog);
    }

    public void StartNode(DialogNode node)
    {
        currentNode = node;
        OnNodeStart?.Invoke(node);
    }

    public void EndNode(DialogNode node)
    {
        currentNode = null;
        OnNodeEnd?.Invoke(node);
    }
}
