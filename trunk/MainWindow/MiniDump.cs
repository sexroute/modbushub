using System;
using System.Collections.Generic;

using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using EricZhao.UiThread;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace EricZhao
{
    public static class MiniDump

    {
        [DllImport("kernel32.dll")]
        private static extern int SetErrorMode(int newMode);

        [DllImport("kernel32.dll")]
        public  static extern void ExitProcess(uint uExitCode);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        public static void TerminateProcess()
        {
            TerminateProcess(Process.GetCurrentProcess().Handle, 1);
        }

        public class ErrorModes
        {
            public static int Default = 0x0,
             FailCriticalErrors = 0x1,
             NoGpFaultErrorBox = 0x2, // &lt;- this is the one we need
             NoAlignmentFaultExcept = 0x4,
             NoOpenFileErrorBox = 0x8000;
        }


        static Mutex m_oMutex = null;
        static Mutex m_oMutex2 = null;

        public static Boolean IsAlreadyInstanceStart()
        {
            try
            {
                String lstrPath = Application.StartupPath;
                byte[] loResult = Encoding.Default.GetBytes(lstrPath);
                System.Security.Cryptography.MD5 loMd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] loOutput = loMd5.ComputeHash(loResult);
                String lstrMD5 = BitConverter.ToString(loOutput).Replace("-", "");
                m_oMutex = new Mutex(true, lstrMD5);

                if (m_oMutex.WaitOne(TimeSpan.Zero, true))
                {
                    lstrPath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                    loResult = Encoding.Default.GetBytes(lstrPath);
                    loMd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    loOutput = loMd5.ComputeHash(loResult);
                    lstrMD5 = BitConverter.ToString(loOutput).Replace("-", "");
                    m_oMutex2 = new Mutex(true, lstrMD5);
                    if (m_oMutex.WaitOne(TimeSpan.Zero, true))
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {

            }
            finally
            {

            }

            return true;

        }

        public static void HandleBiz(object sender, Exception ex)
        {
            try
            {

                ThreadUiController.log(ex.ToString(), ThreadUiController.LOG_LEVEL.FATAL);


                /*  string fileName = "./" + System.AppDomain.CurrentDomain.FriendlyName + ".mdmp";

                  using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.Write))
                  {

                      MiniDump.Write(fs.SafeFileHandle, MiniDump.Option.WithFullMemory);
                  }*/
            }
            catch (Exception e2)
            {
                ThreadUiController.log(e2.ToString(), ThreadUiController.LOG_LEVEL.FATAL);
            }

            TerminateProcess(Process.GetCurrentProcess().Handle, 1);
        }
       public static void UnhandledException(object sender,UnhandledExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = (Exception)e.ExceptionObject;
            HandleBiz(sender,ex);
        }

        private static void UnhandledThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = (Exception)e.Exception;
            HandleBiz(sender, ex);
        }

        public static void RegistUnhandledExceptionHandler()
        {
            SetErrorMode(ErrorModes.FailCriticalErrors | ErrorModes.NoGpFaultErrorBox | ErrorModes.NoOpenFileErrorBox);

            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
            Application.ThreadException += new ThreadExceptionEventHandler(UnhandledThreadException);

        }

        [Flags]

        public enum Option : uint

        {

            // From dbghelp.h:

            Normal = 0x00000000,

            WithDataSegs = 0x00000001,

            WithFullMemory = 0x00000002,

            WithHandleData = 0x00000004,

            FilterMemory = 0x00000008,

            ScanMemory = 0x00000010,

            WithUnloadedModules = 0x00000020,

            WithIndirectlyReferencedMemory = 0x00000040,

            FilterModulePaths = 0x00000080,

            WithProcessThreadData = 0x00000100,

            WithPrivateReadWriteMemory = 0x00000200,

            WithoutOptionalData = 0x00000400,

            WithFullMemoryInfo = 0x00000800,

            WithThreadInfo = 0x00001000,

            WithCodeSegs = 0x00002000,

            WithoutAuxiliaryState = 0x00004000,

            WithFullAuxiliaryState = 0x00008000,

            WithPrivateWriteCopyMemory = 0x00010000,

            IgnoreInaccessibleMemory = 0x00020000,

            ValidTypeFlags = 0x0003ffff,

        };



        public enum ExceptionInfo

        {

            None,

            Present

        }



        //typedef struct _MINIDUMP_EXCEPTION_INFORMATION {

        //    DWORD ThreadId;

        //    PEXCEPTION_POINTERS ExceptionPointers;

        //    BOOL ClientPointers;

        //} MINIDUMP_EXCEPTION_INFORMATION, *PMINIDUMP_EXCEPTION_INFORMATION;

        [StructLayout(LayoutKind.Sequential, Pack = 4)]  // Pack=4 is important! So it works also for x64!

        public struct MiniDumpExceptionInformation

        {

            public uint ThreadId;

            public IntPtr ExceptionPointers;

            [MarshalAs(UnmanagedType.Bool)]

            public bool ClientPointers;

        }



        //BOOL

        //WINAPI

        //MiniDumpWriteDump(

        //    __in HANDLE hProcess,

        //    __in DWORD ProcessId,

        //    __in HANDLE hFile,

        //    __in MINIDUMP_TYPE DumpType,

        //    __in_opt PMINIDUMP_EXCEPTION_INFORMATION ExceptionParam,

        //    __in_opt PMINIDUMP_USER_STREAM_INFORMATION UserStreamParam,

        //    __in_opt PMINIDUMP_CALLBACK_INFORMATION CallbackParam

        //    );



        // Overload requiring MiniDumpExceptionInformation

        [DllImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]

        static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, SafeHandle hFile, uint dumpType, ref MiniDumpExceptionInformation expParam, IntPtr userStreamParam, IntPtr callbackParam);



        // Overload supporting MiniDumpExceptionInformation == NULL

        [DllImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]

        static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, SafeHandle hFile, uint dumpType, IntPtr expParam, IntPtr userStreamParam, IntPtr callbackParam);



        [DllImport("kernel32.dll", EntryPoint = "GetCurrentThreadId", ExactSpelling = true)]

        static extern uint GetCurrentThreadId();



        public static bool Write(SafeHandle fileHandle, Option options, ExceptionInfo exceptionInfo)

        {

            Process currentProcess = Process.GetCurrentProcess();

            IntPtr currentProcessHandle = currentProcess.Handle;

            uint currentProcessId = (uint)currentProcess.Id;

            MiniDumpExceptionInformation exp;

            exp.ThreadId = GetCurrentThreadId();

            exp.ClientPointers = false;

            exp.ExceptionPointers = IntPtr.Zero;

            if (exceptionInfo == ExceptionInfo.Present)

            {

                exp.ExceptionPointers = System.Runtime.InteropServices.Marshal.GetExceptionPointers();

            }

            bool bRet = false;

            if (exp.ExceptionPointers == IntPtr.Zero)

            {

                bRet = MiniDumpWriteDump(currentProcessHandle, currentProcessId, fileHandle, (uint)options, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            }

            else

            {

                bRet = MiniDumpWriteDump(currentProcessHandle, currentProcessId, fileHandle, (uint)options, ref exp, IntPtr.Zero, IntPtr.Zero);

            }

            return bRet;

        }



        public static bool Write(SafeHandle fileHandle, Option dumpType)

        {

            return Write(fileHandle, dumpType, ExceptionInfo.None);

        }

    }
}
