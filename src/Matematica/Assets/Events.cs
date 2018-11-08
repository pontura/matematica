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

	public static System.Action<int> LevelSelectorUpdate = delegate { };
	public static System.Action<bool> ShowLevelSelector = delegate { };

	public static System.Action NextDialog = delegate { };

	public static System.Action AllAreasCompleted = delegate { };

	public static System.Action<int> AddStar = delegate { };

	public static System.Action<int> ReplayArea = delegate { };
}
