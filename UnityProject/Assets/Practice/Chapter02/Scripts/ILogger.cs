using UnityEngine;

public interface ILogger
{
    void Log(string msg);
}

public class NullLogger : ILogger
{
    public void Log(string msg)
    {
        //不用做任何事
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string msg)
    {
        Debug.Log(msg);
    }
}
