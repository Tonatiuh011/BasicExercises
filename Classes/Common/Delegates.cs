using System;

namespace Classes.Common {
    public static class Delegates {
        public delegate void OnExeption(Exception ex);
        public delegate decimal MathCallback();
    }
}