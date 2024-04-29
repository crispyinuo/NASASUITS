using UnityEngine;

[CreateAssetMenu(fileName = "UserPositionData", menuName = "ScriptableObjects/UserPositionData", order = 1)]
public class UserPositionData : ScriptableObject
{
    public System.Collections.Generic.List<Vector3> positions;
}
