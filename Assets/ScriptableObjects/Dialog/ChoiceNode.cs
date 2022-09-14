using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ScriptableObjects.Dialog
{
    [CreateAssetMenu(menuName = "Dialog/Choice node")]
    public class ChoiceNode: ScriptableObject
    {
        public string Preview;

        public DialogNode NextNode;
    }
}
