using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFishState
{
	void UpdateState();

	void ToFloatingState();

	void ToEscapeState();

	void ToWinState();
}
