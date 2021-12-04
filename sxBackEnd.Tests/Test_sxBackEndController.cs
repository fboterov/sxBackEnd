using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using sxBackEnd.Controllers;
using sxBackEnd.db;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sxBackEnd.Tests
{
    public class Test_sxBackEndController
    {
        sxBackEndController sxBackEndController;
        IMembersService membersService;

        [SetUp]
        public void Setup()
        {
            membersService = new MembersService();
            sxBackEndController = new sxBackEndController(new Microsoft.Extensions.Logging.Abstractions.NullLogger<sxBackEndController>(), membersService);
        }

        [Test]
        [TestCase(0473128446, 1405677686, 1)]
        [TestCase(null, 1405677686, 1)]
        [TestCase(0473128446, null, 1)]
        public void Test_GetMemberRecorsValid(long? mcm, long? pn, int expected)
        {
            var result = sxBackEndController.GetMemberRecords(mcm, pn);
            var list = result.Result as ObjectResult;
            var memberRecors = list.Value as IEnumerable<Member>;
            Assert.AreEqual(expected, memberRecors.ToList().Count);
        }

        [Test]
        [TestCase(null, null, null)]
        [TestCase(0, 0, null)]
        public void Test_GetMemberRecorsInvalid(long? mcm, long? pn, int? expected)
        {
            var result = sxBackEndController.GetMemberRecords(mcm, pn);
            var list = result.Result as ObjectResult;
            Assert.AreEqual(expected, list);
        }
    }
}