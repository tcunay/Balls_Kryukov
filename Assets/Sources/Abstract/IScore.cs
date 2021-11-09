using System;

namespace Sources.Abstract
{
    public interface IScore
    {
        event Action ScoreChanged;
        int Score { get; }
    }
}