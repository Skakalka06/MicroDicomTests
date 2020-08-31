using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroDicom_Tests
{
    [TestFixture]
    public class PatientsTests : TestBase
    {
        [Test]
        public void PatientIdTest()
        {
            string testPatientID = ""; //добавляем ID пациеннта с которым будем сравнивать

            string patientId = "";
            if (app.Help.CheckFileIsLoaded()) // проверяем, что снимок был загружен
            {
                patientId = app.Help.SearchPatientId(); //ищем id пациента

            }

            else patientId = null;

            Assert.AreEqual(testPatientID, patientId);
        }
    }
}

