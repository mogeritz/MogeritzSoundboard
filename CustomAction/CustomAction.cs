using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CustomAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult InstallVM(Session session)
        {
            //File.WriteAllText(@"Y:\Projekte\Soundboard\MogeritzSoundboard\MogeritzSoundboard.Setup\bin\Debug\WriteText.txt", "Base");

            try
            {
                string strCmdText2;
                strCmdText2 = "Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1')); choco install voicemeeter -y; pause";
                runCmd(strCmdText2);

                //File.WriteAllText(@"Y:\Projekte\Soundboard\MogeritzSoundboard\MogeritzSoundboard.Setup\bin\Debug\WriteText.txt", retval);
            }
            catch (Exception e)
            {
                //File.WriteAllText(@"Y:\Projekte\Soundboard\MogeritzSoundboard\MogeritzSoundboard.Setup\bin\Debug\WriteText.txt", e.Message);
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult SetRegistry(Session session)
        {
            //File.WriteAllText(@"Y:\Projekte\Soundboard\MogeritzSoundboard\MogeritzSoundboard.Setup\bin\Debug\WriteText.txt", "Base");

            try
            {
                string strCmdText2;
                strCmdText2 = "Set-Location \"HKCU:\\VB-Audio\\Voicemeeter\"; Set-ItemProperty -path . -name \"SysTray\" -value \"1\"; New-Item \"HKCU:\" -Name \"VB-Audio\"; New-Item \"HKCU:\\VB-Audio\" -Name \"Voicemeeter\"; New-ItemProperty -path \"HKCU:\\VB-Audio\\Voicemeeter\" -name \"SysTray\" -value \"1\"; pause";
                runCmd(strCmdText2);

                //File.WriteAllText(@"Y:\Projekte\Soundboard\MogeritzSoundboard\MogeritzSoundboard.Setup\bin\Debug\WriteText.txt", retval);
            }
            catch (Exception e)
            {
                //File.WriteAllText(@"Y:\Projekte\Soundboard\MogeritzSoundboard\MogeritzSoundboard.Setup\bin\Debug\WriteText.txt", e.Message);
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }

        private static void runCmd(string command)
        {
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.RedirectStandardOutput = false;
            cmd.StartInfo.FileName = "powershell.exe";
            cmd.StartInfo.Arguments = command;
            cmd.StartInfo.Verb = "runas";
            cmd.Start();
            cmd.WaitForExit();
        }
    }
}
