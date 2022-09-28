using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtgDev.Voicemeeter;
using AtgDev.Voicemeeter.Utils;
using Definitions;

namespace MogeritzSoundboardGUI
{
    internal class VMInterface
    {
        RemoteApiWrapper vmrapi;

        public VMInterface()
        {
            vmrapi = new RemoteApiWrapper(PathHelper.GetDllPath());

            DataContainer.Instance.DevicesChanged += DevicesChangedHandler;

            if(vmrapi.Login() == 1)
            {
                vmrapi.RunVoicemeeter(1);
                Thread.Sleep(1000);

                int i = vmrapi.IsParametersDirty();
                i += vmrapi.MacroButtonIsDirty();

                InitVM();
            }
            else
            {
                MessageBox.Show("fool,idiot,moron");
            }
        }

        private void DevicesChangedHandler(object sender, EventArgs e)
        {
            string inputdevice = String.Empty;
            for(int i = 0; i < vmrapi.GetInputDevicesNumber(); i++)
            {
                string _inputdevice = "";
                vmrapi.GetInputDeviceDescriptor(i, out _, out _inputdevice, out _);
                if (_inputdevice.Contains(DataContainer.Instance.InputDevice)) inputdevice = _inputdevice;
            }

            string outdevice = String.Empty;
            for (int i = 0; i < vmrapi.GetOutputDevicesNumber(); i++)
            {
                string _outdevice = "";
                vmrapi.GetOutputDeviceDescriptor(i, out _, out _outdevice, out _);
                if (_outdevice.Contains(DataContainer.Instance.OutputDevice)) outdevice = _outdevice;
            }

            if (inputdevice != String.Empty) vmrapi.SetParameter("Strip[0].Device.mme", inputdevice);
            if (outdevice != String.Empty) vmrapi.SetParameter("Bus[0].Device.mme", outdevice);
        }

        private void InitVM()
        {
            vmrapi.SetParameter("Strip[0].B1", 1);
            vmrapi.SetParameter("Strip[0].A1", 0);
            vmrapi.SetParameter("Strip[2].B1", 1);
            vmrapi.SetParameter("Strip[2].A1", 1);
        }

        ~VMInterface()
        {
            vmrapi.Logout();
        }
    }
}
