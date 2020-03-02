﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.SqlServer.SimpleBulks.Extensions
{
    public static class TypeExtensions
    {
        private static Dictionary<Type, string> _mappings = new Dictionary<Type, string>
            {
                {typeof(bool), "bit"},
                {typeof(DateTime), "datetime"},
                {typeof(decimal), "decimal(38, 20)"},
                {typeof(double), "double"},
                {typeof(Guid), "uniqueidentifier"},
                {typeof(short), "smallint"},
                {typeof(int), "int"},
                {typeof(long), "bigint"},
                {typeof(float), "single"},
                {typeof(string), "nvarchar(max)"},
            };

        public static string ToSqlType(this Type type)
        {
            return _mappings.ContainsKey(type) ? _mappings[type] : "nvarchar(max)";
        }

        public static string[] GetDbColumnNames(this Type type, params string[] ignoredColumns)
        {
            var names = type.GetProperties()
                .Where(x => _mappings.Keys.Contains(x.PropertyType))
                .Where(x => ignoredColumns == null || !ignoredColumns.Contains(x.Name))
                .Select(x => x.Name);
            return names.ToArray();
        }

        public static string[] GetUnSupportedDbColumnNames(this Type type)
        {
            var names = type.GetProperties()
                .Where(x => !_mappings.Keys.Contains(x.PropertyType))
                .Select(x => x.Name);
            return names.ToArray();
        }
    }
}
