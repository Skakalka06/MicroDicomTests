using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroDicom_Tests
{
    [TestFixture]
    public class AnnotationTests : TestBase
    {
        [Test]
        public void AddAnnotationTest()
        {
            // в данном тесте достаточно просто открыть 
            //диалоговое окно с аннотацией, так как даже при нажатии на "Cancel" аннотация сохарняется
            bool isAdd = false;

            if (app.Help.CheckFileIsLoaded()) //проверка на то, что снимок загружен
            {
                app.Help.AddAnnotation();
                isAdd = true;
            }

                Assert.True(isAdd);
        }
    }
}
