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
	public static System.Action<bool> ShowLevelMenu = delegate { };
    public static System.Action<string> SetTitleDenom = delegate { };
    public static System.Action<string> SetTitleDenomUp = delegate { };
    public static System.Action<string> SetTitleDenomDown = delegate { };
    public static System.Action<string> SetPeriodicTitle = delegate { };
    
    public static System.Action<int,int> SetOp2A = delegate { };
    public static System.Action<int, int> SetOp2B = delegate { };
    public static System.Action<int, int, int, int, int, int, int> SetOp2C = delegate { };

    public static System.Action NextDialog = delegate { };

	public static System.Action AllAreasCompleted = delegate { };

	public static System.Action<int> AddStar = delegate { };

	public static System.Action<int> ReplayArea = delegate { };

	public static System.Action<bool> KunakSfx = delegate { };

    public static System.Action ResetRecorrido = delegate { };
}
