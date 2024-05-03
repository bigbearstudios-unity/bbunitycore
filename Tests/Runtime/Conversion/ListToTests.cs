﻿using NUnit.Framework;

using BBUnity.Conversion;
using System.Collections.Generic;

namespace Conversion {
    public class ListToTests {

    [Test]
    public void String_ShouldReturnStringWithDefaultSeperator_IfNoSeperatorIsPassed() {
        string result = ListTo.String(new List<string>() {
            "join", "me", "please"
        });

        Assert.AreEqual("join-me-please", result);
    }

    [Test]
    public void String_ShouldReturnStringWithSeperator_IfSeperatorIsPassed() {
        string result = ListTo.String(new List<string>() {
            "join", "me", "please"
        }, " ");

        Assert.AreEqual("join me please", result);
    }
}
}


