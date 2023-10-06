using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp.DataAccess.Data;
using evdekinisatcom.MvcWebApp.Entity.Repositories;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;

namespace evdekinisatcom.MvcWebApp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
	{
		private readonly AppDbContext _context;
		private DbSet<T> _dbSet;

		public Repository(AppDbContext context)
		{
			_context = context;           //veritabanı
			_dbSet = _context.Set<T>();   //ilgili tablo

		}

		public async Task Add(T entity)
		{
			
			await _dbSet.AddAsync(entity);
		}

		public void Delete(int id)
		{
			var entity = _dbSet.Find(id);
			this.Delete(entity);

		}

		public void Delete(T entity)
		{
			if (entity.GetType().GetProperty("IsDeleted") != null)
			{
				entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
				this.Update(entity);

			}
			else
				_dbSet.Remove(entity);
		}

		public async Task<T> Get(Expression<Func<T, bool>> predicate)
		{
			return await _dbSet.FirstOrDefaultAsync(predicate);
		}

		public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			if (orderby != null)
			{
				query = orderby(query);
			}
			foreach (var table in includes)
			{
				query = query.Include(table);
			}

			return await query.ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.AsNoTracking().ToListAsync(); 
		}

		public async Task<T> GetById(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}

		
	}
}

