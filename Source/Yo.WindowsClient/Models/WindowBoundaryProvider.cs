using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yo.WindowsClient.Models
{
    public static class WindowBoundaryProvider
    {
        private static double windowWidth;
        private static double windowHeight;

        public static double WindowWidth
        {
            get => windowWidth;
        }

        public static double WindowHeight
        {
            get => windowHeight;
        }

        public static void SetWindowBoundary(double width, double height)
        {
            windowWidth = width;
            windowHeight = height;
        }
    }
}
