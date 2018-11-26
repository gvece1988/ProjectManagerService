using NBench;
using ProjectManager.Business.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.NBench
{
    class NBenchTests
    {
        private TaskBLTest taskBLTest;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            taskBLTest = new TaskBLTest(new DbContextFixture());            
        }

        [PerfBenchmark(Description = "Project Manager Unit Test Benchmarking",
                       NumberOfIterations = 5, RunMode = RunMode.Throughput,
                       RunTimeMilliseconds = 5000, TestMode = TestMode.Measurement)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 1024 * 1024)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 100)]
        public void Benchmark()
        {
            taskBLTest.GetAll();            
            taskBLTest.GetById();
            taskBLTest.Add();
            taskBLTest.Update();
            taskBLTest.End();
        }

        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }
    }
}
