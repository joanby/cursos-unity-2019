using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CustomExtensions{
   
    public static class StringExtensions{

        public static void JuanGabrielDebug(this string str){
            Debug.LogFormat("La palabra {0} tiene {1} caracteres",
                      str, str.Length);
        }

    }




    public static class IntegerExtensions{

    }
}
