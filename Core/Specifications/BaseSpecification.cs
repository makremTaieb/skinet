using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> creteria)
        {
            Creteria = creteria;
        }

        public Expression<Func<T, bool>> Creteria {get;}

        public List<Expression<Func<T, object>>> Includes { get; } = 
                new List<Expression<Func<T, object>>> ();

        public Expression<Func<T, object>> OrderBy { get;  private set ;}

    public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPageningEnabled { get; private set; }

        protected void AddInclude ( Expression<Func<T, object>>  includesExpression ) {
            Includes.Add(includesExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>>  orderByExpresssion ){
            OrderBy = orderByExpresssion ;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>>  orderByDescExpresssion ){
            OrderByDescending = orderByDescExpresssion; 
        }

        protected void ApplyPaging (int skip , int take){
            Skip = skip ;
            Take = take ;
            IsPageningEnabled = true ;
        }

    }
}