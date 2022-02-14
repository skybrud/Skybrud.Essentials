﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.National {

    [TestClass]
    public class CanadianDateTests {

#pragma warning disable 618

        [TestMethod]
        public void GetCanadaDay() {
            Assert.AreEqual("2000-07-01", CalendarHelper.Canada.GetCanadaDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-07-01", CalendarHelper.Canada.GetCanadaDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-07-01", CalendarHelper.Canada.GetCanadaDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-07-01", CalendarHelper.Canada.GetCanadaDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-07-01", CalendarHelper.Canada.GetCanadaDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-07-01", CalendarHelper.Canada.GetCanadaDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-07-01", CalendarHelper.Canada.GetCanadaDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-07-01", CalendarHelper.Canada.GetCanadaDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-07-01", CalendarHelper.Canada.GetCanadaDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-07-01", CalendarHelper.Canada.GetCanadaDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-07-01", CalendarHelper.Canada.GetCanadaDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-07-01", CalendarHelper.Canada.GetCanadaDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-07-01", CalendarHelper.Canada.GetCanadaDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-07-01", CalendarHelper.Canada.GetCanadaDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-07-01", CalendarHelper.Canada.GetCanadaDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-07-01", CalendarHelper.Canada.GetCanadaDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-07-01", CalendarHelper.Canada.GetCanadaDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-07-01", CalendarHelper.Canada.GetCanadaDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-07-01", CalendarHelper.Canada.GetCanadaDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-07-01", CalendarHelper.Canada.GetCanadaDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-07-01", CalendarHelper.Canada.GetCanadaDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-07-01", CalendarHelper.Canada.GetCanadaDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-07-01", CalendarHelper.Canada.GetCanadaDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-07-01", CalendarHelper.Canada.GetCanadaDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-07-01", CalendarHelper.Canada.GetCanadaDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-07-01", CalendarHelper.Canada.GetCanadaDay(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-07-01", CalendarUtils.Canada.GetCanadaDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-07-01", CalendarUtils.Canada.GetCanadaDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-07-01", CalendarUtils.Canada.GetCanadaDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-07-01", CalendarUtils.Canada.GetCanadaDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-07-01", CalendarUtils.Canada.GetCanadaDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-07-01", CalendarUtils.Canada.GetCanadaDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-07-01", CalendarUtils.Canada.GetCanadaDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-07-01", CalendarUtils.Canada.GetCanadaDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-07-01", CalendarUtils.Canada.GetCanadaDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-07-01", CalendarUtils.Canada.GetCanadaDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-07-01", CalendarUtils.Canada.GetCanadaDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-07-01", CalendarUtils.Canada.GetCanadaDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-07-01", CalendarUtils.Canada.GetCanadaDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-07-01", CalendarUtils.Canada.GetCanadaDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-07-01", CalendarUtils.Canada.GetCanadaDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-07-01", CalendarUtils.Canada.GetCanadaDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-07-01", CalendarUtils.Canada.GetCanadaDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-07-01", CalendarUtils.Canada.GetCanadaDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-07-01", CalendarUtils.Canada.GetCanadaDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-07-01", CalendarUtils.Canada.GetCanadaDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-07-01", CalendarUtils.Canada.GetCanadaDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-07-01", CalendarUtils.Canada.GetCanadaDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-07-01", CalendarUtils.Canada.GetCanadaDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-07-01", CalendarUtils.Canada.GetCanadaDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-07-01", CalendarUtils.Canada.GetCanadaDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-07-01", CalendarUtils.Canada.GetCanadaDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetLabourDay() {
            Assert.AreEqual("2000-09-04", CalendarHelper.Canada.GetLabourDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-09-03", CalendarHelper.Canada.GetLabourDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-09-02", CalendarHelper.Canada.GetLabourDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-09-01", CalendarHelper.Canada.GetLabourDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-09-06", CalendarHelper.Canada.GetLabourDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-09-05", CalendarHelper.Canada.GetLabourDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-09-04", CalendarHelper.Canada.GetLabourDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-09-03", CalendarHelper.Canada.GetLabourDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-09-01", CalendarHelper.Canada.GetLabourDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-09-07", CalendarHelper.Canada.GetLabourDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-09-06", CalendarHelper.Canada.GetLabourDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-09-05", CalendarHelper.Canada.GetLabourDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-09-03", CalendarHelper.Canada.GetLabourDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-09-02", CalendarHelper.Canada.GetLabourDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-09-01", CalendarHelper.Canada.GetLabourDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-09-07", CalendarHelper.Canada.GetLabourDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-09-05", CalendarHelper.Canada.GetLabourDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-09-04", CalendarHelper.Canada.GetLabourDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-09-03", CalendarHelper.Canada.GetLabourDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-09-02", CalendarHelper.Canada.GetLabourDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-09-07", CalendarHelper.Canada.GetLabourDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-09-06", CalendarHelper.Canada.GetLabourDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-09-05", CalendarHelper.Canada.GetLabourDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-09-04", CalendarHelper.Canada.GetLabourDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-09-02", CalendarHelper.Canada.GetLabourDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-09-01", CalendarHelper.Canada.GetLabourDay(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-09-04", CalendarUtils.Canada.GetLabourDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-09-03", CalendarUtils.Canada.GetLabourDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-09-02", CalendarUtils.Canada.GetLabourDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-09-01", CalendarUtils.Canada.GetLabourDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-09-06", CalendarUtils.Canada.GetLabourDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-09-05", CalendarUtils.Canada.GetLabourDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-09-04", CalendarUtils.Canada.GetLabourDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-09-03", CalendarUtils.Canada.GetLabourDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-09-01", CalendarUtils.Canada.GetLabourDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-09-07", CalendarUtils.Canada.GetLabourDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-09-06", CalendarUtils.Canada.GetLabourDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-09-05", CalendarUtils.Canada.GetLabourDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-09-03", CalendarUtils.Canada.GetLabourDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-09-02", CalendarUtils.Canada.GetLabourDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-09-01", CalendarUtils.Canada.GetLabourDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-09-07", CalendarUtils.Canada.GetLabourDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-09-05", CalendarUtils.Canada.GetLabourDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-09-04", CalendarUtils.Canada.GetLabourDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-09-03", CalendarUtils.Canada.GetLabourDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-09-02", CalendarUtils.Canada.GetLabourDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-09-07", CalendarUtils.Canada.GetLabourDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-09-06", CalendarUtils.Canada.GetLabourDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-09-05", CalendarUtils.Canada.GetLabourDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-09-04", CalendarUtils.Canada.GetLabourDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-09-02", CalendarUtils.Canada.GetLabourDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-09-01", CalendarUtils.Canada.GetLabourDay(2025).ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        public void GetThanksgivingDay() {
            Assert.AreEqual("2000-10-09", CalendarHelper.Canada.GetThanksgivingDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-10-08", CalendarHelper.Canada.GetThanksgivingDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-10-14", CalendarHelper.Canada.GetThanksgivingDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-10-13", CalendarHelper.Canada.GetThanksgivingDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-10-11", CalendarHelper.Canada.GetThanksgivingDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-10-10", CalendarHelper.Canada.GetThanksgivingDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-10-09", CalendarHelper.Canada.GetThanksgivingDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-10-08", CalendarHelper.Canada.GetThanksgivingDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-10-13", CalendarHelper.Canada.GetThanksgivingDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-10-12", CalendarHelper.Canada.GetThanksgivingDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-10-11", CalendarHelper.Canada.GetThanksgivingDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-10-10", CalendarHelper.Canada.GetThanksgivingDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-10-08", CalendarHelper.Canada.GetThanksgivingDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-10-14", CalendarHelper.Canada.GetThanksgivingDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-10-13", CalendarHelper.Canada.GetThanksgivingDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-10-12", CalendarHelper.Canada.GetThanksgivingDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-10-10", CalendarHelper.Canada.GetThanksgivingDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-10-09", CalendarHelper.Canada.GetThanksgivingDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-10-08", CalendarHelper.Canada.GetThanksgivingDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-10-14", CalendarHelper.Canada.GetThanksgivingDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-10-12", CalendarHelper.Canada.GetThanksgivingDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-10-11", CalendarHelper.Canada.GetThanksgivingDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-10-10", CalendarHelper.Canada.GetThanksgivingDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-10-09", CalendarHelper.Canada.GetThanksgivingDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-10-14", CalendarHelper.Canada.GetThanksgivingDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-10-13", CalendarHelper.Canada.GetThanksgivingDay(2025).ToString("yyyy-MM-dd"));

            Assert.AreEqual("2000-10-09", CalendarUtils.Canada.GetThanksgivingDay(2000).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2001-10-08", CalendarUtils.Canada.GetThanksgivingDay(2001).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2002-10-14", CalendarUtils.Canada.GetThanksgivingDay(2002).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2003-10-13", CalendarUtils.Canada.GetThanksgivingDay(2003).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2004-10-11", CalendarUtils.Canada.GetThanksgivingDay(2004).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2005-10-10", CalendarUtils.Canada.GetThanksgivingDay(2005).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2006-10-09", CalendarUtils.Canada.GetThanksgivingDay(2006).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2007-10-08", CalendarUtils.Canada.GetThanksgivingDay(2007).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2008-10-13", CalendarUtils.Canada.GetThanksgivingDay(2008).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2009-10-12", CalendarUtils.Canada.GetThanksgivingDay(2009).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2010-10-11", CalendarUtils.Canada.GetThanksgivingDay(2010).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2011-10-10", CalendarUtils.Canada.GetThanksgivingDay(2011).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2012-10-08", CalendarUtils.Canada.GetThanksgivingDay(2012).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-10-14", CalendarUtils.Canada.GetThanksgivingDay(2013).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2014-10-13", CalendarUtils.Canada.GetThanksgivingDay(2014).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2015-10-12", CalendarUtils.Canada.GetThanksgivingDay(2015).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2016-10-10", CalendarUtils.Canada.GetThanksgivingDay(2016).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2017-10-09", CalendarUtils.Canada.GetThanksgivingDay(2017).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2018-10-08", CalendarUtils.Canada.GetThanksgivingDay(2018).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2019-10-14", CalendarUtils.Canada.GetThanksgivingDay(2019).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2020-10-12", CalendarUtils.Canada.GetThanksgivingDay(2020).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2021-10-11", CalendarUtils.Canada.GetThanksgivingDay(2021).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2022-10-10", CalendarUtils.Canada.GetThanksgivingDay(2022).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2023-10-09", CalendarUtils.Canada.GetThanksgivingDay(2023).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2024-10-14", CalendarUtils.Canada.GetThanksgivingDay(2024).ToString("yyyy-MM-dd"));
            Assert.AreEqual("2025-10-13", CalendarUtils.Canada.GetThanksgivingDay(2025).ToString("yyyy-MM-dd"));

        }

#pragma warning restore 618

    }

}