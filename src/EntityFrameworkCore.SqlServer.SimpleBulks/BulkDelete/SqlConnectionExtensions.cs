﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EntityFrameworkCore.SqlServer.SimpleBulks.BulkDelete
{
    public static class SqlConnectionExtensions
    {
        public static void BulkDelete<T>(this SqlConnection connection, IEnumerable<T> data, Expression<Func<T, object>> idSelector, Action<BulkOptions> configureOptions = null)
        {
            string tableName = TableMapper.Resolve(typeof(T));

            new BulkDeleteBuilder<T>(connection)
                .WithData(data)
                .WithId(idSelector)
                .ToTable(tableName)
                .ConfigureBulkOptions(configureOptions)
                .Execute();
        }

        public static void BulkDelete<T>(this SqlConnection connection, IEnumerable<T> data, string idColumn, Action<BulkOptions> configureOptions = null)
        {
            string tableName = TableMapper.Resolve(typeof(T));

            new BulkDeleteBuilder<T>(connection)
                .WithData(data)
                .WithId(idColumn)
                .ToTable(tableName)
                .ConfigureBulkOptions(configureOptions)
                .Execute();
        }

        public static void BulkDelete<T>(this SqlConnection connection, IEnumerable<T> data, IEnumerable<string> idColumns, Action<BulkOptions> configureOptions = null)
        {
            string tableName = TableMapper.Resolve(typeof(T));

            new BulkDeleteBuilder<T>(connection)
                .WithData(data)
                .WithId(idColumns)
                .ToTable(tableName)
                .ConfigureBulkOptions(configureOptions)
                .Execute();
        }

        public static void BulkDelete<T>(this SqlConnection connection, IEnumerable<T> data, string tableName, Expression<Func<T, object>> idSelector, Action<BulkOptions> configureOptions = null)
        {
            new BulkDeleteBuilder<T>(connection)
                .WithData(data)
                .WithId(idSelector)
                .ToTable(tableName)
                .ConfigureBulkOptions(configureOptions)
                .Execute();
        }

        public static void BulkDelete<T>(this SqlConnection connection, IEnumerable<T> data, string tableName, string idColumn, Action<BulkOptions> configureOptions = null)
        {
            new BulkDeleteBuilder<T>(connection)
                .WithData(data)
                .WithId(idColumn)
                .ToTable(tableName)
                .ConfigureBulkOptions(configureOptions)
                .Execute();
        }

        public static void BulkDelete<T>(this SqlConnection connection, IEnumerable<T> data, string tableName, IEnumerable<string> idColumns, Action<BulkOptions> configureOptions = null)
        {
            new BulkDeleteBuilder<T>(connection)
                .WithData(data)
                .WithId(idColumns)
                .ToTable(tableName)
                .ConfigureBulkOptions(configureOptions)
                .Execute();
        }
    }
}
