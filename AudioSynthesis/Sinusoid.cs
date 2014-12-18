using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioSynthesis
{
    public class Sinusoid
    {
        private double A, w, phi, y_offset;

        // Constructors
        // I've written far too much VHDL lately...ALIGN ALL THE THINGS.
        public Sinusoid()
        {
            A        = 1;
            w        = 1;
            phi      = 0;
            y_offset = 0;
        }
        public Sinusoid(double A, double w, double phi, double y_offset)
        {
            this.A        = A;
            this.w        = w;
            this.phi      = phi;
            this.y_offset = y_offset;
        }

        // Properties
        public double Amplitude
        {
            get { return A; }
            set { A = value; }
        }
        public double Frequency
        {
            // in Hertz
            get { return Math.PI * 2 * w; }
            set { w = value / (2 * Math.PI); }
        }
        public double Phase
        {
            // in Degrees
            get { return phi * 360 / (2 * Math.PI); }
            set { phi = value * (2 * Math.PI) / 360; }
        }
        public double Offset
        {
            get { return y_offset; }
            set { y_offset = value; }
        }

        public double sample(double t)
        {
            return A * Math.Cos(w * t - phi) + y_offset;
        }
    }
}
