﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for more information.

namespace EqualExceptionLegacy
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class EqualException
    {
        [IdeFact]
        public void EqualsFailure()
        {
            Assert.Equal(0, 1);
        }

        [IdeFact(Skip = "Test would not pass")]
        public void EqualsSkipped()
        {
            Assert.Equal(0, 1);
        }

        [IdeTheory]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(4, Skip = "Test case will not run")]
        public void EqualsSuccessOrFailureWithParam(int value)
        {
            Assert.Equal(0, value);
        }

        [IdeTheory(Skip = "Test will not run")]
        [InlineData(0)]
        [InlineData(3)]
        public void EqualsWithParamSkipped(int value)
        {
            Assert.Equal(0, value);
        }

        [IdeFact]
        public void EqualsFailureNonXunit()
        {
            throw new InvalidOperationException("Unexpected assertion result.");
        }

        [IdeFact]
        public void EqualsSucceeds()
        {
            Assert.Equal(0, 0);
        }

        [IdeFact]
        public async Task EqualsFailureAsync()
        {
            await Task.Yield();
            Assert.Equal(0, 1);
        }

        [IdeFact]
        public async Task EqualsFailureNonXunitAsync()
        {
            await Task.Yield();
            throw new InvalidOperationException("Unexpected assertion result.");
        }

        [IdeFact]
        public async Task EqualsSucceedsAsync()
        {
            await Task.Yield();
            Assert.Equal(0, 0);
        }
    }
}
