using System.IO.Ports;
using System.Windows;
using Unity;

namespace LedCubeManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly UnityContainer Container = new UnityContainer();
        private SerialPort? cubeComPort;
        protected override void OnStartup(StartupEventArgs e)
        {
            InitializeUnityContainer();

            MainWindow = new MainWindow();
            MainWindow.DataContext = Container.Resolve<MainWindowViewModel>();
            base.OnStartup(e);
            MainWindow.Show();
        }

        private void InitializeUnityContainer()
        {
            var cumPorts = SerialPort.GetPortNames();
            if (cumPorts.Length == 1)
            {
                cubeComPort = new SerialPort(cumPorts[0], 115200);
                if (!cubeComPort.IsOpen)
                {
                    cubeComPort.Open();
                    Container.RegisterInstance(cubeComPort);
                }
            }
            //var viewModel = Container.Resolve<MainWindowViewModel>();
            //Container.RegisterInstance(viewModel);
            Container.RegisterInstance(this);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            cubeComPort?.Dispose();
            base.OnExit(e);
        }
    }
}
