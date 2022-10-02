using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedCubeManager
{
    public enum DriverCommandEnum : byte
    {
        ResetAll = 11,
        ResetLayer = 12,
        ResetLayers = 13,

        SetDelay = 21,

        DrawLine = 31,
        DrawDot = 32,
        DrawSquare = 33,
        DrawCircle = 34,

        AddLayer = 41,
    }
    public class CubeDriver
    {
        private readonly SerialPort _cubeSerialPort;
        public CubeDriver(SerialPort sp)
        {
            _cubeSerialPort = sp;
        }
        private void SendCommand(byte[] bytes)
        {
            _cubeSerialPort.Write(bytes, 0, bytes.Length);
        }

        public void ResetAll()
        {
            var bytes = new Byte[] { 
                DriverCommandEnum.ResetAll.GetByteValue() 
            };
            SendCommand(bytes);
        }
        public void ResetLayer(int layerNumber)
        {
            var bytes = new Byte[] {
                DriverCommandEnum.ResetLayer.GetByteValue(),
                (byte)layerNumber
            };
            SendCommand(bytes);
        }

        public void ResetLayers()
        {
            var bytes = new byte[]
            {
                DriverCommandEnum.ResetLayers.GetByteValue(),
            };
            SendCommand(bytes);
        }
    }
}
