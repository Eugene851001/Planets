using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.ScriptableObjects.Dialog
{
    public abstract class DialogNode: ScriptableObject
    {
        public NarrationLine Line;

        public abstract void Visit(IDialogNodeVisitor visitor);
    }
}
