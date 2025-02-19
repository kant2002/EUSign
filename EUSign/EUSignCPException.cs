namespace EUSignCP;

public class EUSignCPException: System.Exception
{
    private int _errorCode;

    public EUSignCPException() : base() { }
    public EUSignCPException(
        string message) : base(message) { }
    public EUSignCPException(string message, 
        System.Exception inner) : base(message, inner) { }
    public EUSignCPException(int errorCode) 
    {
        _errorCode = errorCode;
    }
    public EUSignCPException(int errorCode,
        string message) : base (message)
    {
        _errorCode = errorCode;
    }

    public int errorCode 
    {
        get
        {
            return _errorCode;
        }
    }
}
