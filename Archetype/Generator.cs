using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Reflection;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;

namespace Archetype
{
    public class Generator<TContext> where TContext : ObjectContext
    {
        TContext _context;

        public Generator()
        {
            Type t = typeof(TContext);
            ConstructorInfo ci = t.GetConstructor(null);
            _context = (ci.Invoke(null) as TContext);
        }

        public T Build<T>() where T : EntityObject
        {
            Type t = typeof(T);
            ConstructorInfo ci = t.GetConstructor(null);
            _context.AddObject(Helpers.Pluralize(t), t);
            return ci.Invoke(null) as T;
        }

        public T Make<T>() where T : EntityObject
        {
            T t = this.Build<T>();
            _context.SaveChanges();
            return t;
        }
    }

    public class Helpers
    {
        public static String Pluralize(string word)
        {
            return PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(word);
        }

        public static String Pluralize(Type t)
        {
            return Pluralize(t.Name.ToString());
        }

        public static String Pluralize(EntityObject obj)
        {
            return Pluralize(obj.GetType());
        }
    }
}
