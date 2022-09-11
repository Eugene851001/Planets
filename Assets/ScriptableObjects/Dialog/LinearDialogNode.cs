using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ScriptableObjects.Dialog
{
    [CreateAssetMenu(menuName = "Dialog/Linear dialog node")]
    public class LinearDialogNode : DialogNode
    {
        public DialogNode NextNode;

        public override void Visit(IDialogNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
