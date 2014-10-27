using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DefineClass
{
    class Battery
    {
        // Battery Fields (Task 1.)
        public enum BatteryType { LiIon, NiMH, NiCd }; // Add enumeration (Task 3.)
        private string model;
        private double? hourIdle = null;
        private double? hourTalk = null;

        // Battery Properties (Task 5.)
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public double? HourIdle
        {
            get { return this.hourIdle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours must be a positive number");
                }
                this.hourIdle = value;
            }
        }
        public double? HourTalk
        {
            get
            {
                return this.hourTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours must be a positive number");
                }
                this.hourTalk = value;
            }
        }

        // Battery Constructors (Task 2.)
        public Battery(string model)
        {
            this.model = model;
        }
        public Battery(string model, double idle, double talk)
            : this(model)
        {
            this.hourIdle = idle;
            this.hourTalk = talk;
        }
    }
    class Display
    {
        // Display Fields (Task 1.)
        private ulong? colorNums = null;
        private double? width = null;
        private double? height = null;

        // Display Properties (Task 5.)
        public ulong? ColorNums
        {
            get { return this.colorNums; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The number of colors must be equal or greater than zero!");
                }
                this.colorNums = value;
            }
        }
        public double? Width
        {
            get { return this.width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The width of the display must be a positive number!");
                }
                this.width = value;
            }
        }
        public double? Height
        {
            get { return this.height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The height of the display must be a positive number!");
                }
                this.height = value;
            }
        }

        // Display Constructors (Task 2.)
        public Display()
        {
            colorNums = null;
            width = null;
            height = null;
            this.height = null;
            this.width = null;
            this.colorNums = null;
        }
        public Display(ulong colorNum)
            : this()
        {
            this.colorNums = colorNum;
        }
        public Display(ulong colorNum, double width, double height)
            : this(colorNum)
        {
            this.height = height;
            this.width = width;
        }
    }

    class GSM 
    {
        //GSM Fields (Task 1.)
        //Battery battery = new Battery();
        Display display = new Display();
        private string model = null;
        private string manafacturer = null;
        private decimal? price = null;
        private string owner = null;
        List<Call> callHistory = new List<Call>(); // (Task 9.)
        private static string iPhone4S = null; // GSM Static Field (Task 6.)

        // GSM Properties (Task 5.)
        public static string IPhone4S // GSM Static Property (Task 6.)
        {
            get { return iPhone4S; }
            set { iPhone4S = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public string Manufacturer
        {
            get { return this.manafacturer; }
            set { this.manafacturer = value; }
        }
        public decimal? Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        //Constructors (Task 2.)
        public GSM(string gsmModel, string gsmManufacturer)
        {
            this.model = gsmModel;
            this.manafacturer = gsmManufacturer;
            this.price = 0.0m;
            this.owner = null;
        }
        public GSM(string gsmModel, string gsmManufacturer, decimal gsmPrice)
            : this(gsmModel, gsmManufacturer)
        {
            this.price = gsmPrice;
        }
        public GSM(string gsmModel, string gsmManufacturer, decimal gsmPrice, string gsmOwner)
            : this(gsmModel, gsmManufacturer, gsmPrice)
        {
            this.owner = gsmOwner;
        }

        //<methods>
        public override string ToString() // override ToString() (Task 4.)
        {
            return "Model: " + this.model + " Manufacturer: " + this.manafacturer + " Price: " + this.price + " Owner: " + this.owner;
        }

        // Add methods for adding and deleting calls from the calls history. Add a method to clear the call history. (Task 10.)
        public void AddCall(Call call)
        {
            callHistory.Add(call);
        }
        public void ClearCalls()
        {
            callHistory.Clear();
        }
        public void RemoveCall(Call call)
        {
            for (int i = 0; i < callHistory.Count; i++)
            {
                if (call.Duration == callHistory[i].Duration)
                {
                    callHistory.RemoveAt(i);
                }
            }
        }

        // Add a method that calculates the total price of the calls in the call history. // (Task 11.)
        public decimal? CalculateTotalPrice(decimal pricePerMinute)
        {
            ulong? durationSum = 0;
            foreach (var call in callHistory)
            {
                durationSum += call.Duration;

            }
            return (durationSum / 60) * pricePerMinute;
        }
    }

    class Call // (Task 8.)
    {
        //Fields
        private DateTime? date = null;
        private ulong? duration = null;

        // Properties
        public ulong? Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        // Constructors
        public Call()
        {
            duration = 0;
        }
        public Call(ulong duration)
        {
            this.duration = duration;
        }
        public Call(DateTime date, ulong duration)
            : this(duration)
        {
            this.date = date;
        }
    }

    class GSMCallHistoryTest // (Task 12.)
    {
        static void Main()
        {
            GSM phone = new GSM("Nokia 3310", "Nokia", 999.01m, "PacoGaroPenio");
            phone.AddCall(new Call(11));
            phone.AddCall(new Call(1511));
            phone.AddCall(new Call(123));
            Console.WriteLine(phone.CalculateTotalPrice(0.37m));
            phone.RemoveCall(new Call(1511));
            Console.WriteLine("Total Price after removing: {0}", phone.CalculateTotalPrice(0.37m));
            phone.ClearCalls();
            Console.WriteLine("Total Price after clearing: {0}", phone.CalculateTotalPrice(0.37m));
        }
    }
}
