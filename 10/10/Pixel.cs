using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    class Pixel
    {
        private int abscissa;
        private int ordinate;
        private int red;
        private int green;
        private int blue;

        public int Abscissia
        {
            set
            {
                abscissa = value;
            }

            get
            {
                return abscissa;
            }
        }

        public int Ordinate
        {
            set
            {
                ordinate = value;
            }

            get
            {
                return ordinate;
            }
        }

        public int Red
        {
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new Exception(" значение КРАСНОГО цвета должно лежать от 0 до 255");
                }

                else
                {
                    red = value;
                }
            }

            get
            {
                return red;
            }
        }

        public int Green
        {
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new Exception(" значение ЗЕЛЁННОГО цвета должно лежать от 0 до 255");
                }

                else
                {
                    green = value;
                }
            }

            get
            {
                return green;
            }
        }

        public int Blue
        {
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new Exception(" значение СИНЕГО цвета должно лежать от 0 до 255");
                }

                else
                {
                    blue = value;
                }
            }

            get
            {
                return blue;
            }
        }

        public override string ToString()
        {
            return $"X = {abscissa}\tY = {ordinate}\t\tR = {red}\tG = {green}\tB = {blue}";
        }
    }
}
