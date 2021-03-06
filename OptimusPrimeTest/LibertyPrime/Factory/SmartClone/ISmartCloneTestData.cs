﻿using System;
using OptimusPrimeTest.Prime;

namespace OptimusPrimeTest.LibertyPrime
{
    public interface ISmartCloneTestData
    {
        Guid ValueMember { get; set; }
        TestData LinkedMember { get; set; }
        ISmartCloneTestData CreateCopy();
        void AssertAreEquals(ISmartCloneTestData actual);
    }
}