using System;
using System.CodeDom;

namespace Sample.Application.Console.Samples
{
    public class BoxingSample
    {
        private Point _test;
        private Object _testObj;

        public BoxingSample()
        {
            _test = new Point(3, 4);
        }

        public void Run()
        {
            System.Console.WriteLine(_test);
            _test.Change(2, 2);
            System.Console.WriteLine(_test);
            _testObj = _test;
            System.Console.WriteLine(_testObj);
            ((Point)_testObj).Change(3, 3);
            System.Console.WriteLine(_testObj);
        }
    }

    public struct Point
    {
        private int px, py;

        public Point(int x, int y)
        {
            px = x;
            py = y;
        }

        public void Change(int x, int y)
        {
            px = x;
            py = y;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", px.ToString(), py.ToString());
        }
    }
}
