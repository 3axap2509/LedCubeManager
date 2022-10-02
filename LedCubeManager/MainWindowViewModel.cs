using System.IO.Ports;

namespace LedCubeManager
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly SerialPort? _cubeComPort;
        public MainWindowViewModel(SerialPort? sp)
        {
            _cubeComPort = sp;
        }
        private byte spedSliderValue = 1;
        public byte SpeedSliderValue
        {
            get => spedSliderValue;
            set
            {
                if (spedSliderValue != value)
                {
                    spedSliderValue = value;
                    OnPropertyChange();
                    SetCubeSpeed((byte)(255 - value));
                }
            }
        }

        public void SetCubeSpeed(byte speed)
        {
            if (_cubeComPort == null) return;
            var bytes = new byte[] { speed };
            _cubeComPort.Write(bytes, 0, 1);
            //_cubeComPort.Read(bytes, 0, 1);
        }

    }
}
