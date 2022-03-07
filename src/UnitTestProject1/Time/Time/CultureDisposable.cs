using System;
using System.Globalization;
using System.Threading;

namespace UnitTestProject1.Time.Time {
    
    public class CultureDisposable : IDisposable {

        public CultureInfo OldCulture { get; }

        public CultureInfo OldUICulture { get; }

        public CultureInfo CurrentCulture { get; }

        public CultureInfo CurrentUICulture { get; }

        public CultureDisposable(string culture) {
            OldCulture = Thread.CurrentThread.CurrentCulture;
            OldUICulture = Thread.CurrentThread.CurrentUICulture;
            CurrentCulture = CurrentUICulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = CurrentCulture;
        }

        public CultureDisposable(CultureInfo culture) {
            OldCulture = Thread.CurrentThread.CurrentCulture;
            OldUICulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = culture;
        }
        
        public void Dispose() {
            Thread.CurrentThread.CurrentCulture = OldCulture;
            Thread.CurrentThread.CurrentUICulture = OldUICulture;
        }

    }

}