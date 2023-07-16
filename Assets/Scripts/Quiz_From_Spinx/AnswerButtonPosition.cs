using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="AnswerButtonPosition", menuName="Containers/AnswerButtonPosition", order=1)]
public class AnswerButtonPosition : ScriptableObject
{
    public Vector2[] PositionList;
    public Vector2[] RealPositionList;
}