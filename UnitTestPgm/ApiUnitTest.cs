using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;
using Pgmasst.Utility;
using Pgmasst.WebApi;

namespace UnitTestPgm
{
    [TestClass]
    public class ApiUnitTest
    {
        [TestMethod]
        public void TestWebDataApi()
        {
            var sgpkmapi = new SgpkmApi();
            sgpkmapi.InitApiVersion();
            var indexes = new int[] { 1, 2, 3, 4, 5, 6, 9, 25, 26, 59, 65, 68, 77, 89, 103, 106, 107, 108, 113, 130, 131, 134, 135, 136, 137, 138, 139, 140, 142, 143, 144, 148, 149, 150, 151 };
            var currentPkms = sgpkmapi.GetCurrentSprites("0", indexes)?.ToList();
            
            currentPkms?.ForEach(p =>
            {
                Debug.WriteLine(p);
            });
        }
        [TestMethod]
        public void TestSpeech()
        {

        }
    }
}
