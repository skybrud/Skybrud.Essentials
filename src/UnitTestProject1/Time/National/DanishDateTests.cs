using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.National {

    [TestClass]
    public class DanishDateTests {

#pragma warning disable 618

        [TestMethod]
        public void GetGeneralPrayerDay() {
            Assert.AreEqual("2000-05-19", CalendarHelper.Denmark.GetGeneralPrayerDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-05-11", CalendarHelper.Denmark.GetGeneralPrayerDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-04-26", CalendarHelper.Denmark.GetGeneralPrayerDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-05-16", CalendarHelper.Denmark.GetGeneralPrayerDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-07", CalendarHelper.Denmark.GetGeneralPrayerDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-04-22", CalendarHelper.Denmark.GetGeneralPrayerDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-05-12", CalendarHelper.Denmark.GetGeneralPrayerDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-04", CalendarHelper.Denmark.GetGeneralPrayerDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-04-18", CalendarHelper.Denmark.GetGeneralPrayerDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-05-08", CalendarHelper.Denmark.GetGeneralPrayerDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-30", CalendarHelper.Denmark.GetGeneralPrayerDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-05-20", CalendarHelper.Denmark.GetGeneralPrayerDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-04", CalendarHelper.Denmark.GetGeneralPrayerDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-04-26", CalendarHelper.Denmark.GetGeneralPrayerDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-05-16", CalendarHelper.Denmark.GetGeneralPrayerDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-01", CalendarHelper.Denmark.GetGeneralPrayerDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-04-22", CalendarHelper.Denmark.GetGeneralPrayerDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-05-12", CalendarHelper.Denmark.GetGeneralPrayerDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-04-27", CalendarHelper.Denmark.GetGeneralPrayerDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-05-17", CalendarHelper.Denmark.GetGeneralPrayerDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-05-08", CalendarHelper.Denmark.GetGeneralPrayerDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-30", CalendarHelper.Denmark.GetGeneralPrayerDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-05-13", CalendarHelper.Denmark.GetGeneralPrayerDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-05", CalendarHelper.Denmark.GetGeneralPrayerDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-04-26", CalendarHelper.Denmark.GetGeneralPrayerDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-05-16", CalendarHelper.Denmark.GetGeneralPrayerDay(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-05-19", CalendarUtils.Denmark.GetGeneralPrayerDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-05-11", CalendarUtils.Denmark.GetGeneralPrayerDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-04-26", CalendarUtils.Denmark.GetGeneralPrayerDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-05-16", CalendarUtils.Denmark.GetGeneralPrayerDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-05-07", CalendarUtils.Denmark.GetGeneralPrayerDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-04-22", CalendarUtils.Denmark.GetGeneralPrayerDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-05-12", CalendarUtils.Denmark.GetGeneralPrayerDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-05-04", CalendarUtils.Denmark.GetGeneralPrayerDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-04-18", CalendarUtils.Denmark.GetGeneralPrayerDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-05-08", CalendarUtils.Denmark.GetGeneralPrayerDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-04-30", CalendarUtils.Denmark.GetGeneralPrayerDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-05-20", CalendarUtils.Denmark.GetGeneralPrayerDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-05-04", CalendarUtils.Denmark.GetGeneralPrayerDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-04-26", CalendarUtils.Denmark.GetGeneralPrayerDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-05-16", CalendarUtils.Denmark.GetGeneralPrayerDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-05-01", CalendarUtils.Denmark.GetGeneralPrayerDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-04-22", CalendarUtils.Denmark.GetGeneralPrayerDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-05-12", CalendarUtils.Denmark.GetGeneralPrayerDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-04-27", CalendarUtils.Denmark.GetGeneralPrayerDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-05-17", CalendarUtils.Denmark.GetGeneralPrayerDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-05-08", CalendarUtils.Denmark.GetGeneralPrayerDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-04-30", CalendarUtils.Denmark.GetGeneralPrayerDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-05-13", CalendarUtils.Denmark.GetGeneralPrayerDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-05-05", CalendarUtils.Denmark.GetGeneralPrayerDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-04-26", CalendarUtils.Denmark.GetGeneralPrayerDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-05-16", CalendarUtils.Denmark.GetGeneralPrayerDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetConstitutionDay() {
            Assert.AreEqual("2000-06-05", CalendarHelper.Denmark.GetConstitutionDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-06-05", CalendarHelper.Denmark.GetConstitutionDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-06-05", CalendarHelper.Denmark.GetConstitutionDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-06-05", CalendarHelper.Denmark.GetConstitutionDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-06-05", CalendarHelper.Denmark.GetConstitutionDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-06-05", CalendarHelper.Denmark.GetConstitutionDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-06-05", CalendarHelper.Denmark.GetConstitutionDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-06-05", CalendarHelper.Denmark.GetConstitutionDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-06-05", CalendarHelper.Denmark.GetConstitutionDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-06-05", CalendarHelper.Denmark.GetConstitutionDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-06-05", CalendarHelper.Denmark.GetConstitutionDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-05", CalendarHelper.Denmark.GetConstitutionDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-06-05", CalendarHelper.Denmark.GetConstitutionDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-06-05", CalendarHelper.Denmark.GetConstitutionDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-06-05", CalendarHelper.Denmark.GetConstitutionDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-06-05", CalendarHelper.Denmark.GetConstitutionDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-06-05", CalendarHelper.Denmark.GetConstitutionDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-06-05", CalendarHelper.Denmark.GetConstitutionDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-06-05", CalendarHelper.Denmark.GetConstitutionDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-06-05", CalendarHelper.Denmark.GetConstitutionDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-06-05", CalendarHelper.Denmark.GetConstitutionDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-06-05", CalendarHelper.Denmark.GetConstitutionDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-06-05", CalendarHelper.Denmark.GetConstitutionDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-06-05", CalendarHelper.Denmark.GetConstitutionDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-06-05", CalendarHelper.Denmark.GetConstitutionDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-06-05", CalendarHelper.Denmark.GetConstitutionDay(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-06-05", CalendarUtils.Denmark.GetConstitutionDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-06-05", CalendarUtils.Denmark.GetConstitutionDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-06-05", CalendarUtils.Denmark.GetConstitutionDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-06-05", CalendarUtils.Denmark.GetConstitutionDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-06-05", CalendarUtils.Denmark.GetConstitutionDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-06-05", CalendarUtils.Denmark.GetConstitutionDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-06-05", CalendarUtils.Denmark.GetConstitutionDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-06-05", CalendarUtils.Denmark.GetConstitutionDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-06-05", CalendarUtils.Denmark.GetConstitutionDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-06-05", CalendarUtils.Denmark.GetConstitutionDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-06-05", CalendarUtils.Denmark.GetConstitutionDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-06-05", CalendarUtils.Denmark.GetConstitutionDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-06-05", CalendarUtils.Denmark.GetConstitutionDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-06-05", CalendarUtils.Denmark.GetConstitutionDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-06-05", CalendarUtils.Denmark.GetConstitutionDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-06-05", CalendarUtils.Denmark.GetConstitutionDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-06-05", CalendarUtils.Denmark.GetConstitutionDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-06-05", CalendarUtils.Denmark.GetConstitutionDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-06-05", CalendarUtils.Denmark.GetConstitutionDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-06-05", CalendarUtils.Denmark.GetConstitutionDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-06-05", CalendarUtils.Denmark.GetConstitutionDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-06-05", CalendarUtils.Denmark.GetConstitutionDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-06-05", CalendarUtils.Denmark.GetConstitutionDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-06-05", CalendarUtils.Denmark.GetConstitutionDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-06-05", CalendarUtils.Denmark.GetConstitutionDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-06-05", CalendarUtils.Denmark.GetConstitutionDay(2025).ToString("yyyy-MM-dd"));

        }

#pragma warning restore 618

    }

}