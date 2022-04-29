using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigibodyRotate : CharacterRotate
{
    private void FixedUpdate()
    {
        RotateCharacter();
    }
}