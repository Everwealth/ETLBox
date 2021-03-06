using ALE.ETLBox;
using ALE.ETLBox.ConnectionManager;
using ALE.ETLBox.ControlFlow;
using ALE.ETLBox.Helper;
using ALE.ETLBox.Logging;
using ALE.ETLBoxTests.Fixtures;
using System;
using System.Collections.Generic;
using Xunit;

namespace ALE.ETLBoxTests.ControlFlowTests
{
    [Collection("ControlFlow")]
    public class CreateSchemaTaskTests
    {
        public SqlConnectionManager Connection => Config.SqlConnectionManager("ControlFlow");
        public CreateSchemaTaskTests(ControlFlowDatabaseFixture dbFixture)
        { }

        [Fact]
        public void CreateSchema()
        {
            //Arrange
            string schemaName = "s" + HashHelper.RandomString(9);
            //Act
            CreateSchemaTask.Create(Connection, schemaName);
            //Assert
            Assert.Equal(1, RowCountTask.Count(Connection, "sys.schemas",
                $"schema_name(schema_id) = '{schemaName}'"));

        }
    }
}
