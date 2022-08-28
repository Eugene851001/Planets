using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThinker
{
    Enemy Context { get; set; }

    void Think();
}
