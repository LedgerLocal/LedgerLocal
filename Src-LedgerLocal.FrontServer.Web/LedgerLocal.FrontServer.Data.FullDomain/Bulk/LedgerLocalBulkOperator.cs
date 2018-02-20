/*
* Copyright ©  2017 Tånneryd IT AB
* 
* This file is part of the tutorial application BulkInsert.App.
* 
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
* 
*   http://www.apache.org/licenses/LICENSE-2.0
* 
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
using Common.Data.Infrastructure;
using LedgerLocal.FrontServer.Data.FullDomain.Bulk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public class LedgerLocalBulkOperator : ILedgerLocalBulkOperator
    {
        private IDatabaseFactory<LedgerLocalDbContext> _databaseFactory;

        public LedgerLocalBulkOperator(IDatabaseFactory<LedgerLocalDbContext> databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task BulkInsertBulkCopy<EntitySimple>(List<EntitySimple> list, IList<Tuple<string, string>> mappings, string destinationTable, int batchSize)
        {
            using (var objReader = new ObjectDataReader<EntitySimple>(list))
            using (var connection = new SqlConnection(@"Server=LedgerLocalWINPROD01\LedgerLocalPRODDB16;Database=LedgerLocal-Main-Prod;User Id=LedgerLocaluserprod;Password=LedgerLocal132@;"))
            {
                connection.Open();

                using (var bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.BatchSize = batchSize;
                    foreach (var m1 in mappings)
                    {
                        bulkCopy.ColumnMappings.Add(m1.Item1, m1.Item2);
                    }
                    
                    bulkCopy.DestinationTableName = destinationTable;
                    await bulkCopy.WriteToServerAsync(objReader);
                }
            }
        }
    }
}