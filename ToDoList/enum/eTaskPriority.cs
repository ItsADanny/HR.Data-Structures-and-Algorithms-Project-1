public enum eTaskPriority
{
    Low,
    Medium,
    High
}

public static class TaskPriority
{
    public static eTaskPriority FromInt(int value)
    {
        switch (value)
        {
            case 1:
                return eTaskPriority.Medium;
            case 2:
                return eTaskPriority.High;
            case 0: default:
                return eTaskPriority.Low;
        }
    }
}