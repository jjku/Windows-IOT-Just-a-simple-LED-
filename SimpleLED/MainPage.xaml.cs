using Windows.UI.Xaml.Controls;
using Windows.Devices.Gpio;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SimpleLED
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GpioController gpio;
        GpioPin pin;

        public MainPage()
        {
            this.InitializeComponent();

            gpio = GpioController.GetDefault(); // This initates the GPIO Controller on the Raspberry PI (or any other device for that matter)
            if (gpio == null)
            {
                return; // GPIO not available on this system, this will prevent an exception
            }

            pin = gpio.OpenPin(4); // I believe this initializes the GPIO pin by ID# so that C# can use the pin, in this case 4
            pin.Write(GpioPinValue.High); // Latch HIGH value first. This ensures a default value when the pin is set as output
            pin.SetDriveMode(GpioPinDriveMode.Output); // Set the IO direction as output as opposed to input

            pin.Write(GpioPinValue.Low); // This turns on the LED light and it will remain on
        }
    }
}
