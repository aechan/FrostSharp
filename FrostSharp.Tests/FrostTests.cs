using System;
using Xunit;
using FrostSharp;

namespace FrostSharp.Tests
{
    public class FrostTests
    {
        private string APIKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1lQGFsZWNjaGFuLmlvIiwiY2xpZW50X3Rva2VuIjoiNzU2MzcxYjYtZTQ1Zi1jMjA0LTE5NzQtZTI2MzhkMzU5NzQyIiwiaWF0IjoxNTE4MTM2OTM2LCJleHAiOjE1MjA5MDE3MzZ9.OrW6ehTROv1T6B1nzIdVrx1bt2j2Sw1WVz-L2FJxe7o";
        private const bool Logging = false;
        private Configuration GetConfiguration() 
        {
            return new Configuration("https://api.frost.po.et");
        }


        [Fact]
        public async void TestGetWork()
        {
            Frost frost = new Frost(APIKey, GetConfiguration(), Logging);

            string workId = "7a7077892b0b46c4da7d27612759de62ff8ab00fba93ad4a943bc03bd876a2a2";

            var work = await frost.GetWork(workId);

            Assert.Equal("God", work.Author);
        }

        [Fact]
        public async void TestPostWork()
        {
            Frost frost = new Frost(APIKey, GetConfiguration(), Logging);

            var work = new WorkAttributes(
                "Test Work",
                DateTime.Now,
                DateTime.Now,
                "Alec Chan",
                "test, test",
                "This is a test from C#"
            );

            string workId = await frost.CreateWork(work);

            Assert.False(string.IsNullOrEmpty(workId));
            Assert.DoesNotContain(workId, " ");
        }

        [Fact]
        public async void TestGetAllWorks()
        {
            Frost frost = new Frost(APIKey, GetConfiguration(), Logging);

            var list = await frost.GetAllWorks();

            Assert.True(list.Count > 0);
        }
    }
}
