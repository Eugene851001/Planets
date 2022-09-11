using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ScriptableObjects.Dialog
{
    [CreateAssetMenu(menuName = "Dialog/Index")]
    public class Dialog: ScriptableObject
    {
        public DialogNode FirstNode;
    }
}
