using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Execute();
    void Stop();
    void SetHand(Transform hand);
    void SetOwner(GameObject owner);
}
