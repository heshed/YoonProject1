using Nett;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoonProject1
{
    class Config
    {
        public Resolution Resolution { get; set; }
    }

    class Resolution
    {
        public int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        public int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        public int windowWidth { get; set; }
        public int windowHeight { get; set; }
        public int imageWidth { get; set; }
        public int imageHeight { get; set; }
    }

    class DefaultConfig
    {
        public void write()
        {
            var config = new Config()
            {
                Resolution = new Resolution()
                {
                    windowWidth = 1920,
                    windowHeight = 1080,
                },
            };

            Toml.WriteFile(config, "config.tml");
        }
    }
}
