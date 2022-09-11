using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;
using UnityEngine.Events;
using Assets.ScriptableObjects.Dialog;

namespace Assets.ScriptableObjects.Chanels
{
    public class DialogChanel: ScriptableObject
    {
        public event Action<Dialog.Dialog> OnDialogStart;
        public event Action<Dialog.Dialog> OnDialogEnd;

        public event Action<DialogNode> OnNodeRequest;
        public event Action<DialogNode> OnNodeStart;
        public event Action<DialogNode> OnNodeEnd;

        public void RaiseDialogStart(Dialog.Dialog dialog)
        {
            OnDialogStart?.Invoke(dialog);
        }

        public void RaiseDialogEnd(Dialog.Dialog dialog)
        {
            OnDialogEnd?.Invoke(dialog);
        }

        public void RaiseRequestNode(DialogNode node)
        {
            OnNodeRequest?.Invoke(node);
        }

        public void RaiseNodeStart(DialogNode node)
        {
            OnNodeStart?.Invoke(node);
        }

        public void RaiseNodEnd(DialogNode node)
        {
            OnNodeEnd?.Invoke(node);
        }
    }
}
