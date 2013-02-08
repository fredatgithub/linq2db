﻿using System;
using System.Data;
using System.Linq.Expressions;

namespace LinqToDB
{
	using Linq;
	using Mapping;
	using SqlProvider;

	public interface IDataContext : IMappingSchemaProvider, IDisposable
	{
		string             ContextID         { get; }
		Func<ISqlProvider> CreateSqlProvider { get; }
		SqlProviderFlags   SqlProviderFlags  { get; }
		Type               DataReaderType    { get; }

		Expression         GetReaderExpression(MappingSchema mappingSchema, IDataReader reader, int idx, Expression readerExpression, Type toType);
		bool?              IsDBNullAllowed    (IDataReader reader, int idx);

		object             SetQuery           (IQueryContext queryContext);
		int                ExecuteNonQuery    (object query);
		object             ExecuteScalar      (object query);
		IDataReader        ExecuteReader      (object query);
		void               ReleaseQuery       (object query);

		string             GetSqlText         (object query);
		IDataContext       Clone              (bool forNestedQuery);

		event EventHandler OnClosing;
	}
}
