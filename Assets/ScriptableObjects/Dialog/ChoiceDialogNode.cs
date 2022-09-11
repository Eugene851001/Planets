using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ScriptableObjects.Dialog
{
    [CreateAssetMenu(menuName = "Dialog/Choice dialog node")]
    public class ChoiceDialogNode: DialogNode
    {
        public ChoiceNode[] Choices;

        public override void Visit(IDialogNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
