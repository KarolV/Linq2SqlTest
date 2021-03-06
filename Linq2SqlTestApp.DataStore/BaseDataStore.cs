﻿using System;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;

using Linq2SqlTestApp.DataStore.Interface;

namespace Linq2SqlTestApp.DataStore
{
	public abstract class BaseDataStore<T> : IDataInstanceStore<T>
	{
		protected readonly DataContext dbContext;

		protected BaseDataStore(string dbConnectionString)
		{
			this.dbContext = new DataContext(dbConnectionString)
			                 {
				                 DeferredLoadingEnabled = true
			                 };
		}

		protected static LambdaExpression GetExpressionForTableLoad(Expression<Func<T, object>> expression)
		{
			var param = Expression.Parameter(typeof (T), "p");
			var loadDetail =
				Expression.Lambda(Expression.Convert(Expression.Property(param, ((MemberExpression) expression.Body).Member.Name),
				                                     typeof (object)),
				                  param);
			return loadDetail;
		}

		#region Implementation of IDataInstanceStore

		/// <summary>
		/// Retrieve data entities of type <see cref="IQueryable{T}"/>
		/// </summary>
		/// <returns>Data entitiees of type <see cref="IQueryable{T}"/></returns>
		public abstract IQueryable<T> GetDataEntities();

		/// <summary>
		/// Persist the instances of <see cref="IQueryable{T}"/> to data storage
		/// </summary>
		/// <typeparam name="T"><see cref="IQueryable{T}"/> collection of being persisted</typeparam>
		/// <param name="entities"><see cref="IQueryable{T}"/> collection of being persisted</param>
		public abstract void SaveDataEntities(IQueryable<T> entities);

		#endregion
	}
}