using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroDicom_Tests
{
    [TestFixture]
    public class LoadFiles: TestBase
    {
        [Test]
        public void LoadFile()
        {
            //проверка открыт ли файл со снимком

            Assert.IsTrue(app.Help.CheckFileIsLoaded());

        }
    }
}
