using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time {

    [TestClass]
    public class EasterDateTests {

#pragma warning disable 618

        [TestMethod]
        public void GetPalmSunday() {
            Assert.AreEqual("2000-04-16", CalendarHelper.GetPalmSunday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-08", CalendarHelper.GetPalmSunday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-24", CalendarHelper.GetPalmSunday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-13", CalendarHelper.GetPalmSunday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-04", CalendarHelper.GetPalmSunday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-20", CalendarHelper.GetPalmSunday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-09", CalendarHelper.GetPalmSunday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-01", CalendarHelper.GetPalmSunday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-16", CalendarHelper.GetPalmSunday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-05", CalendarHelper.GetPalmSunday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-03-28", CalendarHelper.GetPalmSunday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-17", CalendarHelper.GetPalmSunday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-01", CalendarHelper.GetPalmSunday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-24", CalendarHelper.GetPalmSunday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-13", CalendarHelper.GetPalmSunday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-03-29", CalendarHelper.GetPalmSunday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-20", CalendarHelper.GetPalmSunday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-09", CalendarHelper.GetPalmSunday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-25", CalendarHelper.GetPalmSunday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-14", CalendarHelper.GetPalmSunday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-05", CalendarHelper.GetPalmSunday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-03-28", CalendarHelper.GetPalmSunday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-10", CalendarHelper.GetPalmSunday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-02", CalendarHelper.GetPalmSunday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-24", CalendarHelper.GetPalmSunday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-13", CalendarHelper.GetPalmSunday(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-04-16", CalendarUtils.GetPalmSunday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-08", CalendarUtils.GetPalmSunday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-24", CalendarUtils.GetPalmSunday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-13", CalendarUtils.GetPalmSunday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-04", CalendarUtils.GetPalmSunday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-20", CalendarUtils.GetPalmSunday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-09", CalendarUtils.GetPalmSunday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-01", CalendarUtils.GetPalmSunday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-16", CalendarUtils.GetPalmSunday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-05", CalendarUtils.GetPalmSunday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-03-28", CalendarUtils.GetPalmSunday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-17", CalendarUtils.GetPalmSunday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-01", CalendarUtils.GetPalmSunday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-24", CalendarUtils.GetPalmSunday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-13", CalendarUtils.GetPalmSunday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-03-29", CalendarUtils.GetPalmSunday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-20", CalendarUtils.GetPalmSunday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-09", CalendarUtils.GetPalmSunday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-25", CalendarUtils.GetPalmSunday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-14", CalendarUtils.GetPalmSunday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-05", CalendarUtils.GetPalmSunday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-03-28", CalendarUtils.GetPalmSunday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-10", CalendarUtils.GetPalmSunday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-02", CalendarUtils.GetPalmSunday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-24", CalendarUtils.GetPalmSunday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-13", CalendarUtils.GetPalmSunday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetMoundyThursday() {
            Assert.AreEqual("2000-04-20", CalendarHelper.GetMoundyThursday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-12", CalendarHelper.GetMoundyThursday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-28", CalendarHelper.GetMoundyThursday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-17", CalendarHelper.GetMoundyThursday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-08", CalendarHelper.GetMoundyThursday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-24", CalendarHelper.GetMoundyThursday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-13", CalendarHelper.GetMoundyThursday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-05", CalendarHelper.GetMoundyThursday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-20", CalendarHelper.GetMoundyThursday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-09", CalendarHelper.GetMoundyThursday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-01", CalendarHelper.GetMoundyThursday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-21", CalendarHelper.GetMoundyThursday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-05", CalendarHelper.GetMoundyThursday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-28", CalendarHelper.GetMoundyThursday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-17", CalendarHelper.GetMoundyThursday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-02", CalendarHelper.GetMoundyThursday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-24", CalendarHelper.GetMoundyThursday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-13", CalendarHelper.GetMoundyThursday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-29", CalendarHelper.GetMoundyThursday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-18", CalendarHelper.GetMoundyThursday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-09", CalendarHelper.GetMoundyThursday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-01", CalendarHelper.GetMoundyThursday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-14", CalendarHelper.GetMoundyThursday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-06", CalendarHelper.GetMoundyThursday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-28", CalendarHelper.GetMoundyThursday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-17", CalendarHelper.GetMoundyThursday(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-04-20", CalendarUtils.GetMoundyThursday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-12", CalendarUtils.GetMoundyThursday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-28", CalendarUtils.GetMoundyThursday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-17", CalendarUtils.GetMoundyThursday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-08", CalendarUtils.GetMoundyThursday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-24", CalendarUtils.GetMoundyThursday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-13", CalendarUtils.GetMoundyThursday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-05", CalendarUtils.GetMoundyThursday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-20", CalendarUtils.GetMoundyThursday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-09", CalendarUtils.GetMoundyThursday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-01", CalendarUtils.GetMoundyThursday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-21", CalendarUtils.GetMoundyThursday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-05", CalendarUtils.GetMoundyThursday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-28", CalendarUtils.GetMoundyThursday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-17", CalendarUtils.GetMoundyThursday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-02", CalendarUtils.GetMoundyThursday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-24", CalendarUtils.GetMoundyThursday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-13", CalendarUtils.GetMoundyThursday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-29", CalendarUtils.GetMoundyThursday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-18", CalendarUtils.GetMoundyThursday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-09", CalendarUtils.GetMoundyThursday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-01", CalendarUtils.GetMoundyThursday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-14", CalendarUtils.GetMoundyThursday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-06", CalendarUtils.GetMoundyThursday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-28", CalendarUtils.GetMoundyThursday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-17", CalendarUtils.GetMoundyThursday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetGoodFriday() {
            Assert.AreEqual("2000-04-21", CalendarHelper.GetGoodFriday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-13", CalendarHelper.GetGoodFriday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-29", CalendarHelper.GetGoodFriday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-18", CalendarHelper.GetGoodFriday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-09", CalendarHelper.GetGoodFriday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-25", CalendarHelper.GetGoodFriday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-14", CalendarHelper.GetGoodFriday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-06", CalendarHelper.GetGoodFriday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-21", CalendarHelper.GetGoodFriday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-10", CalendarHelper.GetGoodFriday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-02", CalendarHelper.GetGoodFriday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-22", CalendarHelper.GetGoodFriday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-06", CalendarHelper.GetGoodFriday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-29", CalendarHelper.GetGoodFriday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-18", CalendarHelper.GetGoodFriday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-03", CalendarHelper.GetGoodFriday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-25", CalendarHelper.GetGoodFriday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-14", CalendarHelper.GetGoodFriday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-30", CalendarHelper.GetGoodFriday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-19", CalendarHelper.GetGoodFriday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-10", CalendarHelper.GetGoodFriday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-02", CalendarHelper.GetGoodFriday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-15", CalendarHelper.GetGoodFriday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-07", CalendarHelper.GetGoodFriday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-29", CalendarHelper.GetGoodFriday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-18", CalendarHelper.GetGoodFriday(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-04-21", CalendarUtils.GetGoodFriday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-13", CalendarUtils.GetGoodFriday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-29", CalendarUtils.GetGoodFriday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-18", CalendarUtils.GetGoodFriday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-09", CalendarUtils.GetGoodFriday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-25", CalendarUtils.GetGoodFriday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-14", CalendarUtils.GetGoodFriday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-06", CalendarUtils.GetGoodFriday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-21", CalendarUtils.GetGoodFriday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-10", CalendarUtils.GetGoodFriday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-02", CalendarUtils.GetGoodFriday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-22", CalendarUtils.GetGoodFriday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-06", CalendarUtils.GetGoodFriday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-29", CalendarUtils.GetGoodFriday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-18", CalendarUtils.GetGoodFriday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-03", CalendarUtils.GetGoodFriday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-25", CalendarUtils.GetGoodFriday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-14", CalendarUtils.GetGoodFriday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-30", CalendarUtils.GetGoodFriday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-19", CalendarUtils.GetGoodFriday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-10", CalendarUtils.GetGoodFriday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-02", CalendarUtils.GetGoodFriday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-15", CalendarUtils.GetGoodFriday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-07", CalendarUtils.GetGoodFriday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-29", CalendarUtils.GetGoodFriday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-18", CalendarUtils.GetGoodFriday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetHolySaturday() {
            Assert.AreEqual("2000-04-22", CalendarHelper.GetHolySaturday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-14", CalendarHelper.GetHolySaturday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-30", CalendarHelper.GetHolySaturday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-19", CalendarHelper.GetHolySaturday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-10", CalendarHelper.GetHolySaturday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-26", CalendarHelper.GetHolySaturday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-15", CalendarHelper.GetHolySaturday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-07", CalendarHelper.GetHolySaturday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-22", CalendarHelper.GetHolySaturday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-11", CalendarHelper.GetHolySaturday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-03", CalendarHelper.GetHolySaturday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-23", CalendarHelper.GetHolySaturday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-07", CalendarHelper.GetHolySaturday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-30", CalendarHelper.GetHolySaturday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-19", CalendarHelper.GetHolySaturday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-04", CalendarHelper.GetHolySaturday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-26", CalendarHelper.GetHolySaturday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-15", CalendarHelper.GetHolySaturday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-31", CalendarHelper.GetHolySaturday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-20", CalendarHelper.GetHolySaturday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-11", CalendarHelper.GetHolySaturday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-03", CalendarHelper.GetHolySaturday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-16", CalendarHelper.GetHolySaturday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-08", CalendarHelper.GetHolySaturday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-30", CalendarHelper.GetHolySaturday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-19", CalendarHelper.GetHolySaturday(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-04-22", CalendarUtils.GetHolySaturday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-14", CalendarUtils.GetHolySaturday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-30", CalendarUtils.GetHolySaturday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-19", CalendarUtils.GetHolySaturday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-10", CalendarUtils.GetHolySaturday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-26", CalendarUtils.GetHolySaturday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-15", CalendarUtils.GetHolySaturday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-07", CalendarUtils.GetHolySaturday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-22", CalendarUtils.GetHolySaturday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-11", CalendarUtils.GetHolySaturday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-03", CalendarUtils.GetHolySaturday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-23", CalendarUtils.GetHolySaturday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-07", CalendarUtils.GetHolySaturday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-30", CalendarUtils.GetHolySaturday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-19", CalendarUtils.GetHolySaturday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-04", CalendarUtils.GetHolySaturday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-26", CalendarUtils.GetHolySaturday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-15", CalendarUtils.GetHolySaturday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-03-31", CalendarUtils.GetHolySaturday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-20", CalendarUtils.GetHolySaturday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-11", CalendarUtils.GetHolySaturday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-03", CalendarUtils.GetHolySaturday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-16", CalendarUtils.GetHolySaturday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-08", CalendarUtils.GetHolySaturday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-30", CalendarUtils.GetHolySaturday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-19", CalendarUtils.GetHolySaturday(2025).ToString("yyyy-MM-dd"));
        }

        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Easter#Table_of_the_dates_of_Easter</cref>
        /// </see>
        [TestMethod]
        public void GetEasterSunday() {
            Assert.AreEqual("2000-04-23", CalendarHelper.GetEasterSunday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-15", CalendarHelper.GetEasterSunday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-31", CalendarHelper.GetEasterSunday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-20", CalendarHelper.GetEasterSunday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-11", CalendarHelper.GetEasterSunday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-27", CalendarHelper.GetEasterSunday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-16", CalendarHelper.GetEasterSunday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-08", CalendarHelper.GetEasterSunday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-23", CalendarHelper.GetEasterSunday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-12", CalendarHelper.GetEasterSunday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-04", CalendarHelper.GetEasterSunday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-24", CalendarHelper.GetEasterSunday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-08", CalendarHelper.GetEasterSunday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-31", CalendarHelper.GetEasterSunday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-20", CalendarHelper.GetEasterSunday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-05", CalendarHelper.GetEasterSunday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-27", CalendarHelper.GetEasterSunday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-16", CalendarHelper.GetEasterSunday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-04-01", CalendarHelper.GetEasterSunday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-21", CalendarHelper.GetEasterSunday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-12", CalendarHelper.GetEasterSunday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-04", CalendarHelper.GetEasterSunday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-17", CalendarHelper.GetEasterSunday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-09", CalendarHelper.GetEasterSunday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-31", CalendarHelper.GetEasterSunday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-20", CalendarHelper.GetEasterSunday(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-04-23", CalendarUtils.GetEasterSunday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-15", CalendarUtils.GetEasterSunday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-03-31", CalendarUtils.GetEasterSunday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-20", CalendarUtils.GetEasterSunday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-11", CalendarUtils.GetEasterSunday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-27", CalendarUtils.GetEasterSunday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-16", CalendarUtils.GetEasterSunday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-08", CalendarUtils.GetEasterSunday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-23", CalendarUtils.GetEasterSunday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-12", CalendarUtils.GetEasterSunday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-04", CalendarUtils.GetEasterSunday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-24", CalendarUtils.GetEasterSunday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-08", CalendarUtils.GetEasterSunday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-03-31", CalendarUtils.GetEasterSunday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-20", CalendarUtils.GetEasterSunday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-05", CalendarUtils.GetEasterSunday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-27", CalendarUtils.GetEasterSunday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-16", CalendarUtils.GetEasterSunday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-04-01", CalendarUtils.GetEasterSunday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-21", CalendarUtils.GetEasterSunday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-12", CalendarUtils.GetEasterSunday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-04", CalendarUtils.GetEasterSunday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-17", CalendarUtils.GetEasterSunday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-09", CalendarUtils.GetEasterSunday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-03-31", CalendarUtils.GetEasterSunday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-20", CalendarUtils.GetEasterSunday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetEasterMonday() {
            Assert.AreEqual("2000-04-24", CalendarHelper.GetEasterMonday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-16", CalendarHelper.GetEasterMonday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-04-01", CalendarHelper.GetEasterMonday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-21", CalendarHelper.GetEasterMonday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-12", CalendarHelper.GetEasterMonday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-28", CalendarHelper.GetEasterMonday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-17", CalendarHelper.GetEasterMonday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-09", CalendarHelper.GetEasterMonday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-24", CalendarHelper.GetEasterMonday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-13", CalendarHelper.GetEasterMonday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-05", CalendarHelper.GetEasterMonday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-25", CalendarHelper.GetEasterMonday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-09", CalendarHelper.GetEasterMonday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-04-01", CalendarHelper.GetEasterMonday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-21", CalendarHelper.GetEasterMonday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-06", CalendarHelper.GetEasterMonday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-28", CalendarHelper.GetEasterMonday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-17", CalendarHelper.GetEasterMonday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-04-02", CalendarHelper.GetEasterMonday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-22", CalendarHelper.GetEasterMonday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-13", CalendarHelper.GetEasterMonday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-05", CalendarHelper.GetEasterMonday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-18", CalendarHelper.GetEasterMonday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-10", CalendarHelper.GetEasterMonday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-04-01", CalendarHelper.GetEasterMonday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-21", CalendarHelper.GetEasterMonday(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-04-24", CalendarUtils.GetEasterMonday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-04-16", CalendarUtils.GetEasterMonday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-04-01", CalendarUtils.GetEasterMonday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-04-21", CalendarUtils.GetEasterMonday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-04-12", CalendarUtils.GetEasterMonday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-03-28", CalendarUtils.GetEasterMonday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-04-17", CalendarUtils.GetEasterMonday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-04-09", CalendarUtils.GetEasterMonday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-03-24", CalendarUtils.GetEasterMonday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-04-13", CalendarUtils.GetEasterMonday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-05", CalendarUtils.GetEasterMonday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-04-25", CalendarUtils.GetEasterMonday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-04-09", CalendarUtils.GetEasterMonday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-04-01", CalendarUtils.GetEasterMonday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-04-21", CalendarUtils.GetEasterMonday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-04-06", CalendarUtils.GetEasterMonday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-03-28", CalendarUtils.GetEasterMonday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-04-17", CalendarUtils.GetEasterMonday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-04-02", CalendarUtils.GetEasterMonday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-04-22", CalendarUtils.GetEasterMonday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-04-13", CalendarUtils.GetEasterMonday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-05", CalendarUtils.GetEasterMonday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-04-18", CalendarUtils.GetEasterMonday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-04-10", CalendarUtils.GetEasterMonday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-04-01", CalendarUtils.GetEasterMonday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-04-21", CalendarUtils.GetEasterMonday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetAscensionDay() {
            Assert.AreEqual("2000-06-01", CalendarHelper.GetAscensionDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-05-24", CalendarHelper.GetAscensionDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-05-09", CalendarHelper.GetAscensionDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-05-29", CalendarHelper.GetAscensionDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-20", CalendarHelper.GetAscensionDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-05-05", CalendarHelper.GetAscensionDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-05-25", CalendarHelper.GetAscensionDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-17", CalendarHelper.GetAscensionDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-05-01", CalendarHelper.GetAscensionDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-05-21", CalendarHelper.GetAscensionDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-05-13", CalendarHelper.GetAscensionDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-02", CalendarHelper.GetAscensionDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-17", CalendarHelper.GetAscensionDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-05-09", CalendarHelper.GetAscensionDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-05-29", CalendarHelper.GetAscensionDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-14", CalendarHelper.GetAscensionDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-05-05", CalendarHelper.GetAscensionDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-05-25", CalendarHelper.GetAscensionDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-05-10", CalendarHelper.GetAscensionDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-05-30", CalendarHelper.GetAscensionDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-05-21", CalendarHelper.GetAscensionDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-05-13", CalendarHelper.GetAscensionDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-05-26", CalendarHelper.GetAscensionDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-18", CalendarHelper.GetAscensionDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-05-09", CalendarHelper.GetAscensionDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-05-29", CalendarHelper.GetAscensionDay(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-06-01", CalendarUtils.GetAscensionDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-05-24", CalendarUtils.GetAscensionDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-05-09", CalendarUtils.GetAscensionDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-05-29", CalendarUtils.GetAscensionDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-20", CalendarUtils.GetAscensionDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-05-05", CalendarUtils.GetAscensionDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-05-25", CalendarUtils.GetAscensionDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-17", CalendarUtils.GetAscensionDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-05-01", CalendarUtils.GetAscensionDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-05-21", CalendarUtils.GetAscensionDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-05-13", CalendarUtils.GetAscensionDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-02", CalendarUtils.GetAscensionDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-17", CalendarUtils.GetAscensionDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-05-09", CalendarUtils.GetAscensionDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-05-29", CalendarUtils.GetAscensionDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-14", CalendarUtils.GetAscensionDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-05-05", CalendarUtils.GetAscensionDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-05-25", CalendarUtils.GetAscensionDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-05-10", CalendarUtils.GetAscensionDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-05-30", CalendarUtils.GetAscensionDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-05-21", CalendarUtils.GetAscensionDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-05-13", CalendarUtils.GetAscensionDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-05-26", CalendarUtils.GetAscensionDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-18", CalendarUtils.GetAscensionDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-05-09", CalendarUtils.GetAscensionDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-05-29", CalendarUtils.GetAscensionDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetWhitSunday() {
            Assert.AreEqual("2000-06-11", CalendarHelper.GetWhitSunday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-06-03", CalendarHelper.GetWhitSunday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-05-19", CalendarHelper.GetWhitSunday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-06-08", CalendarHelper.GetWhitSunday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-30", CalendarHelper.GetWhitSunday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-05-15", CalendarHelper.GetWhitSunday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-06-04", CalendarHelper.GetWhitSunday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-27", CalendarHelper.GetWhitSunday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-05-11", CalendarHelper.GetWhitSunday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-05-31", CalendarHelper.GetWhitSunday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-05-23", CalendarHelper.GetWhitSunday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-12", CalendarHelper.GetWhitSunday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-27", CalendarHelper.GetWhitSunday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-05-19", CalendarHelper.GetWhitSunday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-06-08", CalendarHelper.GetWhitSunday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-24", CalendarHelper.GetWhitSunday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-05-15", CalendarHelper.GetWhitSunday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-06-04", CalendarHelper.GetWhitSunday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-05-20", CalendarHelper.GetWhitSunday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-06-09", CalendarHelper.GetWhitSunday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-05-31", CalendarHelper.GetWhitSunday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-05-23", CalendarHelper.GetWhitSunday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-06-05", CalendarHelper.GetWhitSunday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-28", CalendarHelper.GetWhitSunday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-05-19", CalendarHelper.GetWhitSunday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-06-08", CalendarHelper.GetWhitSunday(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-06-11", CalendarUtils.GetWhitSunday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-06-03", CalendarUtils.GetWhitSunday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-05-19", CalendarUtils.GetWhitSunday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-06-08", CalendarUtils.GetWhitSunday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-30", CalendarUtils.GetWhitSunday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-05-15", CalendarUtils.GetWhitSunday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-06-04", CalendarUtils.GetWhitSunday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-27", CalendarUtils.GetWhitSunday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-05-11", CalendarUtils.GetWhitSunday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-05-31", CalendarUtils.GetWhitSunday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-05-23", CalendarUtils.GetWhitSunday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-12", CalendarUtils.GetWhitSunday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-27", CalendarUtils.GetWhitSunday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-05-19", CalendarUtils.GetWhitSunday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-06-08", CalendarUtils.GetWhitSunday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-24", CalendarUtils.GetWhitSunday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-05-15", CalendarUtils.GetWhitSunday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-06-04", CalendarUtils.GetWhitSunday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-05-20", CalendarUtils.GetWhitSunday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-06-09", CalendarUtils.GetWhitSunday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-05-31", CalendarUtils.GetWhitSunday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-05-23", CalendarUtils.GetWhitSunday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-06-05", CalendarUtils.GetWhitSunday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-28", CalendarUtils.GetWhitSunday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-05-19", CalendarUtils.GetWhitSunday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-06-08", CalendarUtils.GetWhitSunday(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetWhitMonday() {
            Assert.AreEqual("2000-06-12", CalendarHelper.GetWhitMonday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-06-04", CalendarHelper.GetWhitMonday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-05-20", CalendarHelper.GetWhitMonday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-06-09", CalendarHelper.GetWhitMonday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-31", CalendarHelper.GetWhitMonday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-05-16", CalendarHelper.GetWhitMonday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-06-05", CalendarHelper.GetWhitMonday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-28", CalendarHelper.GetWhitMonday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-05-12", CalendarHelper.GetWhitMonday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-06-01", CalendarHelper.GetWhitMonday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-05-24", CalendarHelper.GetWhitMonday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-13", CalendarHelper.GetWhitMonday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-28", CalendarHelper.GetWhitMonday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-05-20", CalendarHelper.GetWhitMonday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-06-09", CalendarHelper.GetWhitMonday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-25", CalendarHelper.GetWhitMonday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-05-16", CalendarHelper.GetWhitMonday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-06-05", CalendarHelper.GetWhitMonday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-05-21", CalendarHelper.GetWhitMonday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-06-10", CalendarHelper.GetWhitMonday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-06-01", CalendarHelper.GetWhitMonday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-05-24", CalendarHelper.GetWhitMonday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-06-06", CalendarHelper.GetWhitMonday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-29", CalendarHelper.GetWhitMonday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-05-20", CalendarHelper.GetWhitMonday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-06-09", CalendarHelper.GetWhitMonday(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-06-12", CalendarUtils.GetWhitMonday(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-06-04", CalendarUtils.GetWhitMonday(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-05-20", CalendarUtils.GetWhitMonday(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-06-09", CalendarUtils.GetWhitMonday(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-31", CalendarUtils.GetWhitMonday(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-05-16", CalendarUtils.GetWhitMonday(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-06-05", CalendarUtils.GetWhitMonday(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-28", CalendarUtils.GetWhitMonday(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-05-12", CalendarUtils.GetWhitMonday(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-06-01", CalendarUtils.GetWhitMonday(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-05-24", CalendarUtils.GetWhitMonday(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-13", CalendarUtils.GetWhitMonday(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-28", CalendarUtils.GetWhitMonday(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-05-20", CalendarUtils.GetWhitMonday(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-06-09", CalendarUtils.GetWhitMonday(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-25", CalendarUtils.GetWhitMonday(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-05-16", CalendarUtils.GetWhitMonday(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-06-05", CalendarUtils.GetWhitMonday(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-05-21", CalendarUtils.GetWhitMonday(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-06-10", CalendarUtils.GetWhitMonday(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-06-01", CalendarUtils.GetWhitMonday(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-05-24", CalendarUtils.GetWhitMonday(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-06-06", CalendarUtils.GetWhitMonday(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-29", CalendarUtils.GetWhitMonday(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-05-20", CalendarUtils.GetWhitMonday(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-06-09", CalendarUtils.GetWhitMonday(2025).ToString("yyyy-MM-dd"));

        }

#pragma warning restore 618

    }

}