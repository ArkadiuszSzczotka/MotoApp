using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Services;

public interface IUserCommunication
{
    void ChooseAction();
    void WriteColorLine(string message, ConsoleColor color);
}
