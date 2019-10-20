using System;
using System.Runtime.Serialization;

namespace GameEngine
{
    
    public enum CellState
    {
        [EnumMember(Value = "Empty")]
        Empty,
        [EnumMember(Value = "Blue")]
        B,
        [EnumMember(Value = "Red")]
        R
    };
    
}