using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GcodeParse
{
    public class PlotterSettings
    {
        public Dictionary<int,Setting> Settings { get; set; }

        public PlotterSettings()
        {
            Settings = new Dictionary<int, Setting>();           
        }

        public void LoadDefault()
        {
            Settings.Clear();

            Settings.Add(0, new Setting
            {
                Title = "Step pulse (uS)",
                Description = "",
                Value = 10,
                ValueType = typeof(int)
            });

            Settings.Add(1, new Setting
            {
                Title = "Step idle delay (mS)",
                Description = "",
                Value = 10,
                ValueType = typeof(int)
            });

            Settings.Add(2, new Setting
            {
                Title = "Step port invert (mask)",
                Description = "",
                Value = 0,
                ValueType = typeof(int)
            });

            Settings.Add(3, new Setting
            {
                Title = "Dir port invert (mask)",
                Description = "",
                Value = 0,
                ValueType = typeof(int)
            });

            Settings.Add(4, new Setting
            {
                Title = "Step enable invert (mask)",
                Description = "",
                Value = 0,
                ValueType = typeof(int)
            });

            Settings.Add(5, new Setting
            {
                Title = "Limit pins invert (mask)",
                Description = "",
                Value = 0,
                ValueType = typeof(int)
            });

            Settings.Add(6, new Setting
            {
                Title = "Proble pin invert (mask)",
                Description = "",
                Value = 0,
                ValueType = typeof(int)
            });

            Settings.Add(10, new Setting
            {
                Title = "Status report (mask)",
                Description = "",
                Value = 1,
                ValueType = typeof(int)
            });

            Settings.Add(11, new Setting
            {
                Title = "Junction deviation (mm)",
                Description = "",
                Value = 0.010f,
                ValueType = typeof(float)
            });

            Settings.Add(12, new Setting
            {
                Title = "Arc tolerance (mm)",
                Description = "",
                Value = 0.002f,
                ValueType = typeof(float)
            });

            Settings.Add(13, new Setting
            {
                Title = "Report inches (bool)",
                Description = "",
                Value = false,
                ValueType = typeof(bool)
            });

            Settings.Add(20, new Setting
            {
                Title = "Soft limits (bool)",
                Description = "",
                Value = false,
                ValueType = typeof(bool)
            });

            Settings.Add(21, new Setting
            {
                Title = "Hard limits (bool)",
                Description = "",
                Value = false,
                ValueType = typeof(bool)
            });

            Settings.Add(22, new Setting
            {
                Title = "Homing cycle (bool)",
                Description = "",
                Value = true,
                ValueType = typeof(bool)
            });

            Settings.Add(23, new Setting
            {
                Title = "Homing direction (mask)",
                Description = "",
                Value = 0,
                ValueType = typeof(int)
            });

            Settings.Add(24, new Setting
            {
                Title = "Homing feed (mm/min)",
                Description = "",
                Value = 25.0f,
                ValueType = typeof(float)
            });

            Settings.Add(25, new Setting
            {
                Title = "Homing seek (mm/min)",
                Description = "",
                Value = 500.0f,
                ValueType = typeof(float)
            });

            Settings.Add(26, new Setting
            {
                Title = "Homing debounce (mS)",
                Description = "",
                Value = 250,
                ValueType = typeof(int)
            });

            Settings.Add(27, new Setting
            {
                Title = "Homing pull-off (mm)",
                Description = "",
                Value = 1.00f,
                ValueType = typeof(float)
            });

            Settings.Add(30, new Setting
            {
                Title = "Max servo value (val)",
                Description = "",
                Value = 255,
                ValueType = typeof(int)
            });

            Settings.Add(31, new Setting
            {
                Title = "Min spindle speed (RPM)",
                Description = "",
                Value = 0.0f,
                ValueType = typeof(float)
            });

            Settings.Add(32, new Setting
            {
                Title = "Laser mode (bool)",
                Description = "",
                Value = false,
                ValueType = typeof(bool)
            });

            Settings.Add(100, new Setting
            {
                Title = "X steps/mm",
                Description = "",
                Value = 250.0f,
                ValueType = typeof(float)
            });

            Settings.Add(101, new Setting
            {
                Title = "Y steps/mm",
                Description = "",
                Value = 250.0f,
                ValueType = typeof(float)
            });

            Settings.Add(102, new Setting
            {
                Title = "Z steps/mm",
                Description = "",
                Value = 250.0f,
                ValueType = typeof(float)
            });

            Settings.Add(110, new Setting
            {
                Title = "X max rate (mm/min)",
                Description = "",
                Value = 500.0f,
                ValueType = typeof(float)
            });

            Settings.Add(111, new Setting
            {
                Title = "Y max rate (mm/min)",
                Description = "",
                Value = 500.0f,
                ValueType = typeof(float)
            });

            Settings.Add(112, new Setting
            {
                Title = "Z max rate (mm/min)",
                Description = "",
                Value = 500.0f,
                ValueType = typeof(float)
            });

            Settings.Add(120, new Setting
            {
                Title = "X acceleration (mm/sec^2)",
                Description = "",
                Value = 10.0f,
                ValueType = typeof(float)
            });

            Settings.Add(121, new Setting
            {
                Title = "Y acceleration (mm/sec^2)",
                Description = "",
                Value = 10.0f,
                ValueType = typeof(float)
            });

            Settings.Add(122, new Setting
            {
                Title = "Z acceleration (mm/sec^2)",
                Description = "",
                Value = 10.0f,
                ValueType = typeof(float)
            });

            Settings.Add(130, new Setting
            {
                Title = "X max travel (mm)",
                Description = "",
                Value = 200.0f,
                ValueType = typeof(float)
            });

            Settings.Add(131, new Setting
            {
                Title = "Y max travel (mm)",
                Description = "",
                Value = 200.0f,
                ValueType = typeof(float)
            });

            Settings.Add(132, new Setting
            {
                Title = "Z max travel (mm)",
                Description = "",
                Value = 200.0f,
                ValueType = typeof(float)
            });
        }

        public bool ParseSetting(string line)
        {

            var st = line.Trim().Replace("$", "");
            var values = st.Split('=');
            int index = int.Parse(values[0]);

            var type = Settings[index].ValueType;

            if (type == typeof(float))
            {
                Settings[index].Value = float.Parse(values[1]);
            }
            else if(type == typeof(int))
            {
                Settings[index].Value = int.Parse(values[1]);
            }
            else if (type == typeof(bool))
            {
                var val = int.Parse(values[1]);
                if (val == 1)
                {
                    Settings[index].Value = true;
                }
                else
                {
                    Settings[index].Value = false;
                }
            }



            return false;
        }
    }


    public class Setting
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public object Value { get; set; }
        public Type ValueType { get; set; }

    }
}
