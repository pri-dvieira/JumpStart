using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestePDEX
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolvePDEX);

            Application.Run(new Form1());
        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string assemblyFullName;

            System.Reflection.AssemblyName assemblyName;

            const string PRIMAVERA_FOLDER = "PRIMAVERA\\SG100\\Apl";

            assemblyName = new System.Reflection.AssemblyName(args.Name);
            assemblyFullName = System.IO.Path.Combine(System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), PRIMAVERA_FOLDER), assemblyName.Name + ".dll");

            if (System.IO.File.Exists(assemblyFullName))
                //return System.Reflection.Assembly.LoadFile(assemblyFullName);
                return System.Reflection.Assembly.LoadFrom(assemblyFullName);
            else
                return null;
        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolvePDEX(object sender, ResolveEventArgs args)
        {
            string assemblyFullName;

            System.Reflection.AssemblyName assemblyName;

            const string PRIMAVERA_FOLDER = "PRIMAVERA\\SG100\\Apl\\PDEX";

            assemblyName = new System.Reflection.AssemblyName(args.Name);
            assemblyFullName = System.IO.Path.Combine(System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), PRIMAVERA_FOLDER), assemblyName.Name + ".dll");

            if (System.IO.File.Exists(assemblyFullName))
                //return System.Reflection.Assembly.LoadFile(assemblyFullName);
                return System.Reflection.Assembly.LoadFrom(assemblyFullName);
            else
                return null;
        }
    }
}
