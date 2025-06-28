

namespace DO;
[Serializable]
public class DalIdAllreadyExists : Exception
{
    public DalIdAllreadyExists(String message) : base(message)
    {
        throw new Exception($"error: {message}");
    }
}

[Serializable]
public class DalWriteToXmlExeption : Exception
{
    public DalWriteToXmlExeption(String type)
    {
        throw new Exception($"error in write to xml - {type}");
    }
}


[Serializable]
public class DalReadFromXmlExeption : Exception
{
    public DalReadFromXmlExeption(String type)
    {
        throw new Exception($"error in read from xml - {type}");
    }
}




[Serializable]
public class DalIdNotFoundException : Exception
{
    public DalIdNotFoundException(string message) :base(message)
    {
        throw new Exception($"error: {message}");
    }
}

[Serializable]
public class DalNullObjectExeption : Exception
{
    public DalNullObjectExeption(String type)
    {
        throw new Exception($"null recived - {type}");
    }
}

[Serializable]
public class DalGeneralExeption : Exception
{
    public DalGeneralExeption(String type, String nameFunc)
    {
        throw new Exception($"error in - {type} in function: {nameFunc}");
    }
}

[Serializable]
public class DalIdNotExistExeption : Exception
{
    public DalIdNotExistExeption(String type)
    {
        throw new Exception($"id does not exist - {type}");
    }
}