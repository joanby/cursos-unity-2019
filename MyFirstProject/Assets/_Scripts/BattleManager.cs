using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseManager
{ 

    // De regalo tengo acceso a la variable _state,
    // pues esta era protegida en el padre
    public override string State{
        get { return _state;}
        set { _state = value;}
    }

    public override void Initialize(){
        _state = "Manager Inicializado";
        Debug.Log(_state);
    }
}
