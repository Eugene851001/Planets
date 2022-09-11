using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.ScriptableObjects.Dialog
{
    public interface IDialogNodeVisitor
    {
        void Visit(ChoiceDialogNode node);

        void Visit(LinearDialogNode node);
    }
}
