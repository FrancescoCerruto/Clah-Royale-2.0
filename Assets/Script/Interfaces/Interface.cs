using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Killed<T>
{
  void Kill();
  void Hit(T damageTaken);
}

