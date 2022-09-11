using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/Narration line")]
public class NarrationLine : ScriptableObject
{
    public NarrationCharacter Character;

    public string Text;
}
