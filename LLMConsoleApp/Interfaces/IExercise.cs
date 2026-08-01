using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLMConsoleApp.Interfaces
{
    public interface IExercise
    {
        string Name { get; }
        Task RunAsync();
    }
}
