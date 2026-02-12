public enum eTaskStatus
{
    ToDo,
    Doing,
    Review,
    Complete
}

public static class TaskStatus {
    public static eTaskStatus FromInt(int status)
    {
        switch (status)
        {
            case 1:
                return eTaskStatus.Doing;
            case 2:
                return eTaskStatus.Review;
            case 3:
                return eTaskStatus.Complete;
            case 0: default:
                return eTaskStatus.ToDo;
        }
    }

    public static eTaskStatus NextState(eTaskStatus status)
    {
        if (((int) status) + 1 <= 3)
        {
            switch (status)
            {
                case eTaskStatus.ToDo:
                    return eTaskStatus.Doing;
                case eTaskStatus.Doing:
                    return eTaskStatus.Review;
                case eTaskStatus.Review:
                    return eTaskStatus.Complete;
            }
        }
        return status;
    }

    public static eTaskStatus PrevState(eTaskStatus status)
    {
        if (((int) status) - 1 >= 0)
        {
            switch (status)
            {
                case eTaskStatus.Complete:
                    return eTaskStatus.Review;
                case eTaskStatus.Review:
                    return eTaskStatus.Doing;
                case eTaskStatus.Doing:
                    return eTaskStatus.ToDo;
            }
        }
        return status;
    }
}