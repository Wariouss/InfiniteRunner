using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.SCrpt
{
    public static class ListExtensions 
    {
        public static List<T> Shuffle<T>(this List<T> _list)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                T temp = _list[i];
                int randomIndex = Random.Range(i, _list.Count);
                _list[i] = _list[randomIndex];
                _list[randomIndex] = temp;
            }
            return _list;
        }
    }
}