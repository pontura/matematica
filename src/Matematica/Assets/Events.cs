using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {

	//public static System.Action<UIButton> OnButtonClickd = delegate { };	

	public static System.Action NextExercise = delegate { };

	public static System.Action AddScore = delegate { };
	public static System.Action BadAnswer = delegate { };

	public static System.Action<int> AreaChange = delegate { };
	public static System.Action<int> SubAreaChange = delegate { };

}
