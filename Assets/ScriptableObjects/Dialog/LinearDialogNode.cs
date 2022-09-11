using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.ScriptableObjects.Dialog
{
    public class LinearDialogNode : DialogNode
    {
        public DialogNode NextNode;

        public override void Visit(IDialogNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
