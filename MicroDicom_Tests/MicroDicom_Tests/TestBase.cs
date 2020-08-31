﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MicroDicom_Tests
{
    public class TestBase
    {
        public ApplicationManager app;

        [SetUp]
        public void InitAplication()
        {
            app = new ApplicationManager();
        }

        [TearDown]

        public void StopApplication()
        {
            app.Stop();
        }
    }
}

