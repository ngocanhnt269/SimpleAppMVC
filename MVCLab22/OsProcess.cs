using System.Diagnostics;

namespace GlobalLibrary;

public class OsProcess
{
    public static Process[] GetProcessesOnMyComputer()
    {
        return Process.GetProcesses();
    }

    public static Process GetProcessByIdOnMyComputerById(int id)
    {
        return Process.GetProcessById(id);
    }

    public static object? GetProcessByIdOnMyComputerById(object id)
    {
        throw new NotImplementedException();
    }
}
