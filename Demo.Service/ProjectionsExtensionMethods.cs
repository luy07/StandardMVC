

using System.Collections.Generic;

using Domain.Seedwork;
using Infrastructure.Adapter;

namespace Demo.Service
{
    /// <summary>
    /// 为基类Entity拓展两个Dto方法（一个单实体转换，一个列表转换）
    /// </summary>
   public static class ProjectionsExtensionMethods
   {

      /// <summary>
      ///    Project a type using a DTO
      /// </summary>
      /// <typeparam name="TProjection">The dto projection</typeparam>
      /// <param name="entity">The source entity to project</param>
      /// <returns>The projected type</returns>
      public static TProjection ProjectedAs<TProjection>(this Entity item) where TProjection : class, new()
      {
         var adapter = TypeAdapterFactory.CreateAdapter();
         return adapter.Adapt<TProjection>(item);
      }

      /// <summary>
      ///    projected a enumerable collection of items
      /// </summary>
      /// <typeparam name="TProjection">The dtop projection type</typeparam>
      /// <param name="items">the collection of entity items</param>
      /// <returns>Projected collection</returns>
      public static List<TProjection> ProjectedAsCollection<TProjection>(this IEnumerable<Entity> items)
         where TProjection : class, new()
      {
         var adapter = TypeAdapterFactory.CreateAdapter();
         return adapter.Adapt<List<TProjection>>(items);
      }

   }

}