using UnityEngine;

[CreateAssetMenu (fileName = "Leaf", menuName = "Leaves")]

public class LeafData : ScriptableObject
{
    public float FallSpeed;
    public float SwayAmp;
    public float SwayFreq;
    public int ScoreValue;
    public Color LeafColor;
}
