using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.ScriptableObjects.Dialog
{
    public class ChoiceDialogNode: DialogNode
    {
        public ChoiceNode[] Choices;

        public override void Visit(IDialogNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
